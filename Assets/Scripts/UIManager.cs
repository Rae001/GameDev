using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static bool isTutorial = false;
    public static bool isStage = false;
    public static bool isStage_1 = false;
    public static bool isStage_2 = false;
    public static bool isStage_3 = false;
    public static bool isStage_4 = false;
    public static bool isVideoplay = false;

    public GameObject MainUI;
    public GameObject SelectUI;
    public GameObject ResetMenu;

    public Button[] lvButtons; // 스테이지 버튼을 리스트로 관리

    public List<Button> ui = new List<Button>();

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 3); // int default값이 3이면 스테이지 1,2는 기본으로 값을 가져온다. 왜냐하면 build setting에 저장된 스테이지 1의 값이 2이기 때문이다.

        for (int i = 0; i < lvButtons.Length; i++) // 0 ~ 4까지 반복문을 실행
        {
            if (i + 2 > levelAt) // levelAt이 3이상이면 버튼클릭을 비활성화  {levelAt의 스테이지가 1이면 스테이지2는 비활성화}
            {
                lvButtons[i].interactable = false;
            }
        }

        ui[0].onClick.AddListener(() => // Select화면으로 전환 (MainUI 비활성화 && SelectUI 활성화)
        {
            SelectUI.gameObject.SetActive(true);
            MainUI.gameObject.SetActive(false);
            Debug.Log("Select화면으로 전환");
        });

        ui[1].onClick.AddListener(() => // Main화면으로 전환 (MainUI 활성화 && SelectUI 비활성화)
        {
            SelectUI.gameObject.SetActive(false);
            MainUI.gameObject.SetActive(true);
            Debug.Log("Main화면으로 전환");
        });

        ui[2].onClick.AddListener(() => // Exit
        {
            Application.Quit();
            Debug.Log("게임종료");
        });

        ui[3].onClick.AddListener(() => // Reset메뉴 활성화
        {
            ResetMenu.gameObject.SetActive(true);
        });

        ui[4].onClick.AddListener(() => //TutorialScene
        {
            isVideoplay = true;
            isTutorial = true;
            isStage = false;
            SceneManager.LoadScene("StageScene");
            Debug.Log("튜토리얼");
        });

        ui[5].onClick.AddListener(() =>
        {
            isTutorial = false;
            isStage = true;
            isStage_1 = true;
            SceneManager.LoadScene("StageScene");
            Debug.Log("1단계");
        });

        ui[6].onClick.AddListener(() =>
        {
            isTutorial = false;
            isStage = true;
            isStage_2 = true;
            SceneManager.LoadScene("StageScene");
            Debug.Log("2단계");
        });

        ui[7].onClick.AddListener(() =>
        {
            isTutorial = false;
            isStage = true;
            isStage_3 = true;
            SceneManager.LoadScene("StageScene");
            Debug.Log("3단계");
        });

        ui[8].onClick.AddListener(() =>
        {
            isTutorial = false;
            isStage = true;
            isStage_4 = true;
            SceneManager.LoadScene("StageScene");
            Debug.Log("4단계");
        });

        ui[9].onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SelectScene");
            Debug.Log("캐릭터창");
        });

        ui[10].onClick.AddListener(() => // 리셋 확인
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("MainScene");
            Debug.Log("Reset하고 Select화면으로 전환");
        });

        ui[11].onClick.AddListener(() => // 리셋취소
        {
            ResetMenu.gameObject.SetActive(false);
        });

        if (Movement.isUIChange == true) // 뒤로가기를 누르면 select화면으로 전환
        {
            SelectUI.gameObject.SetActive(true);
            MainUI.gameObject.SetActive(false);
            Debug.Log("Select화면으로 전환");
        }

        if (CarSelection.isChrChange == true) // 뒤로가기를 누르면 select화면으로 전환
        {
            SelectUI.gameObject.SetActive(true);
            MainUI.gameObject.SetActive(false);
            Debug.Log("Select화면으로 전환");
        }

        if (CarSelection.isBack == true)
        {
            SelectUI.gameObject.SetActive(true);
            MainUI.gameObject.SetActive(false);
            Debug.Log("CharacterSelect 화면에서 Select화면으로 전환");
        }

        if(GameController.isStageNext == true)
        {
            SelectUI.gameObject.SetActive(true);
            MainUI.gameObject.SetActive(false);
            Debug.Log("Select화면으로 전환");
            isStage_1 = false;
            isStage_2 = false;
            isStage_3 = false;
            isStage_4 = false;

        }

        if(GameController.isTutorialNext == true)
        {
            SelectUI.gameObject.SetActive(false);
            MainUI.gameObject.SetActive(true);
            Debug.Log("Main화면으로 전환");
        }

    }

    void Update()
    {
        

    }
}
