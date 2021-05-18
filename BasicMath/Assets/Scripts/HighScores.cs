using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{

    public Text[] scores = new Text[10];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            if (PlayerPrefs.GetInt(i + ".Score") != -1)
            {
                scores[i - 1].text = i + " - " + PlayerPrefs.GetInt(i + ".Score").ToString();
            }
            else
                break;
        }
    }

}
