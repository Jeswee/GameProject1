using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;

    //Keeps Track of Score & Highscore & uodates/ saves accordignly :)
    public static int score;
    public static int highscore;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI GameOverScoreText;
    [SerializeField] TextMeshProUGUI PauseMenuScoreText;
    [SerializeField] TextMeshProUGUI HighscoreText;
    [SerializeField] TextMeshProUGUI GameOverHighscoreText;
    [SerializeField] TextMeshProUGUI PauseMenuHighscoreText;

    void Start()
    {
        instance = this;
        highscore = PlayerPrefs.GetInt("HighScore");
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
            HighscoreText.text = highscore.ToString();
        }
    }

}
