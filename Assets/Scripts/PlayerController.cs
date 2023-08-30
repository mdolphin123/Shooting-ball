using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 15000000.0f;
    public float turnSpeed = 6000000000.0f;
    public float horizontalInput;
    public float forwardInput;
    public float xRange = 100.0f;
    public float zRange = 100.0f;
    public GameObject ballPrefab;
    public int ballCnt;
    public int health;
    public Slider healthSlider;
    public AudioClip shootSound;
    public AudioClip hurtSound;
    private AudioSource playerAudio;
    private bool gameOver;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
      transform.Translate(0, 5, 0);
      health = 100;
      ballCnt = 0;
      playerAudio = GetComponent<AudioSource>();
      gameOver = false;
      score = 0;
      scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        if (health <= 0) {
          gameOver = true;
          gameOverText.gameObject.SetActive(true);

        }
        if (gameOver) {
          return;
        }
        scoreText.text = "Score: " + score;
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");


        if (transform.position.x < -xRange) 
        {
          transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange) 
        {
          transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        if(transform.position.z < -zRange) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if(transform.position.z > zRange) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        
        if (Input.GetKey(KeyCode.Z)) {
          transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed);
        } else if (Input.GetKey(KeyCode.X)) {
          transform.Rotate(Vector3.down, Time.deltaTime * turnSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
          Vector3 offset = new Vector3(-10.0f, -5.0f, 0f);
          Instantiate(ballPrefab, transform.position + transform.rotation * offset, transform.rotation);
          ballCnt += 1;
          //playerAudio.PlayOneShot(shootSound, 1.0f);
        }

        
        //Debug.Log($"x = {transform.position.x}, y = {transform.position.y} z = {transform.position.z} h = {horizontalInput} v= {forwardInput}");
        float zPos = transform.position.z + -1 * Time.deltaTime * speed * horizontalInput;
        float yPos = transform.position.y;
        float xPos = transform.position.x + Time.deltaTime * speed * forwardInput;
        transform.position = new Vector3(xPos, yPos, zPos);
        
    }

}
