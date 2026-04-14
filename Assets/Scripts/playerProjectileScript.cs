using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class playerProjectileScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float lifetime = 3f;

    private void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.up * speed;
    }
}
