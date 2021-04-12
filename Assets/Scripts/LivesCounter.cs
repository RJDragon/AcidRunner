using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesCounter : MonoBehaviour
{
    //counting for the health
    public static int livesCounter = 3;
    
    // textmeshpro variable
    private TextMeshProUGUI _lives;
    // Start is called before the first frame update
    void Start()
    {
        _lives = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        //displays health as string and the value
        _lives.text = "Health: " + livesCounter;
    }
}
