using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed = 10f; // Speed multiplier for swipe responsiveness

    // Gun variables
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 2f)]
    [SerializeField] private float fireRate = 0.5f;
    private float fireTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Disable gravity for swipe control
        fireTimer = 0f; // Initialize fire timer
    }

    void Update()
    {
        fireTimer -= Time.deltaTime;

        // Handle all active touches
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Determine which side of the screen the touch is on
            if (touch.position.x > Screen.width / 2)
            {
                // Right side: Fire functionality
                HandleFire(touch);
            }
            else
            {
                // Left side: Movement functionality
                HandleMovement(touch);
            }
        }
    }

    private void HandleFire(Touch touch)
    {
        if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
        {
            if (fireTimer <= 0f)
            {
                Fire();
                fireTimer = fireRate; // Reset fire rate timer
            }
        }
    }

    private void HandleMovement(Touch touch)
    {
        if (touch.phase == TouchPhase.Moved)
        {
            // Calculate swipe movement
            Vector2 touchDelta = touch.deltaPosition * moveSpeed * Time.deltaTime;

            // Apply movement directly to the plane
            rb.velocity = new Vector2(touchDelta.x, touchDelta.y);
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            // Stop movement when the touch ends
            rb.velocity = Vector2.zero;
        }
    }

    private void Fire()
    {
        // Spawn a bullet at the firing point
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}