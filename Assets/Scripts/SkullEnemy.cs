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

    [SerializeField]
    GameObject bullet;

    float fireRate;
    float nextFire;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireRate = 1f;
        nextFire = 3;
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = direction * speed;

        duration += Time.deltaTime;

        if (duration > maxDuration)
        {
            SetNewDestination();
            duration = 0;
        }

        CheckIfTimeToFire();

        fireRate += Time.deltaTime;
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
}
