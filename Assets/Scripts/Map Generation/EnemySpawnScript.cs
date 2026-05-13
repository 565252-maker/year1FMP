using NUnit.Framework;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject[] Bosses;

    public int enemyCount = 5;

    public Transform spawnPoint;

    bool enemyHasSpawned = false;

    public SpriteRenderer sr;

    public Sprite ShopRoom;
    public Sprite ShopRoom2;

    public Sprite AltarRoom;
    public Sprite AltarRoom2;

    public Sprite BossRoom;
    public Sprite BossRoom2;

    public int enemiesAlive;

    bool hatchSpawned;

    public Transform bloodMachine;
    public Transform powerUp;

    public void SpawnEnemies()
    {
        enemiesAlive = 0;
        for(int i = 0; i < enemyCount; i++)
        {
            int choice = Random.Range(0, 2);
            Instantiate(Enemies[choice], spawnPoint.position, spawnPoint.rotation);
            enemyHasSpawned = true;
            enemiesAlive += 1;
        }
       GameManager.Instance.enemiesAlive = enemiesAlive;
    }

    public void SpawnBoss()
    {
        
        enemiesAlive = 0;
        if(GameManager.Instance.currentFloor != 4)
        {
            int choice = Random.Range(0, 2);
            Instantiate(Bosses[choice], spawnPoint.position, spawnPoint.rotation);
            enemyHasSpawned = true;
            enemiesAlive += 1;
            GameManager.Instance.enemiesAlive = enemiesAlive;
        }
        if(GameManager.Instance.currentFloor == 4)
        {
            Instantiate(Bosses[2], spawnPoint.position + new Vector3(0,-0.3f,0), spawnPoint.rotation);
            enemyHasSpawned = true;
            enemiesAlive += 1;
            GameManager.Instance.enemiesAlive = enemiesAlive;
        }
        
    }

    private void Awake()
    {
        if (transform.position == new Vector3(25.60f, -11.52f, 0))
        {
            enemyHasSpawned = true;
        }
        
    }
    private void Start()
    {
        hatchSpawned = false;
        if(sr.sprite == ShopRoom || sr.sprite == ShopRoom2)
        {
            enemyHasSpawned =true;
            Instantiate(Resources.Load("Prefabs/Blood Machine_0"), bloodMachine.position,bloodMachine.rotation);
            Instantiate(Resources.Load("Prefabs/ShopAltar"), powerUp.position, powerUp.rotation);
        }
        if (sr.sprite == AltarRoom || sr.sprite == AltarRoom2)
        {
            enemyHasSpawned = true;
            
            Instantiate(Resources.Load("Prefabs/Altar"), transform.position,transform.rotation);
            
        }
        
    }

    private void Update()
    {
        if(enemiesAlive < 0)
        {
            enemiesAlive = 0;
        }

        if (sr.sprite == BossRoom || sr.sprite == BossRoom2)
        {
            if(enemyHasSpawned && GameManager.Instance.enemiesAlive == 0 && hatchSpawned == false)
            {
                Instantiate(Resources.Load("Prefabs/Hatch"),transform.position,transform.rotation);
                hatchSpawned = true; 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == ("Player"))
        {
            if (!enemyHasSpawned)
            {
                if(sr.sprite != BossRoom && sr.sprite != BossRoom2)
                {
                    SpawnEnemies();
                    enemyHasSpawned = true;
                }
                if (sr.sprite== BossRoom || sr.sprite == BossRoom2)
                {
                    SpawnBoss();
                    enemyHasSpawned = true;
                }

            }
        }
       
        
    }

    
}
