using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_screen : MonoBehaviour
{
    public GameObject Endscreen;
    public GameObject TutorialEndscreen;
    public static bool isClear = false;
    public static bool isTrigger = false;
    public static bool isCameraOff = false;
    public int nextSceneLoad;

    void Start()
    {
        if(UIManager.isStage == true && UIManager.isStage_1 == true)
        {
            nextSceneLoad = 3;
        }

        if (UIManager.isStage == true && UIManager.isStage_2 == true)
        {
            nextSceneLoad = 4;
        }

        if (UIManager.isStage == true && UIManager.isStage_3 == true)
        {
            nextSceneLoad = 5;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && UIManager.isStage == true) // 일반 스테이지
        {
            Invoke("End", 3.5f);
            //Endscreen.gameObject.SetActive(true);
            Movement.Started = false;
            Movement.isAlive = false;
            isClear = true;
            isTrigger = true;
            isCameraOff = true;

            nextSceneLoad += 1;

            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }

        if (other.gameObject.tag == "Player" && UIManager.isTutorial == true) // 튜토리얼 스테이지
        {
            Invoke("TutorialEnd", 3.5f);
            //TutorialEndscreen.gameObject.SetActive(true);
            Movement.Started = false;
            Movement.isAlive = false;
            isClear = true;
        }
    }
     public void End()
     {
        Endscreen.gameObject.SetActive(true);
     }

    public void TutorialEnd()
    {
        TutorialEndscreen.gameObject.SetActive(true);
    }
}
