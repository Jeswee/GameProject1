using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static int score;
    public static int highscore;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0);     //default = 0
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.FloorToInt(PlayerController.instance.transform.position.y) > score)
        {
            score = Mathf.FloorToInt(PlayerController.instance.transform.position.y);
        }
        

        if (score > highscore)
        {
            highscore = score;
        }
        Debug.Log(score + "...." + highscore);
    }
}
