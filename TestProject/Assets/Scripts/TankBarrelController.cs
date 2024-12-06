using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBarrelController : MonoBehaviour
{
    [SerializeField, Range(10f, 90f)] private float maxAngle = 45f;
    [SerializeField, Range(0.1f, 50f)] private float movementSpeed = 2f; 

    private void Update()
    {
        AnimateBarrel();
    }
    private void AnimateBarrel()
    {
        float angle = Mathf.PingPong(Time.time * movementSpeed, maxAngle * 2) - maxAngle;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
