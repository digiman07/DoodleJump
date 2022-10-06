using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public Text PlayerName;
    public GameObject GamePaused;

    //Set Cursor
    void Start()
    {
#if UNITY_EDITOR
        Cursor.SetCursor(PlayerSettings.defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape")) 
        {
            if (GamePaused.activeInHierarchy == false)
            {
                Time.timeScale = 0;
                GamePaused.SetActive(true);
            }
        }
    }

    public void OpenURL(string URL)
    {
        Application.OpenURL(URL);
    }


    public void OpenMHSoftwareURL()
    {
        Application.OpenURL("https://www.facebook.com/malcolm.hough/");
    }

    public void StartGame()
    {
        //Saved Player Name
        PlayerPrefs.SetString("Player Name ", PlayerName.text);

        //Set Level
        PlayerPrefs.SetInt("Level ", 1);

        //Set Gems
        PlayerPrefs.SetInt("Gems ", 000);

        //Load Main Scene
        SceneManager.LoadScene("Main");
    }

    public void ReaumeGame()
    {
        Time.timeScale = 1;
        GamePaused.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
