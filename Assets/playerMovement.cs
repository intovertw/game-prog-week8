using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    /*
     * speeds[0] = moveSpeed
     * [1] = rotation speed
     * [2] = jump velocity
     */

    public static float[] baseSpeeds = { 10f, 10f, 2f }, speeds = { 0f, 0f, 0f };
    public Rigidbody rb;
    public bool isGrounded;
    public static bool isCoin = false;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            speeds[i] = baseSpeeds[i];
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = (Input.GetAxis("Vertical") * speeds[0]) * Time.deltaTime,
            rotation = (Input.GetAxis("Horizontal") * speeds[1]) * Time.deltaTime;

        transform.Translate(rotation, 0, translation);

        if (isGrounded == true)
        {
            if (Input.GetButton("Jump"))
            {
                rb.AddForce(new Vector3(0, speeds[2], 0), ForceMode.Impulse);
            }
        }

        if (isCoin == true)
        {
            isCoin = false;
            StartCoroutine(speedUpTimer());
        }
    }

    IEnumerator speedUpTimer()
    {
        speeds[0] += 20;
        speeds[1] += 20;
        speeds[2] += 1;

        Debug.Log("nyoom!");

        yield return new WaitForSeconds(5);

        speeds[0] = baseSpeeds[0];
        speeds[1] = baseSpeeds[1];
        speeds[2] = baseSpeeds[2];

        Debug.Log("unnyoom");

        yield return new WaitForSeconds(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
