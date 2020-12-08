using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    [Range(0.001f, 1f)] //범위 설정
    public float speed = 100f;
    public float smoothFactor = 0.5f;
    public bool LookAtPlayer = false;
    private Vector3 _cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(End_screen.isCameraOff == false)
        {
            Vector3 newPos = Player.transform.position + _cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
            if (LookAtPlayer)
            {
                transform.LookAt(Player.transform);
            }
        }
        

        if(End_screen.isTrigger == true && End_screen.isCameraOff == true)
        {
            Rot();
            Invoke("RotStop", 3.5f);
        }
    }

    public void Rot()
    {
        transform.RotateAround(Player.transform.position, Vector3.down, speed * Time.deltaTime);
    }

    public void RotStop()
    {
        End_screen.isTrigger = false;
    }
}
