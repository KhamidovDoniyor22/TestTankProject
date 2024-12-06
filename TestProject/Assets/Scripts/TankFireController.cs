using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFireController : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform barrelTip;
    [SerializeField, Range(5f, 50f)] private float fireForce = 20f;

    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, barrelTip.position, barrelTip.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(barrelTip.up * fireForce, ForceMode2D.Impulse);
    }
}
