using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    // public so other scripts can change its value (coin hit player and costs of paceinfluencing)
    public static int scoreCounter = 0;

    // meshpro variable for crisp text
    private TextMeshProUGUI _score;
    
    void Start()
    {
        // basic textmeshpro initialisation
        _score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // displays amount of coins as text
        _score.text = scoreCounter+ " Coins";
    }
}
