using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGod : MonoBehaviour
{

    public GameObject bullet;
    public float minRotation;
    public float maxRotation;

    public Transform player;
    public int maxBullets;

    public float godSpeed;
    public float cooldown;
    public float timer;
    public float bulletSpeed;
    public Vector2 bulletVelocity;

    GameObject parentObject;

    float[] rotations;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    public Transform targetPlayer;
    public float rotationSpeed;
    public float circleRadius;
    public float elevationOffset;
    private Vector3 positionOffset;
    private float angle;

    private void LateUpdate()
    {
        positionOffset.Set(Mathf.Cos(angle) * circleRadius, Mathf.Sin(angle) * circleRadius, elevationOffset);
        transform.position = targetPlayer.position + positionOffset;
        angle += Time.deltaTime * rotationSpeed;
    }

    private void Awake()
    {
        //Bound within screen
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void Start()
    {
        
        timer = cooldown;
        rotations = new float[maxBullets];
        InvokeRepeating("FireTutorialExample", 0f, godSpeed);

    }

    void Update()
    {
        FacePlayer();
        //DistributedRotations();
        
        //if (timer <= 0)
        //{
        //    Debug.Log("Spawning Bullet");
        //    //SpawnBullets();
        //    Fire();
        //    timer = cooldown;
        //}
        Vector3 playerPos = player.position;
        Vector2 kingDir = (playerPos = transform.position).normalized;
        timer -= Time.deltaTime;

        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(transform.position.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(transform.position.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);

        transform.position = viewPos;
    }


    public void FacePlayer()
    {
        Vector3 vectorToTarget = player.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 1f);
    }

    public void Fire()
    {

        for (int i = 0; i < maxBullets; i++)
        {
            bullet = BulletPooler.bulletPoolInstance.GetBullets();

            
            bullet.gameObject.SetActive(true);
            var bul = bullet.GetComponent<Bullet>();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bul.rotation = rotations[i];
            bul.speed = bulletSpeed;
            bul.Velocity = bulletVelocity;
        }
    }

    public void FireTutorialExample()
    {
        float angleStep = (maxRotation - minRotation) / maxBullets;
        float angle = minRotation;
        for (int i = 0; i < maxBullets + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPooler.bulletPoolInstance.GetBullets();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().Velocity = bulDir;
            angle += angleStep;
        }
    }
    public float[] DistributedRotations()
    {
        for (int i = 0; i < maxBullets; i++)
        {
            var fraction = (float)i / (float)maxBullets;
            var difference = maxRotation - minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[i] = fractionOfDifference + minRotation;
            
        }

        return rotations;
    }


    public GameObject[] SpawnBullets()
    {
        
        GameObject[] spawnedBullets = new GameObject[maxBullets];
        for (int i = 0; i < maxBullets; i++)
        {
            
            spawnedBullets[i] = Instantiate(bullet);
            spawnedBullets[i].transform.SetParent(this.transform);
            spawnedBullets[i].transform.position = transform.position;
            spawnedBullets[i].transform.rotation = transform.rotation;
            var bul = spawnedBullets[i].GetComponent<Bullet>();
            bul.rotation = rotations[i];
            bul.speed = bulletSpeed;
            bul.Velocity = bulletVelocity;

        }
        return spawnedBullets;
    }



}
