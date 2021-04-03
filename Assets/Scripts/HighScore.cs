using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
public class HighScore : MonoBehaviour

{
    public static float highScore = 0f;

    private Text _highScore;
    // Start is called before the first frame update
    void Start()
    {
        _highScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _highScore.text = "Your Highscore: " + highScore;
    }
}
