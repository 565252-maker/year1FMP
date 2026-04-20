using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
public class playerProjectileScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float lifetime = 3f;

    public Vector2 attackValue;

    private Vector2 direction;
    private void Start()
    {
        direction = attackValue;
        Destroy(gameObject, lifetime);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        rb.linearVelocity = direction * speed;

    }






}
