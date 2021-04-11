using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Status : MonoBehaviour
{

    private TextMeshProUGUI _status;
    // Start is called before the first frame update
    void Start()
    {
        _status = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player>().startCrazy && GameObject.Find("Player").GetComponent<Player>().startImmune)
        {
            _status.text = "CRAZY and immune!";
        }
        else if (GameObject.Find("Player").GetComponent<Player>().startCrazy)
        {
            _status.text = "      CRAZY";
        }
        else if (GameObject.Find("Player").GetComponent<Player>().startImmune)
        {
            _status.text = "      immune!";
        }
        else
        {
            _status.text = " ";
        }
    }
}
