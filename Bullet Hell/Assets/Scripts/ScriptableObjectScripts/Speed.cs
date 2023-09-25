using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed PowerUp", menuName = "Power/Speed PowerUp")]
public class Speed : Powers
{
    private PlayerController player;
    public float baseSpeed;

    public override void Initialise(GameObject obj)
    {
        Debug.Log("Innit");
        player = obj.GetComponent<PlayerController>();
        baseSpeed = player.moveSpeed;
    }
    public override void Effect()
    {
        player.moveSpeed = player.moveSpeed * speedMod;
        Debug.Log("Applying Effect");
    }


    public override void Revert()
    {
        player.moveSpeed = baseSpeed;
        baseSpeed = 0f;

    }

}
