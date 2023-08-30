using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    PlayerController playerController;
    AudioSource playerAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        playerAudioSource = player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("ball")) {
            //Debug.Log($"bump into player collision");
            BallController ballController = other.collider.gameObject.GetComponent<BallController>();
            if (ballController.hasBounced) {
                playerController.health -= 10;
                playerController.ballCnt -= 1;
                Destroy(other.collider.gameObject);
                //playerAudioSource.PlayOneShot(playerController.hurtSound, 1.0f);
            }
        }
    }
}
