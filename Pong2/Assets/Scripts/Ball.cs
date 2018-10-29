using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 30f;

    private new Rigidbody2D rigidbody;

    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.right * speed;
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        //leftPaddl or RightPaddle
        if ((col.gameObject.name == "PaddleLeft") || (col.gameObject.name == "PaddleRight"))
        {
            HandlePaddleHit(col);
        }
        //Wall Bottom or wall Top
        if ((col.gameObject.name == "WallBottom") || (col.gameObject.name == "WallTop"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallBloop);
        }
        //leftGoal or rtGoal
        if ((col.gameObject.name == "LeftGoal") || (col.gameObject.name == "RightGoal"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);
            //TODO update Score UI
            if (col.gameObject.name == "LeftGoal")
            {
                IncreaseTextUIScore("RightScoreUI");
            }
            if (col.gameObject.name == "RightGoal")
            {
                IncreaseTextUIScore("LeftScoreUI");
            } 
            transform.position = new Vector2(0, 0);
        }
    }

    private void HandlePaddleHit(Collision2D col)
    {
        float y = BallHitPaddleWhere(transform.position, col.transform.position,
            col.collider.bounds.size.y);//transform.position assumes your referencing 'this'
        //col.collider.bounds.size.y gets the height of an obj x would get width
        Vector2 dir = new Vector2();
        if (col.gameObject.name == "PaddleLeft")
        {
            dir = new Vector2(1, y).normalized;
        }
        if (col.gameObject.name == "PaddleRight")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidbody.velocity = dir * speed;

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitPaddleBloop);
    }
    //sees where ball hits paddle 
    private float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
    void IncreaseTextUIScore(string textUIName)
    {
        var textUIComp = GameObject.Find(textUIName).GetComponent<Text>();
        int score = int.Parse(textUIComp.text);
        score++;
        textUIComp.text = score.ToString();
    }
}
