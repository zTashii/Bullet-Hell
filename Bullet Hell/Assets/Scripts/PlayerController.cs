using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int health;
    public float moveSpeed;
    public Rigidbody2D myRigidbody2D;


    public void Awake()
    {
        this.myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        Move();
    }


    public void Move()
    {
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");

        this.myRigidbody2D.velocity = new Vector2(hMove * this.moveSpeed, vMove * this.moveSpeed);
    }

    public void Damage()
    {
        health--;
        if(health <= 0)
        {
            //dead
            this.gameObject.SetActive(false);
        }
    }


}
