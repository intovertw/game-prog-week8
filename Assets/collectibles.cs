using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class collectibles : MonoBehaviour
{
    public bool isCoins, isSpeedUp;
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(isCoins && isSpeedUp)
            {
                playerScript script = other.GetComponent<playerScript>();
                StartCoroutine(speedUpTimer());
                script.score++;
                Destroy(gameObject);
            }
        }
    }
    IEnumerator speedUpTimer()
    {
        playerScript script = this.GetComponent<playerScript>();
        script.moveSpeed *= 5f;
        script.rotSpeed *= 5f;
        yield return new WaitForSeconds(5);
    }
}
