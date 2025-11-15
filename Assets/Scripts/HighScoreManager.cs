using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static int score;
    public static int highscore;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI HighscoreText;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore");
        score = 0;
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        //Debug.Log(score + "...." + highscore);
    }

    void UpdateScore()
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
        }
    }

}
