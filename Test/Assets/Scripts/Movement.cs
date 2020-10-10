using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

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
    public static bool Started = false;
    public GameObject music;
    public AudioSource music2;
    
    
    void Start()
    {
        move_speed = 5.0f;
        loopCount = 1;
        onGround = true;
        distFromGround = 0.6f;
        isAlive = true;
        Started = false;
        music.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //첫 터치시 Start텍스트가 비활성화 되고 게임과 음악이 활성화됨
        {
            StartText.gameObject.SetActive(false);
            Started = true;
            music.gameObject.SetActive(true);
        }
        if (isAlive == true && Started == true)
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


                if (Input.GetMouseButtonDown(0)) // 클릭시 회전
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
            music2.Pause();
            RestartText.gameObject.SetActive(true);
            RestartButton.gameObject.SetActive(true);
            ShowAD();
           
        }
    }

    public void Restart() // Restart 버튼을 누르면 게임화면 초기화
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowAD()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}

