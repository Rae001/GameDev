using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_screen : MonoBehaviour
{
    public GameObject Endscreen;
    public GameObject TutorialEndscreen;
    public static bool isClear = false;
    public int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && UIManager.isStage == true) // 일반 스테이지
        {
            Endscreen.gameObject.SetActive(true);
            Movement.Started = false;
            Movement.isAlive = false;
            isClear = true;

            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }

        if (other.gameObject.tag == "Player" && UIManager.isTutorial == true) // 튜토리얼 스테이지
        {
            TutorialEndscreen.gameObject.SetActive(true);
            Movement.Started = false;
            Movement.isAlive = false;
            isClear = true;
        }
    }

}
