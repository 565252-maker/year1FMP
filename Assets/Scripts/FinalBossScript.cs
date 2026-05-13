using UnityEngine;

public class FinalBossScript : MonoBehaviour
{
    private float health;

    float hurtCountdown = 0;

    Animator anim; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.enemiesAlive -= 1;
            float number = Random.Range(1, 20);
            if (number == 1)
            {
                GameManager.Instance.playerHealth += 1;
            }
            float coin = Random.Range(1, 4);
            if (coin == 1)
            {
                Instantiate(Resources.Load("Prefabs/coin_0"), transform.position, transform.rotation);
                print("coinDropped");
            }
        }

        hurtCountdown = 0;
        anim.SetBool("hurt", true);

    }
}
