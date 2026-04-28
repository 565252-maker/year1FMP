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

    public Sprite AltarRoom;

    public Sprite BossRoom;

    public int enemiesAlive;

    

    

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

    private void Awake()
    {
        if (transform.position == new Vector3(25.60f, -11.52f, 0))
        {
            enemyHasSpawned = true;
        }
        
    }
    private void Start()
    {
       
        
        if(sr.sprite == ShopRoom)
        {
            enemyHasSpawned =true; 
        }
        if (sr.sprite == AltarRoom)
        {
            enemyHasSpawned = true;
            Instantiate(Resources.Load("Prefabs/Altar"), transform.position, transform.rotation);
        }
        if (sr.sprite == BossRoom)
        {
            enemyHasSpawned = true;
        }
    }

    private void Update()
    {
        if(enemiesAlive < 0)
        {
            enemiesAlive = 0;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == ("Player"))
        {
            if (!enemyHasSpawned)
            {
                SpawnEnemies();
                enemyHasSpawned = true;

            }
        }
       
        
    }

    
}
