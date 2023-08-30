using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] gemPrefabs;
    private GameObject player;
    float xRange = 45.0f;
    float zRange = 100.0f;
    float startDelay = 2f;
    float spawnInterval = 3.0f;
    public AudioClip gemSound;
    private AudioSource audioSource;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomGem", startDelay, spawnInterval);
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomGem() {
        if (playerController.health <= 0) {
            return;
        }
        int index = Random.Range(0, gemPrefabs.Length);
        Vector3 pos;
        while (true) {
            pos = new Vector3(Random.Range(-xRange, xRange), 5, Random.Range(-zRange, zRange));
            float dis = Vector3.Distance(pos, player.transform.position);
            if (Mathf.Abs(dis)> 20) {
                break;
            }
        }

        Instantiate(gemPrefabs[index], pos, gemPrefabs[index].transform.rotation);
        audioSource.PlayOneShot(gemSound, 1.0f);
    }
}
