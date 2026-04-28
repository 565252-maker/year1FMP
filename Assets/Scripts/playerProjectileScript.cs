using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
public class playerProjectileScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float lifetime = 3f;
    public float damage;

    public Vector2 attackValue;

    private Vector2 direction;
    private void Start()
    {
        direction = attackValue;
        Destroy(gameObject, lifetime);
        damage = GameManager.Instance.playerDamage;
        speed = GameManager.Instance.playerShotSpeed;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        rb.linearVelocity = direction * speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == ("Enemy"))
        {
            Destroy(gameObject);
            if(other.gameObject.TryGetComponent<SlimeEnemy>(out SlimeEnemy enemyComponent))
            {
                enemyComponent.TakeDamage(damage);
            }

            if(other.gameObject.TryGetComponent<SkullEnemy>(out SkullEnemy enemyComponent1))
            {
                enemyComponent1.TakeDamage(damage);
            }
        }
        if (other.tag == ("Room"))
        {

            Destroy(gameObject);

        }
    }




}
