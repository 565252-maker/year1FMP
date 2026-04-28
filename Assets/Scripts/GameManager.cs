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
        doorsLocked = false;
        playerDamage = 1;
        playerMaxHealth = 5;
        playerHealth = 5;
        playerFireCooldown = 0.5f;
        playerShotSpeed = 2.5f;
    }

    private void Update()
    {
       
        if(enemiesAlive != 0)
        {
            doorsLocked = true;
        }
        else
        {
            doorsLocked = false;
        }
    }

    
}
