using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTileController : MonoBehaviour
{
    [Header("Warhead Settings")]
    [SerializeField] private GameObject warheadPrefab;
    [SerializeField, Range(2, 10)] private int warheadCount = 3;
    [SerializeField, Range(1f, 10f)] private float spreadAngle = 15f;
    [SerializeField, Range(1f, 10f)] private float warheadSpeedMultiplier = 1f; 
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        Invoke(nameof(SplitIntoWarheads), 0.7f);
    }
    private void SplitIntoWarheads()
    {
        float baseAngle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        float angleStep = spreadAngle / (warheadCount - 1);
        float startAngle = baseAngle - spreadAngle / 2;

        for (int i = 0; i < warheadCount; i++)
        {
            float currentAngle = startAngle + angleStep * i;
            Vector2 direction = Quaternion.Euler(0, 0, currentAngle) * Vector2.right;

            GameObject warhead = Instantiate(warheadPrefab, transform.position, Quaternion.identity);
            Rigidbody2D warheadRb = warhead.GetComponent<Rigidbody2D>();
            warheadRb.velocity = direction.normalized * rb.velocity.magnitude * warheadSpeedMultiplier;
        }
        Destroy(gameObject);
    }
}
