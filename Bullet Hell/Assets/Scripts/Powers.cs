using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powers : ScriptableObject
{
    public int id;
    public string powerName;
    public float speedMod;
    public float timeLimit;
    public Sprite sprite;

    public abstract void Initialise(GameObject obj);
    public abstract void Effect();
    public abstract void Revert();


}
