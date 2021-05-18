using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSpawn : MonoBehaviour
{
    GameManager manager;
    public int correct = 0;
    private int result = 0;
    private int fakeResult = 0;
    public Button buttonA;
    public Button buttonB;
    public Text question;
    private int totalScore = 0;
    public Text score;

    int type = 0;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    public void questionGenerate()
    {
        type = Random.Range(0, 3);
        string q = "";
        if (type == 0)
            q = sumQuestion();
        else if (type == 1)
            q = subQuestion();
        else
            q = mulQuestion();

        question.text = q;
        correct = Random.Range(0, 2);
        if (correct == 0)
        {
            buttonA.GetComponentInChildren<Text>().text = result.ToString();
            buttonB.GetComponentInChildren<Text>().text = fakeResult.ToString();
        }
        else
        {
            buttonB.GetComponentInChildren<Text>().text = result.ToString();
            buttonA.GetComponentInChildren<Text>().text = fakeResult.ToString();
        }

    }

    string sumQuestion()
    {
        int left = Random.Range(1, 100);
        int right = Random.Range(1, 100);
        string s = string.Format("{0} + {1} = ?", left, right);
        result = left + right;
        int addition = Random.Range(-10, 10);
        if (addition == 0)
            addition = 10;
        fakeResult = result + addition;
        return s;
    }

    string mulQuestion()
    {
        int left = Random.Range(10, 100);
        int right = Random.Range(1, 10);
        string s = string.Format("{0} x {1} = ?", left, right);
        result = left * right;
        int addition = (result * Random.Range(1, 10)) / 100;
        if (addition == 0)
            fakeResult = result + right;
        else
            fakeResult = result + addition;
        return s;
    }
    string subQuestion()
    {
        int left = Random.Range(1, 100);
        int right = Random.Range(1, 100);
        if (left < right)
        {
            int dumdum = left;
            left = right;
            right = dumdum;
        }
        string s = string.Format("{0} - {1} = ?", left, right);
        result = left - right;
        int addition = Random.Range(-10, 10);
        if (addition == 0)
            addition = -5;
        fakeResult = result + addition;
        return s;
    }

    public void checkAnswerA()
    {
        if (correct == 0)
        {
            totalScore = totalScore + 6 + type;
            score.text = totalScore.ToString();
            manager.increaseTime(true);
        }
        else
        {
            manager.increaseTime(false);
        }


    }

    public void checkAnswerB()
    {
        if (correct == 1)
        {
            totalScore = totalScore + 6 + type;
            score.text = totalScore.ToString();
            manager.increaseTime(true);
        }
        else
        {
            manager.increaseTime(false);
        }
    }
}
