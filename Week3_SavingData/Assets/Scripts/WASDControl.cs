using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using TMPro;
using UnityEngine.SceneManagement;

public class WASDControl : MonoBehaviour
{
    public static WASDControl Instance;
    
    public Rigidbody2D rb2d;

    public float forceAmt = 1;

    public float maxSpd = 250;

    // public TextMeshProUGUI gameOverText;

    void Awake()
    {
        // singleton
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // rb2d.position = new Vector2(0, 8);
    }

    // Update is called once per frame
    void Update()
    {

        // WASD control
        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(forceAmt * Vector2.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(forceAmt * Vector2.left);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(forceAmt * Vector2.down);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(forceAmt * Vector2.right);
        }
        
        // add a friction on the x-axis
        if (rb2d.velocity.x != 0)
        {
            Vector2 vel = rb2d.velocity;
            vel.x *= .997f;
            rb2d.velocity = vel;
        }
        
        // check if the player falls out of the screen
        if (rb2d.position.y <= -5)
        {
            if (GameManager.Instance.currentLevel == 0 || GameManager.Instance.currentLevel == 1)
            {
                GameManager.Instance.currentLevel = -1;
                // Debug.Log("Game over!");
                GameManager.Instance.score = 0;
                gameObject.SetActive(false);
                SceneManager.LoadScene(3);
            }
        }
    }

    // private void FixedUpdate()
    // {
    //     if(rb2d.velocity.magnitude > maxSpd)
    //     {
    //         rb2d.velocity = rb2d.velocity.normalized * maxSpd;
    //     }
    // }
}
