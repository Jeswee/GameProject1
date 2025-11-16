using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;

    //Keeps Track of Score & Highscore & uodates/ saves accordignly :)
    public int score;
    public int highscore;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI GameOverScoreText;
    [SerializeField] TextMeshProUGUI PauseMenuScoreText;
    [SerializeField] TextMeshProUGUI HighscoreText;
    [SerializeField] TextMeshProUGUI GameOverHighscoreText;
    [SerializeField] TextMeshProUGUI PauseMenuHighscoreText;

    void Start()
    {
        instance = this;
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        HighscoreText.text = highscore.ToString();
        score = 0;
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        //Debug.Log(score + "...." + highscore);
    }

    public void UpdateScore()
    {
        if(Mathf.FloorToInt(PlayerController.instance.transform.position.y) > score)
        {
            score = Mathf.FloorToInt(PlayerController.instance.transform.position.y);
            scoreText.text = score.ToString();
        }
        

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
            HighscoreText.text = highscore.ToString();
        }

        GameOverHighscoreText.text = highscore.ToString();
        PauseMenuHighscoreText.text = highscore.ToString();
        GameOverScoreText.text = score.ToString();
        PauseMenuScoreText.text = score.ToString();

        Debug.Log(PlayerPrefs.GetInt("Highscore"));
    }

}
