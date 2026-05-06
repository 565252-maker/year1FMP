using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float playerDamage;
    public float playerMaxHealth;
    public float playerHealth;
    public float playerFireCooldown;
    public float playerShotSpeed;

    public playerProjectileScript projectileScript;
    public SlimeEnemy slimeEnemy;
    public SkullEnemy skullEnemy;

    public int enemiesAlive;
    public bool doorsLocked;

    public float timeSpeed = 0;

    public bool timeEaterHasSpawned;
    float timeEaterCooldown;

    GameObject doorEnter;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        timeEaterHasSpawned = false;
        doorsLocked = false;
        playerDamage = 1;
        playerMaxHealth = 5;
        playerHealth = 5;
        playerFireCooldown = 0.5f;
        playerShotSpeed = 2.5f;
    }

    private void Update()
    {
        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }

        if (enemiesAlive != 0)
        {
            doorsLocked = true;
            timeEaterHasSpawned = false;
        }
        else
        {
            doorsLocked = false;
            timeEaterCooldown += Time.deltaTime;
            if(timeEaterCooldown > 1)
            {
                GameObject timeEater = GameObject.FindGameObjectWithTag("TimeEater");
                Destroy(timeEater);
                timeEaterHasSpawned = false;
                timeEaterCooldown = 0;
            }
           
        }
    }

    
}
