using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool isJump = false;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isJump == true)
        {
            rb.AddForce(Vector3.up + new Vector3(0, 250, 0));
            isJump = false;
        }
    }

    private void OnTriggerEnter(Collider other) // Jumper에 Player가 충돌하면 점프
    {
        if (other.gameObject.tag == "Player")
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            isJump = true;
        }
    }
}
