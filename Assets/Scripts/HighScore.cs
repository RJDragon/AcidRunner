using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
    
public class HighScore : MonoBehaviour

{
    // public variable for the highscore
    public static float highScore = 0f;

    // textmeshpro variable
    private TextMeshProUGUI _highScore;
   
    void Start()
    {
        _highScore = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        // displays the highscore as a string and the value; format checks amount of digits
        _highScore.text = "Highscore: " + highScore.ToString("F1") + " m";
    }
}
