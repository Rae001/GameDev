using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    void Start()
    {
       
    }

    public void StartButton()
    {
        SceneManager.LoadScene("StageScene");
    }


    public void BackButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void NextButton()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Level1Button()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void Level2Button()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void Level3Button()
    {
        SceneManager.LoadScene("Level_3");
    }
    public void Level4Button()
    {
        SceneManager.LoadScene("Level_4");
    }
}
