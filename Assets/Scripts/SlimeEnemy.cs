using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    public float speed = 0.5f;
    Rigidbody2D rb;
    Transform player;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (player)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
        }
    }
}
