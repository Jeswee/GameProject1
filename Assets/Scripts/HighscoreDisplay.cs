using System;
using TMPro;
using UnityEngine;

public class HighscoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HighscoreText;
    
    void Start()
    {
        int highscore = PlayerPrefs.GetInt("Highscore");
        HighscoreText.text = highscore.ToString();
    }

}