using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    public static int livesCounter = 3;
    

    private Text _lives;
    // Start is called before the first frame update
    void Start()
    {
        _lives = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _lives.text = "Lives: " + livesCounter;
    }
}
