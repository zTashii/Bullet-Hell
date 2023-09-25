using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIdleMovement : MonoBehaviour
{

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
    private void Update()
    {
        FacePlayer();
    }

    public void FacePlayer()
    {
        Vector3 vectorToTarget = targetPlayer.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 1f);
    }
}
