using UnityEngine;

public class SkullShoot : MonoBehaviour
{

    float moveSpeed = 1.5f;

    Rigidbody2D rb;

    GameObject player;
    Vector2 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        moveDirection =(player.transform.position - transform.position).normalized * moveSpeed;
        rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == ("Player") || collision.gameObject.tag == ("Room"))
        {
            Destroy(gameObject);
        }
    }
    
        
    
}
