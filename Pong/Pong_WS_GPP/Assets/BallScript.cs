using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int delay;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
        delay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= 1;
    }

    void GoBall()
    {
        float randX = Random.Range(-1, 1);
        float randY = Random.Range(-1, 1);
        
        rb2d.AddForce(new Vector2(500 * Mathf.Sign(randX), -75 * Mathf.Sign(randY)));
      
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (delay <= 0)
        {
            if (collision.collider.CompareTag("Player"))
            {
                Vector2 vel;
                vel.x = -rb2d.velocity.x;
                vel.y = (rb2d.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 2);
                rb2d.velocity = vel;
                delay = 100;
            }
        }

    }

}
