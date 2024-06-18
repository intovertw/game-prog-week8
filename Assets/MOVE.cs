using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float baseMoveSpeed, moveSpeed, rotSpeed, jumpVel;
    public Rigidbody rb;
    public bool grounded;
    public int score;

    void Start()
    {
        baseMoveSpeed = 10;
        baseMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = (Input.GetAxis("Horizontal") * rotSpeed) * Time.deltaTime, 
            translation = (Input.GetAxis("Vertical") * moveSpeed) * Time.deltaTime;

        transform.Translate(rotation,0,translation);
        //transform.Rotate(0,rotation,0);

        if (grounded == true)
        {
            if (Input.GetButton("Jump"))
            {
                rb.AddForce(new Vector3(0, jumpVel, 0), ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
