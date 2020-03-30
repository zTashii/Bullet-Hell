using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKing : MonoBehaviour
{
    public int bulletAmount;
    public float rotateSpeed;
    [SerializeField] private float startAngle = 90f, endAngle = 360f;

    private Vector2 bulletMoveDirection;


    private void Start()
    {
        InvokeRepeating("Hell", 0f, 0.1f);
    }
    private void Update()
    {
      
        EvenMoreHellPart3();
    }

    private void Hell()
    {
        float angleStep = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;

        for(int i = 0; i < bulletAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) /180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) /180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPooler.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().Move(bulDir);

            angle += angleStep;
        }
    }

    public void EvenMoreHell()
    {
        transform.Rotate(Vector2.up * rotateSpeed * Time.deltaTime);
    }
    public void EvenMoreHellPart2()
    {
        transform.Rotate(Vector2.right * rotateSpeed * Time.deltaTime);
    }
    public void EvenMoreHellPart3()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }



}
