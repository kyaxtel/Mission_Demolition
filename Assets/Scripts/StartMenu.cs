using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class StartMenu : MonoBehaviour
{
    [SerializeField] private Configuration configuration;
    public Button startButton;
    public Button Red;
    public Button Blue;
    public Button Green;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        Red.onClick.AddListener(() => SelectColor(0));
        Blue.onClick.AddListener(() => SelectColor(1));
        Green.onClick.AddListener(() => SelectColor(2));
    }

    void StartGame()
    {
        SceneManager.LoadScene("Scene_0");
    }

    void SelectColor(int colorIndex) {
        PlayerPrefs.SetInt("ProjectileColor", colorIndex);
        PlayerPrefs.Save();

        Debug.Log("Color selected and saved to PlayerPrefs: " + colorIndex);
    }
}
