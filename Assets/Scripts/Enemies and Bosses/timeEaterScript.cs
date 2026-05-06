using UnityEngine;

public class timeEaterScript : MonoBehaviour
{
    float speed = 0.2f;
    Rigidbody2D rb;
    Animator anim;
    Transform player;
    Vector2 moveDirection;
    public Transform timeEater;



   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        player = GameObject.Find("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(timeEater.position, player.position);
        if(distance > 4)
        {
            speed = 10;
        }
        else
        {
            speed = 0.2f;
        }
        print(distance);

        if (player)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            moveDirection = direction;
        }

       if (moveDirection.x > 0)
        {
            anim.SetBool("movingRight", true);
        }
        if (moveDirection.x < 0)
        {
            anim.SetBool("movingRight", false);
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
