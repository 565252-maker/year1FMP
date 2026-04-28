using System.Threading;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    public float speed = 0.5f;
    Rigidbody2D rb;
    Animator anim;
    Transform player;
    Vector2 moveDirection;
    private float health;

    

    float hurtCountdown = 0;

    GameObject EnemySpawn;

    EnemySpawnScript enemySpawnScript;

    GameObject playerObj;
    PlayerScript playerScript;

    //float timeSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        EnemySpawn = GameObject.FindWithTag("EnemySpawn");
        enemySpawnScript = EnemySpawn.GetComponent<EnemySpawnScript>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      //  playerObj = GameObject.FindGameObjectWithTag("Player");
      //  playerScript = player.GetComponent<PlayerScript>();

        player = GameObject.Find("Player").transform;
        health = 1.5f;
    }   

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            moveDirection = direction;
        }

        hurtCountdown += Time.deltaTime;
        if(hurtCountdown > 0.2f)
        {
            anim.SetBool("hurt", false);
        }

       // timeSpeed = playerScript.timeSpeed;
    }

    private void FixedUpdate()
    {
        if (player)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * speed;// * timeSpeed;
        }
    }

   public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.enemiesAlive -= 1;
        }

        hurtCountdown = 0;
        anim.SetBool("hurt", true);

    }



}
