using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Configuration", menuName = "Configuration")]
public class Configuration : ScriptableObject
{
    [field:SerializeField] public float velcoityMultiplier {get; private set;} = 10;
    [field:SerializeField] public int Radius {get; private set;}
    [field:SerializeField] public GameObject BallPrefab {get; private set;}
}
