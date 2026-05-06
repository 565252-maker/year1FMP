using UnityEngine;

public class SkullEnemy : MonoBehaviour
{
    public float speed;
    float duration;
    float maxDuration;
    float distanceX,distanceY;
    Vector2 direction;

    public Transform bulletPos;

    Rigidbody2D rb;
    Animator anim;
    [SerializeField]
    GameObject bullet;

    float fireRate;
    float nextFire;

    private float health;

    float hurtCountdown = 0;

    GameObject EnemySpawn;

    EnemySpawnScript enemySpawnScript;

    float timeSpeed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireRate = 1f;
        nextFire = 3;
        SetNewDestination();

        health = 2f;

        EnemySpawn = GameObject.FindWithTag("EnemySpawn");
        enemySpawnScript = EnemySpawn.GetComponent<EnemySpawnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSpeed = GameManager.Instance.timeSpeed;

        rb.linearVelocity = direction * speed * timeSpeed;

        duration += Time.deltaTime;

        if (duration > maxDuration)
        {
            SetNewDestination();
            duration = 0;
        }

        CheckIfTimeToFire();

        fireRate += Time.deltaTime * timeSpeed;

        hurtCountdown += Time.deltaTime;
        if (hurtCountdown > 0.2f)
        {
            anim.SetBool("hurt", false);
        }
    }

    void SetNewDestination()
    {
        maxDuration = Random.Range(1, 5);
        distanceX = Random.Range(-5, 6);
        distanceY = Random.Range(-5, 6);
        direction = new Vector2(distanceX,distanceY);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        direction = -direction;
    }

    void CheckIfTimeToFire()
    {
        if (fireRate > nextFire)
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
            fireRate = 0;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.enemiesAlive -= 1;
            float number = Random.Range(1, 7);
            if (number == 1)
            {
                GameManager.Instance.playerHealth += 1;
            }
            
        }

        hurtCountdown = 0;
        anim.SetBool("hurt", true);

    }
}
