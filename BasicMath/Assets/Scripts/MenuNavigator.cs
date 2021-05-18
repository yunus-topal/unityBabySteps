using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuNavigator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            if (!PlayerPrefs.HasKey(i + ".Score"))
            {
                PlayerPrefs.SetString(i + ".Person", "");
                PlayerPrefs.SetInt(i + ".Score", -1);
            }
        }
    }

    public void toGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void toBoard()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void resetBoard()
    {
        for (int i = 1; i <= 10; i++)
        {
            PlayerPrefs.SetInt(i + ".Score", -1);

        }
    }
    public void toMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
