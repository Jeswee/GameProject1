using System;
using TMPro;
using UnityEngine;

public class HighscoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HighscoreText;
    
    void Start()
    {
        int highscore = PlayerPrefs.GetInt("HighScore");
        HighscoreText.text = highscore.ToString();
    }

}
