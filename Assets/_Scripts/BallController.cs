﻿using UnityEngine;

public class BallController : MonoBehaviour
{
    private PaddleController paddle;
    private Vector3 paddleToBallVector;
    bool gameStarted = false;
    private AudioSource boing;
	// Use this for initialization
	void Start ()
    {
        paddle = FindObjectOfType<PaddleController>();
        boing = FindObjectOfType<AudioSource>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!gameStarted)
        {
            transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse Clicked, launching ball");
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                gameStarted = true;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals("Breakable"))
        {
            boing.Play();
        }
    }
}
