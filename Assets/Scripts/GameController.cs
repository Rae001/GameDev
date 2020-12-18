using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    
    public static bool isTutorialNext = false;
    public static bool isStageNext = false;

    public VideoPlayer video;

    public GameObject videoscreen;
    public GameObject Endscreen;
    public GameObject TutorialEndscreen;
    public GameObject EndTrigger;

    public Button skipButton;
    public Button stageNextButton;
    public Button tutorialNextButton;
    
    public GameObject[] CarPrefab;
    public Text start_text;
    public List<GameObject> Stage = new List<GameObject>();



    void Start()
    {
        if (UIManager.isStage_1 == true)
        {
            EndTrigger.transform.position = new Vector3(-346.83f, 1.44f, 489.81f);
        }
        if (UIManager.isStage_2 == true)
        {
            EndTrigger.transform.position = new Vector3(-352.8f, 1.44f, 371.7f);
        }
        if (UIManager.isStage_3 == true)
        {
            EndTrigger.transform.position = new Vector3(-402.83f, 1.44f, 412.59f);
        }
        if (UIManager.isStage_4 == true)
        {
            EndTrigger.transform.position = new Vector3(-422.5771f, 3.160274f, 421.24f);
        }



        GameObject player = GameObject.FindWithTag("Player");
        if (player)
        {
            int carIndex = PlayerPrefs.GetInt("CurrentCar");
            GameObject car = Instantiate(CarPrefab[carIndex]);
            car.transform.SetParent(player.transform);
            car.transform.localPosition = new Vector3(0, 0, 0);
        }

        stageNextButton.onClick.AddListener(() => // 클리어하고 스테이지화면으로 돌아감
        { 
            SceneManager.LoadScene("MainScene");
            Debug.Log("stagenext");
            isStageNext = true;
            End_screen.isTrigger = false;
            End_screen.isCameraOff = false;
        });

        tutorialNextButton.onClick.AddListener(() => // 클리어하고 메인화면으로 돌아감
        {         
            SceneManager.LoadScene("MainScene");
            Debug.Log("tutorialnext");
            isTutorialNext = true;
            End_screen.isTrigger = false;
            End_screen.isCameraOff = false;
        });


        if (UIManager.isTutorial == true)
        {
            if(UIManager.isVideoplay == true)
            {
                videoscreen.gameObject.SetActive(true);
                video.Play();

                skipButton.onClick.AddListener(() =>
                {
                    videoscreen.gameObject.SetActive(false);
                    video.Stop();

                    //SceneManager.LoadScene("MainScene");
                });
            }
             
            start_text.text = "리듬에 맞춰 터치하세요";
            Stage[0].gameObject.SetActive(true);
            Stage[1].gameObject.SetActive(false);
            Stage[2].gameObject.SetActive(false);
            Stage[3].gameObject.SetActive(false);
            Stage[4].gameObject.SetActive(false);
            
        }
        if(UIManager.isStage == true)
        {
            
            start_text.text = "Start";

            if (UIManager.isStage_1 == true)
            {
                
                Stage[0].gameObject.SetActive(false);
                Stage[1].gameObject.SetActive(true);
                Stage[2].gameObject.SetActive(false);
                Stage[3].gameObject.SetActive(false);
                Stage[4].gameObject.SetActive(false);
            }
            if (UIManager.isStage_2 == true)
            {
                Stage[0].gameObject.SetActive(false);
                Stage[1].gameObject.SetActive(false);
                Stage[2].gameObject.SetActive(true);
                Stage[3].gameObject.SetActive(false);
                Stage[4].gameObject.SetActive(false);
            }
            if (UIManager.isStage_3 == true)
            {
                Stage[0].gameObject.SetActive(false);
                Stage[1].gameObject.SetActive(false);
                Stage[2].gameObject.SetActive(false);
                Stage[3].gameObject.SetActive(true);
                Stage[4].gameObject.SetActive(false);
            }
            if (UIManager.isStage_4 == true)
            {
                Stage[0].gameObject.SetActive(false);
                Stage[1].gameObject.SetActive(false);
                Stage[2].gameObject.SetActive(false);
                Stage[3].gameObject.SetActive(false);
                Stage[4].gameObject.SetActive(true);
            }
            
            if(Movement.isDestroy == true)
            {
                
            }
        }      
    }   
}
