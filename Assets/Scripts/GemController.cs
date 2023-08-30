using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    private IEnumerator coroutine;
    private float turnSpeed = 500.0f;
    PlayerController playerController;
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        coroutine = GemTtlRoutine(8.0f);
        StartCoroutine(coroutine);
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed);
    }

    IEnumerator GemTtlRoutine(float ttl) {
        yield return new WaitForSeconds(ttl);
        //Debug.Log("time is up");
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("ball")) {
            BallController ballController = other.collider.gameObject.GetComponent<BallController>();
            Debug.Log($"bump into gem  {ballController.hasBounced}");

            if (!ballController.hasBounced) {
                playerController.score += value;
                Destroy(gameObject);
            }
        }
    }
}
