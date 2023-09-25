using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public int health;
    public float moveSpeed;
    public Rigidbody2D myRigidbody2D;

    public Transform bulletKing;
    public GameManager gm;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    public bool godMode;

    public void Awake()
    {
        this.myRigidbody2D = GetComponent<Rigidbody2D>();
        //this.gm = gm.GetComponent<GameManager>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
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
        Vector3 vectorToTarget = bulletKing.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 1f);
        
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(transform.position.x, screenBounds.x * - 1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(transform.position.y, screenBounds.y * - 1 + objectHeight, screenBounds.y - objectHeight);

        transform.position = viewPos;
        
    }

    public void Damage()
    {
        if (godMode == false)
        {
            health--;
        }
        if(health <= 0)
        {
            //dead
            //StartCoroutine(gm.StopGames());
            //this.gameObject.SetActive(false);
            
            gm.StopGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Bullet"))
        {
            Damage();
        }
    }

}
