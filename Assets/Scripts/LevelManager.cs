using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public GameObject Player;
    public Text PlayerName;
    public GameObject LevelGenerator;
    public GameObject CountDown;
    public Text CountDownText;
    public float CountDownTime = 4;
    private int LevelVal = 1;
    public Text LevelText;
    private int NextLevel = 200;
    public Text HighScore;
    private int HighScoreVal;
    public Text Score;
    private int ScoreVal;
    public AudioClip LevelUpSound;

    // Start is called before the first frame update
    void Start()
    {
        //Get Saved Player Name
        PlayerName.text = PlayerPrefs.GetString("Player Name ", PlayerName.ToString());

        //Get Saved High Score
        HighScoreVal = PlayerPrefs.GetInt("High Score ", HighScoreVal);
        HighScore.text = "High Score " + HighScoreVal.ToString("000");

        //Set Level
        PlayerPrefs.SetInt("Level ", 1);
        PlayerPrefs.SetInt("NextLevel ", NextLevel);
        LevelText.text = "Level " + LevelVal.ToString();

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if left CTRL and Z was pressed
        if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.Z))
        {
            ResetHighScore();
        }

            CountDownTime -= Time.deltaTime;
            CountDownText.text = CountDownTime.ToString();

        if (CountDownTime <= 0)
        {
            LevelGenerator.SetActive(true);
            Player.SetActive(true);
            CountDown.SetActive(false);
            CountDownTime = 3;
        }

        //Heigh Score
        if (int.Parse(Player.transform.position.y.ToString("000")) >= HighScoreVal)
        {
            UpdateHighScore();
        }

        //Score
        if (int.Parse(Player.transform.position.y.ToString("000")) >= ScoreVal)
        {
            UpdateScore();
        }

        //Level Up
        if (int.Parse(Player.transform.position.y.ToString("000")) >= NextLevel)
        {
            LevelUp();
        }

        if (Player.transform.position.y >= NextLevel)
        {
            //Call LevelUp In LevelManager MonoBehaviour
            LevelUp();
        }
    }

    public void UpdateHighScore()
    {
        HighScoreVal = int.Parse(Player.transform.position.y.ToString("000"));
        HighScore.text = "High Score " + HighScoreVal.ToString("000");

        //Saved High Score
        PlayerPrefs.SetInt("High Score ", HighScoreVal);
    }

    public void ResetHighScore()
    {
        //Reset High Score
        HighScoreVal = int.Parse("000");
        HighScore.text = "High Score 000";
        PlayerPrefs.SetInt("High Score ", HighScoreVal);

        //Reset Level
        LevelVal = int.Parse("1");
        LevelText.text = "Level " + LevelVal.ToString("1");
        PlayerPrefs.SetInt("Level ", LevelVal);
    }

    public void UpdateScore()
    {
        ScoreVal = int.Parse(Player.transform.position.y.ToString("000"));
        Score.text = "Score " + ScoreVal.ToString("000");
    }

    public void LevelUp()
    {
        //Increase Level by 1
        LevelVal++;
        LevelText.text = "Level " + LevelVal.ToString();

        //Set Next Level
        NextLevel = NextLevel + 200;

        //Play the LevelUp Sound Clip
        AudioSource audio = LevelManager.FindObjectOfType<AudioSource>();
        audio.clip = LevelUpSound;
        audio.Play();

        //Saved Level
        PlayerPrefs.SetInt("Level ", LevelVal);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Main");
    }

    public void PlayerDied()
    {
        //Remove Player
        Player.SetActive(false);

        //ReSet Level
        PlayerPrefs.SetInt("NextLevel ", NextLevel);

        //Load Main Scene
        SceneManager.LoadScene("Main");
    }
}
