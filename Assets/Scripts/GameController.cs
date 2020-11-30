using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    /*public static bool isGo = false;
    public static bool isStop = false;

    private float countdown = 3;
    public Text time;*/
    public VideoPlayer video;
    public GameObject videoscreen;
    public Button skipButton;

    public GameObject[] CarPrefab;
    public Text start_text;
    public List<GameObject> Stage = new List<GameObject>();



    void Start()
    {
        /*isGo = true;
        isStop = false;*/
        videoscreen.gameObject.SetActive(false);
        

        GameObject player = GameObject.FindWithTag("Player");
        if (player)
        {
            int carIndex = PlayerPrefs.GetInt("CurrentCar");
            GameObject car = Instantiate(CarPrefab[carIndex]);
            car.transform.SetParent(player.transform);
            car.transform.localPosition = new Vector3(0, 0, 0);

        }

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
                });
            }
             
            start_text.text = "리듬에 맞춰 터치하세요";
            Instantiate(Stage[0]);
        }
        if(UIManager.isStage == true)
        {
            
            start_text.text = "Start";

            if (UIManager.isStage_1 == true)
            {
                
                Instantiate(Stage[1]);
            }
            if (UIManager.isStage_2 == true)
            {
                Instantiate(Stage[2]);
            }
            if (UIManager.isStage_3 == true)
            {
                Instantiate(Stage[3]);
            }
            if (UIManager.isStage_4 == true)
            {
                Instantiate(Stage[4]);
            }
        }
    }

    void Update()
    {
        /*if(Movement.isResume == true)
        {
            time.text = countdown.ToString("0");
            if (countdown > 1)
            {
                isGo = false;
                isStop = true;
                countdown -= Time.deltaTime;
                time.gameObject.SetActive(true);
            }
            else // countdown이 0이 될 때
            {
                isGo = true;
                isStop = false;
                Movement.isResume = false;
                time.gameObject.SetActive(false);
            }
        }*/
    }
}
