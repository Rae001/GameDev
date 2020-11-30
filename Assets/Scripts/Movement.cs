using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    public GameObject Player;
    private int loopCount = 1;
    private float move_speed = 5.0f;
    private Vector3 pos;
    public Material mat;
    public bool onGround = true;
    public float distFromGround = 0.6f;
    public static bool isAlive = true;
    public GameObject StartText;
    public GameObject RestartText;
    public GameObject RestartButton;
    public GameObject PauseMenu;
    public static bool Started = false;
    public GameObject music; // 음악
    public AudioSource music2; // 음악
    [SerializeField] private AudioClip[] bgm;

    public static bool isPaused = false;
    //public static bool isResume = false;
    public static bool isUIChange = false;
    public static bool isDestroy = false;
    
    
    void Start()
    {
        move_speed = 5.0f;
        loopCount = 1;
        onGround = true;
        distFromGround = 0.6f;
        isAlive = true;
        Started = false;
        isPaused = false;
        music.gameObject.SetActive(false); //음악  isMusicSet = false

        if(UIManager.isTutorial == true)
        {
            music2.clip = bgm[0];
        }

        if(UIManager.isStage == true && UIManager.isStage_1 == true)
        {
            music2.clip = bgm[1];
        }
        if (UIManager.isStage == true && UIManager.isStage_2 == true)
        {
            music2.clip = bgm[2];
        }
        if (UIManager.isStage == true && UIManager.isStage_3 == true)
        {
            music2.clip = bgm[3];
        }
        if (UIManager.isStage == true && UIManager.isStage_4 == true)
        {
            music2.clip = bgm[4];
        }
    }

    
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) //첫 터치시 Start텍스트가 비활성화 되고 게임과 음악이 활성화됨
        {
            StartText.gameObject.SetActive(false);
            Started = true;
            music.gameObject.SetActive(true); // 음악 isMusicSet = true
        }
        if (isAlive == true && Started == true)
        {
            if(isPaused == false)
            {
                onGround = isGrounded();
                Player.transform.Translate(Vector3.forward * move_speed * Time.deltaTime);
                pos = Player.transform.position; //Player 포지션 설정

                if (onGround == true)
                {
                    GameObject Player2 = GameObject.CreatePrimitive(PrimitiveType.Cube); //PlayerClone 오브젝트 생성
                    Player2.transform.position = pos; //PlayerClone 포지션 설정
                    Player2.GetComponent<MeshRenderer>().material = mat; //PlayerClone 색 설정
                    Player2.GetComponent<BoxCollider>().isTrigger = true; // Player와 Clone이 충돌하지 않도록 함


                    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) // 클릭시 회전
                    {
                        if (loopCount % 2 != 0)
                        {
                            Player.transform.eulerAngles = new Vector3(0, 0, 0);
                            loopCount++;
                        }
                        else
                        {
                            Player.transform.eulerAngles = new Vector3(0, -90, 0);
                            loopCount++;
                        }
                    }
                }
            }
            
        }
    }

    public bool isGrounded() //Player가 밑으로 쏘는 레이저에 바닥이 맞으면 isGround 리턴
    {
        return Physics.Raycast(Player.transform.position, Vector3.down, distFromGround);
    }

    private void OnCollisionEnter(Collision collision) // 장애물과의 충돌여부 
    {
        if(collision.gameObject.tag == "obstacle") // Player가 벽에 부딪히면 모든행동과 음악이 멈추고 재시작버튼이 활성화됨
        {
            isAlive = false;
            Started = false;
            music2.Pause(); // isMusicStop = true
            RestartText.gameObject.SetActive(true);
            RestartButton.gameObject.SetActive(true);
           
        }
    }

    public void Restart() // Restart 버튼을 누르면 게임화면 초기화
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UIManager.isVideoplay = false;
    }

    public void Pause()
    {
        
        isPaused = true;
        PauseMenu.gameObject.SetActive(true);
        music2.Pause(); // 음악 isMusicStop = true
    }

    public void Resume()
    {
        
        isPaused = false;
        //isResume = true;
        PauseMenu.gameObject.SetActive(false);
        music2.Play(); // 음악 isMusicStart = true

        if (isAlive == false && Started == false)
        {
         music2.Pause(); // 음악 isMusicStop = true
        }
    }

    public void StageBackButton() // Player에 옮기기
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("인게임에서 Select화면으로 전환");
        isUIChange = true;
        isDestroy = true;
    }

    public void TutorialBackButton() // Player에 옮기기
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("튜토리얼에서 Main화면으로 전환");
        isDestroy = true;
    }

    public void NextButton() // Player에 옮기기
    {
        SceneManager.LoadScene("StageScene");
        isDestroy = true;
    }

}

