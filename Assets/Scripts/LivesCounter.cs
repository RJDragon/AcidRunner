using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesCounter : MonoBehaviour
{
    public static int livesCounter = 3;
    

    //private Text _lives;

    private TextMeshProUGUI _lives;
    // Start is called before the first frame update
    void Start()
    {
        _lives = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _lives.text = "Health: " + livesCounter;
    }
}
