using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public Ball theBall;
    public float speed = 30f;
    public float lerpTweek = 2f;//lerping makes mvmnt smoother
    private new Rigidbody2D rigidbody;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        //check if ball y pos is less than or greater than paddle position
        //tell AI paddle to move in relation to ball
        if (theBall.transform.position.y > transform.position.y)
        {
            Vector2 dir = new Vector2(0,1).normalized;
            rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, dir * speed, lerpTweek * Time.deltaTime);
        }
        else if (theBall.transform.position.y < transform.position.y)
        {
            Vector2 dir = new Vector2(0, -1).normalized;
            rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, dir * speed, lerpTweek * Time.deltaTime);
        }
        else
        {
            Vector2 dir = new Vector2(0, 0).normalized;
            rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, dir * speed, lerpTweek * Time.deltaTime);
        }
    }
   
}
