using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
    
public class HighScore : MonoBehaviour

{
    public static float highScore = 0f;

    //private Text _highScore;

    private TextMeshProUGUI _highScore;
    // Start is called before the first frame update
    void Start()
    {
        _highScore = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _highScore.text = "Highscore: " + highScore.ToString("F1") + " m";
    }
}
