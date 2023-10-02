using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D myRgidbody2;
    void Start()
    {
        myRgidbody2 = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        myRgidbody2.velocity = new Vector2(moveSpeed, myRgidbody2.velocity.y);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipSprite();
    }

    void FlipSprite()
    {
        transform.localScale = new Vector2(-Mathf.Sign(myRgidbody2.velocity.x), 1f);     
    }
}
