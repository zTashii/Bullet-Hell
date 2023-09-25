using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKing : MonoBehaviour
{
    public int bulletAmount;
    public float rotateSpeed;
    public float shootingSpeed;
    [SerializeField] private float startAngle = 90f, endAngle = 360f;

    private Vector2 bulletMoveDirection;
    public TimeManager tm;
    public Transform player;
    private int currentTime;
    public GameObject currentBul;
    public BulletPooler bulletPooler;
    public bool phase1;
    public bool phase2;
    public bool phase3;



    ////if start phase 1
    //// start phase
    ////change startphase 1 bool to false
    //private void Start()
    //{
        
    //    tm = tm.GetComponent<TimeManager>();
    //    StartCoroutine(Easy());
    //}
    //private void FixedUpdate()
    //{

        
    //    currentTime = tm.time;
        
    //    //StartCoroutine(Medium());

    //    //InvokeRepeating("Hell", 0f, shootingSpeed);
    //    //if (currentTime < 5)
    //    //{
    //    //    //dialogue, text, startup etc.
    //    //}
    //    //if (currentTime == 0)
    //    //{

    //    //    StartCoroutine(Easy());
    //    //    //StartCoroutine(Medium());
    //    //    //InvokeRepeating("StartGame", 0f, shootingSpeed);
    //    //}
    //    //if (currentTime == 10)
    //    //{
    //    //    bulletAmount = 2;
    //    //    StopAllCoroutines();
    //    //    StartCoroutine(Medium());

    //    //    //InvokeRepeating("Hell", 0f, shootingSpeed);
    //    //    //Hell();
    //    //}

    //}

    //public void StartGame()
    //{

    //    for (int i = 0; i < bulletAmount + 1; i++)
    //    {

    //        Vector3 bulMoveVector = player.position;
    //        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

    //        GameObject bul = BulletPooler.bulletPoolInstance.GetBullets();
    //        bul.transform.position = transform.position;
    //        bul.transform.rotation = transform.rotation;
    //        bul.SetActive(true);
    //        bul.GetComponent<Bullet>().Move(bulDir);

    //    }
    //}
    //IEnumerator Easy()
    //{
        
    //    while (phase1)
    //    {

    //        //MoreHell();
    //        Vector3 bulMoveVector = player.position;
    //        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

    //        GameObject bul = BulletPooler.bulletPoolInstance.GetBullets();
    //        if (bul != null)
    //        {
    //            bul.transform.position = transform.position;
    //            bul.transform.rotation = transform.rotation;
    //            currentBul = bul;
    //            bul.SetActive(true);
    //            bul.GetComponent<Bullet>().Move(bulDir);
    //        }

    //        yield return new WaitForSeconds(shootingSpeed);

    //    }
            
        
    //}
        

    //IEnumerator Medium()
    //{
    //    float angleStep = (endAngle - startAngle) / bulletAmount;
    //    float angle = startAngle;
    //    while (currentTime < 30)
    //    {
            
    //        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
    //        float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

    //        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
    //        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

    //        GameObject bul = BulletPooler.bulletPoolInstance.GetBullets();
    //        bul.transform.position = transform.position;
    //        bul.transform.rotation = transform.rotation;
    //        bul.SetActive(true);
    //        bul.GetComponent<Bullet>().Move(bulDir);

    //        angle += angleStep;
    //        yield return new WaitForSeconds(shootingSpeed);
            
    //    }
    //}

    //private void Hell()
    //{
    //    float angleStep = (endAngle - startAngle) / bulletAmount;
    //    float angle = startAngle;

    //    for(int i = 0; i < bulletAmount + 1; i++)
    //    {
    //        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) /180f);
    //        float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) /180f);

    //        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
    //        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

    //        GameObject bul = BulletPooler.bulletPoolInstance.GetBullets();
    //        bul.transform.position = transform.position;
    //        bul.transform.rotation = transform.rotation;
    //        bul.SetActive(true);
    //        bul.GetComponent<Bullet>().Move(bulDir);

    //        angle += angleStep;
    //    }
    //}

    //public void MoreHell()
    //{
        
    //    transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

    //}
    //public void EvenMoreHell()
    //{
        
    //    transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    //}
    //public void EvenMoreHellPart2()
    //{
        
    //    transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    //}
    //public void HellRandomizer()
    //{

    //}




}
