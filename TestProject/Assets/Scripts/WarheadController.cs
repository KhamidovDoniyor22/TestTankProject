using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarheadController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
