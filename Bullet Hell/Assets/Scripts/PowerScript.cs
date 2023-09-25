using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public Powers power;
    public float timeLimit;
    public float timer;
    public void UsePower()
    {
        power.Initialise(gameObject);
        power.Effect();
        StartCoroutine(Timer());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("PowerUp"))
        {
            Debug.Log("HIII");
            power = collision.GetComponent<PowersObject>().power;
            timeLimit = power.timeLimit;
            Destroy(collision.gameObject);
            UsePower();
        }
    }

    IEnumerator Timer()
    {
        while (timer < timeLimit)
        {
            yield return new WaitForSeconds(1f);
            timer += 1;
        }
        if(timer == timeLimit)
        {
            power.Revert();
            timer = 0;
            StopCoroutine(Timer());
            power = null;
        }
       
    }

}
