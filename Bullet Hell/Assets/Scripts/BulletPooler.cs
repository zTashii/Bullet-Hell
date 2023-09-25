using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{
    public static BulletPooler bulletPoolInstance;

    //[SerializeField] private GameObject pooledBullet;
    //private bool notEnoughBullets = true;
    //private int maxBullets = 100;
    GameObject parentObject;
    public List<GameObject> bullets;
    public List<PooledBullet> bulletToPool;
    
    private void Awake()
    {
        bulletPoolInstance = this;
    }

    private void Start()
    {
        bullets = new List<GameObject>();
        parentObject = new GameObject();
        foreach (PooledBullet item in bulletToPool)
        {
            
            parentObject.transform.SetParent(transform);
            parentObject.name = "Bullets";
            for (int i = 0; i < item.maxBullets; i++)
            {
                GameObject bul = Instantiate(item.bulletToPool);
                bul.transform.SetParent(parentObject.transform);
                bul.SetActive(false);
                bullets.Add(bul);
            }
        }
    }

    public GameObject GetBullets()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    Debug.Log(bullets[i]);
                    return bullets[i];
                }
            }
            foreach (PooledBullet item in bulletToPool)
            {
                parentObject = GameObject.Find("Bullets");
                if (item.notEnoughBullets)
                {
                    GameObject bul = Instantiate(item.bulletToPool);
                    bul.transform.SetParent(parentObject.transform);
                    bul.SetActive(false);
                    bullets.Add(bul);
                    return bul;
                }
            }
        }
        return null;
    }

}

[System.Serializable]
public class PooledBullet
{
    public int maxBullets;
    public GameObject bulletToPool;
    public bool notEnoughBullets;
}

