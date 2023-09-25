using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  
    public Vector2 Velocity;
    public float speed;
    public float rotation;
    public float lifeTime;
    public float maxLifetime;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;


    private void OnEnable()
    {
        Invoke("Destroy", lifeTime);
    }
    void Start()
    {
        lifeTime = maxLifetime;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        //objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void Update()
    {

        transform.Translate(Velocity * speed * Time.deltaTime);
        //lifeTime -= Time.deltaTime;
        //if (lifeTime <= 0)
        //{
        //    lifeTime = maxLifetime;
        //    this.gameObject.SetActive(false);
        //}
        //Vector3 viewPos = transform.position;
        //viewPos.x = Mathf.Clamp(transform.position.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        //viewPos.y = Mathf.Clamp(transform.position.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        //transform.position = viewPos;


    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

}
