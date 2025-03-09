using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField] private LineRenderer rubber;
    [SerializeField] private Transform firstPoint;
    [SerializeField] private Transform secondPoint;
    [SerializeField] private Configuration configuration;
    private Transform ballPrefab;
    public GameObject projLinePrefab;
    Vector3 ballPosition = Vector3.zero;
    void Start()
    {
        rubber.SetPosition(0,firstPoint.position);
        rubber.SetPosition(2,secondPoint.position);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            ballPrefab = Instantiate(configuration.BallPrefab).transform;
        }
        if(Input.GetMouseButton(0)){
            ballPosition = GetMousePositionInWorld();
            ballPrefab.position = ballPosition;
            rubber.SetPosition(1, GetMousePositionInWorld());
        }
        if(Input.GetMouseButtonUp(0)) {
            Rigidbody rigidbody = ballPrefab.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            Vector3 launchDirection = (firstPoint.position - ballPosition).normalized;
            rigidbody.linearVelocity = launchDirection * configuration.velcoityMultiplier;
            FollowCam.SWITCH_VIEW(FollowCam.eView.slingshot);
            FollowCam.POI = ballPrefab.gameObject;
            Instantiate<GameObject>(projLinePrefab, ballPrefab.transform);
            ballPrefab = null;
            MissionDemolition.SHOT_FIRED();
        }
    }

    Vector3 GetMousePositionInWorld() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(firstPoint.position).z;
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 offset = mousePositionInWorld - firstPoint.position;
        if(offset.magnitude > configuration.Radius) {
            offset.Normalize();
            offset *= configuration.Radius;
        }
        return firstPoint.position + offset; 
    }
}
