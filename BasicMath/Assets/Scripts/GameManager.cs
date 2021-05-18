using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    private float timeLeft = 10f;
    private float reduceConstant = 0.02f;
    public Slider timeSlider;
    public GameObject fill;
    //boolean to know if timer started
    private bool timerStarter = false;
    //initial text
    public Text startText;

    public Text score;
    //buttons
    public Button optionA;
    public Button optionB;

    public Button pauseButton;



    public void startingButton()
    {
        startText.enabled = false;
        optionA.gameObject.SetActive(true);
        optionB.gameObject.SetActive(true);

        timerStarter = true;
    }
    // Update is called once per frame
    //timer needs update every frame.
    private void FixedUpdate()
    {
        if (timerStarter)
        {
            timeLeft -= reduceConstant;
            if (timeLeft <= 0)
            {
                optionA.enabled = false;
                optionB.enabled = false;
                Time.timeScale = 0;
                gameOver();
            }
            else if (timeLeft < 5)
            {

                fill.GetComponent<Image>().color = Color.red;
            }
            else
            {
                // fillArea = timeSlider.transform.Find("Fill Area").gameObject;
                // fill = fillArea.transform.Find("Fill").gameObject;
                Color32 myBlue = new Color32(112, 197, 255, 255);
                fill.GetComponent<Image>().color = myBlue;
                //112 197 255 255
            }
            timeSlider.value = timeLeft / 10;
        }
    }

    public void increaseTime(bool b)
    {
        reduceConstant += 0.002f;
        if (b)
        {
            timeLeft += 3f;
            if (timeLeft > 10)
                timeLeft = 10;
        }
        else
        {
            timeLeft -= 2.5f;
        }
    }
    void gameOver()
    {
        int total = int.Parse(score.text);

        for (int i = 1; i <= 10; i++)
        {
            if (PlayerPrefs.GetInt(i + ".Score") == -1)
            {
                PlayerPrefs.SetInt(i + ".Score", total);
                break;
            }
            else if (PlayerPrefs.GetInt(i + ".Score") < total)
            {
                int changes = PlayerPrefs.GetInt(i + ".Score");
                PlayerPrefs.SetInt(i + ".Score", total);
                total = changes;
                break;
            }
        }


        startText.text = "Game Over";
        startText.GetComponent<Text>().fontSize = 45;
        startText.enabled = true;
    }
}
