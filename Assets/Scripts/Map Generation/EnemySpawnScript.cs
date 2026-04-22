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

    int enemiesAlive = 0;


    public void SpawnEnemies()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            int choice = Random.Range(0, 2);
            Instantiate(Enemies[choice], spawnPoint.position, spawnPoint.rotation);
            enemyHasSpawned = true;
            enemiesAlive += 1;
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

        
        if(sr.sprite == ShopRoom)
        {
            enemyHasSpawned =true; 
        }
        if (sr.sprite == AltarRoom)
        {
            enemyHasSpawned = true;
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
