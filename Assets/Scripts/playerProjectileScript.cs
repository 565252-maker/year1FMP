using UnityEngine;

public class playerProjectileScript : MonoBehaviour
{
    public Vector2 direction;
    Rigidbody2D rb;
    public float speed = 2.5f;

    private void Awake()
    {
        rb.GetComponent<Rigidbody2D>();
    }
    

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = 
    }
}
