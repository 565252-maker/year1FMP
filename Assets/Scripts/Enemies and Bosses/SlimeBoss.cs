using System.Threading;
using UnityEngine;

public class SlimeBoss : MonoBehaviour
{
    public float speed = 0.5f;
    Rigidbody2D rb;
    Animator anim;
    Transform player;
    Vector2 moveDirection;
    private float health;

    public int stage;
    

    float hurtCountdown = 0;

    GameObject EnemySpawn;

    EnemySpawnScript enemySpawnScript;

    GameObject playerObj;
    PlayerScript playerScript;

    float timeSpeed;

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
      

        player = GameObject.Find("Player").transform;

        if(stage == 1)
        {
            health = 15f;
        }
        if(stage == 2)
        {
            health = 5f;
        }
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

       timeSpeed = GameManager.Instance.timeSpeed;
    }

    private void FixedUpdate()
    {
        if (player)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * speed * timeSpeed;
        }
    }

   public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if(stage == 1)
            {
                for(int i = 0; i < 2; i++)
                {
                    Instantiate(Resources.Load("Prefabs/SlimeBossMini"), transform.position, transform.rotation);
                    GameManager.Instance.enemiesAlive += 1;
                }
            }
            if(stage == 2)
            {
                for(int i = 0; i < 2; i++)
                {
                    Instantiate(Resources.Load("Prefabs/Enemies_0"), transform.position, transform.rotation);
                    GameManager.Instance.enemiesAlive += 1;
                }
            }
            Destroy(gameObject);
            GameManager.Instance.enemiesAlive -= 1;
            float number = Random.Range(1, 10);
            if (number == 1)
            {
                GameManager.Instance.playerHealth += 1;
            }
            
        }

        hurtCountdown = 0;
        anim.SetBool("hurt", true);

    }



}
