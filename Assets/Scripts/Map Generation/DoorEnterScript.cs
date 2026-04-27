using Unity.VisualScripting;
using UnityEngine;

public class DoorEnterScript : MonoBehaviour
{
    int timeEaterActive = 1;

    private bool HasCollided;

    GameObject player;
    GameObject cam;
    GameObject enemySpawn;
    EnemySpawnScript enemySpawnScript;

    bool doorsLocked;

    public SpriteRenderer sr;

    public Sprite Door0;
    public Sprite Door1;
    public Sprite Door2;
    public Sprite Door3;

    public Sprite ShopDoor0;
    public Sprite ShopDoor1;
    public Sprite ShopDoor2;
    public Sprite ShopDoor3;

    public Sprite AltarDoor0;
    public Sprite AltarDoor1;
    public Sprite AltarDoor2;
    public Sprite AltarDoor3;

    public Sprite BossDoor0;
    public Sprite BossDoor1;
    public Sprite BossDoor2;
    public Sprite BossDoor3;

     


    private void Start()
    {
        player =  GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera");

        enemySpawn = GameObject.FindGameObjectWithTag("EnemySpawn");
        enemySpawnScript = enemySpawn.GetComponent<EnemySpawnScript>();

        doorsLocked = false;
    }
    private void Update()
    {
        
       
        
       
        if (HasCollided)
        {
            if (!doorsLocked)

            {
                //Normal Door Sprite check for direction teleport
                if (sr.sprite == Door0)
                {
                    player.transform.position += new Vector3(-1, 0, 0);
                    cam.transform.position += new Vector3(-5.12f, 0, 0);
                    HasCollided = false;

                }

                if (sr.sprite == Door1)
                {
                    player.transform.position += new Vector3(0, 1, 0);
                    cam.transform.position += new Vector3(0, 2.88f, 0);
                    HasCollided = false;


                }

                if (sr.sprite == Door2)
                {
                    player.transform.position += new Vector3(1, 0, 0);
                    cam.transform.position += new Vector3(5.12f, 0, 0);
                    HasCollided = false;


                }

                if (sr.sprite == Door3)
                {
                    player.transform.position += new Vector3(0, -1, 0);
                    cam.transform.position += new Vector3(0, -2.88f, 0);
                    HasCollided = false;


                }

                //Special Door Sprite check for direction teleport and Time eater disable/enable

                if (sr.sprite == ShopDoor0 || sr.sprite == AltarDoor0 || sr.sprite == BossDoor0)
                {
                    player.transform.position += new Vector3(-1, 0, 0);
                    cam.transform.position += new Vector3(-5.12f, 0, 0);
                    HasCollided = false;
                    timeEaterActive = timeEaterActive * -1;
                    Debug.Log(timeEaterActive);
                }

                if (sr.sprite == ShopDoor1 || sr.sprite == AltarDoor1 || sr.sprite == BossDoor1)
                {
                    player.transform.position += new Vector3(0, 1, 0);
                    cam.transform.position += new Vector3(0, 2.88f, 0);
                    HasCollided = false;
                    timeEaterActive = timeEaterActive * -1;
                    Debug.Log(timeEaterActive);
                }

                if (sr.sprite == ShopDoor2 || sr.sprite == AltarDoor2 || sr.sprite == BossDoor2)
                {
                    player.transform.position += new Vector3(1, 0, 0);
                    cam.transform.position += new Vector3(5.12f, 0, 0);
                    HasCollided = false;
                    timeEaterActive = timeEaterActive * -1;
                    Debug.Log(timeEaterActive);
                }

                if (sr.sprite == ShopDoor3 || sr.sprite == AltarDoor3 || sr.sprite == BossDoor3)
                {
                    player.transform.position += new Vector3(0, -1, 0);
                    cam.transform.position += new Vector3(0, -2.88f, 0);
                    HasCollided = false;
                    timeEaterActive = timeEaterActive * -1;
                    Debug.Log(timeEaterActive);
                }
            }
            

        }

       

            
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            HasCollided = true;
            
        }
    }

    
    


}
