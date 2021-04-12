using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Status : MonoBehaviour
{

    // textmeshpro variable
    private TextMeshProUGUI _status;
    // Start is called before the first frame update
    void Start()
    {
        _status = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // if crazy and immune, display information on screen
        if (GameObject.Find("Player").GetComponent<Player>().startCrazy && GameObject.Find("Player").GetComponent<Player>().startImmune)
        {
            _status.text = "CRAZY and immune!";
        }
        // if crazy, display information on screen
        else if (GameObject.Find("Player").GetComponent<Player>().startCrazy)
        {
            _status.text = "      CRAZY";
        }
        // if immune, display information on screen
        else if (GameObject.Find("Player").GetComponent<Player>().startImmune)
        {
            _status.text = "      immune!";
        }
        // else display "nothing"
        else
        {
            _status.text = " ";
        }
    }
}
