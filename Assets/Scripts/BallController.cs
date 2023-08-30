using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed;
    private Rigidbody ballRb;
    private GameObject player;
    private PlayerController playerController;
    private bool applyForce;
    private Vector3 startPos;
    public bool hasBounced;
    float xRange = 60.0f;
    float zRange = 130.0f;
    float yRange = 30.0f;
    // Start is called before the first frame update

    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        speed = 200;
        applyForce = true;
        playerController = GetComponent<PlayerController>();
        hasBounced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (applyForce) {
            ballRb.AddForce(player.transform.rotation * Vector3.left * speed, ForceMode.Impulse);
            startPos = transform.position;
            applyForce = false;
        }
        if (transform.position.x >= xRange || transform.position.x <= -xRange) {
            Debug.Log($"out of x bound {transform.position}");
            Destroy(gameObject);
        } else if (transform.position.y >= yRange || transform.position.y <= 0) {
            Debug.Log($"out of y bound {transform.position}");
            Destroy(gameObject);
        } else if (transform.position.z >= zRange || transform.position.z <= -zRange) {
            Debug.Log($"out of z bound {transform.position}");
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("wall1")) {
            //Debug.Log("hit wall  1");
            hasBounced = true;
        } else if (other.collider.CompareTag("wall2")) {
            //bounceBackFromWall(Vector3.forward);
            //startPos = transform.position;
            //Debug.Log($"hit wall 2");
            hasBounced = true;
        } else if (other.collider.CompareTag("wall3")) {
            //Debug.Log("hit wall  3");
            hasBounced = true;
        } else if (other.collider.CompareTag("wall4")) {
            //Debug.Log("hit wall  4");
            hasBounced = true;
        } else if (other.collider.CompareTag("ball")) {
            Debug.Log($"hit another ball {transform.position} {other.collider.gameObject.transform.position}");
            hasBounced = true;
        }

    }
}
 