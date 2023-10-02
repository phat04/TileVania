using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    Rigidbody2D myRigidbody2D;
    PlayerMovementScript playerMovementScript;
    float xSpeed;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        playerMovementScript = FindObjectOfType<PlayerMovementScript>();
        xSpeed = playerMovementScript.transform.localScale.x * bulletSpeed;
    }

    
    void Update()
    {
        myRigidbody2D.velocity = new Vector2(xSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
