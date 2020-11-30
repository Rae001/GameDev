using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    [Range(0.001f, 1f)] //범위 설정
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
        Vector3 newPos = Player.transform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        if (LookAtPlayer)
        {
            transform.LookAt(Player.transform);
        }
    }
}
