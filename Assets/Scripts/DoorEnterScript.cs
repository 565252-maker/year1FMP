using UnityEngine;

public class DoorEnterScript : MonoBehaviour
{
    

    private bool HasCollided;

    GameObject player;

    public SpriteRenderer sr;

    public Sprite Door0;
    public Sprite Door1;
    public Sprite Door2;
    public Sprite Door3;

    private void Start()
    {
        player =  GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        
        if (HasCollided)
        {
            
            
            player.transform.position += new Vector3(-1, 0, 0);
            Debug.Log("Player has triggered trigger");
            HasCollided = false;
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
