using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public static int scoreCounter = 0;

    private Text _score;
    // Start is called before the first frame update
    void Start()
    {
        _score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _score.text = scoreCounter+ " Coins";
    }
}
