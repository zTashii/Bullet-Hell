using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public int speed;
    public Vector2 moveDirection;

    public void OnEnable()
    {
        Invoke("Destroy", 4f);
        
    }

    public void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
      
    }

    public void Move(Vector2 dir)
    {
        moveDirection = dir;
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
