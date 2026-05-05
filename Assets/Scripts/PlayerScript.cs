using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    playerProjectileScript projectileScript;
    DoorEnterScript doorEnterScript;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    private PlayerInput playerInput;

    [SerializeField] private healthBar HealthBar;

    Vector2 attackValue;
    Vector2 moveValue;
    InputAction moveAction;
    InputAction attackAction;

    public Animator anim;
    private Rigidbody2D rb;

    public float speed;

    private float shootCooldown;

    public float timeSpeed;

    public float health;
    public float maxHealth;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;
    public bool KnockFromUp;

    float immunityTimer = 0;
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");
        doorEnterScript = GetComponent<DoorEnterScript>();
        health = GameManager.Instance.playerHealth;

       
    }
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        foreach (var actionMap in playerInput.actions.actionMaps)
        {
            actionMap.Disable();
        }

        playerInput.SwitchCurrentActionMap("Player");
    }

    private void Update()
    {
        immunityTimer += Time.deltaTime;

        moveValue = moveAction.ReadValue<Vector2>();
        attackValue = attackAction.ReadValue<Vector2>();

        maxHealth = GameManager.Instance.playerMaxHealth;
        HealthBar.SetmaxHealth(maxHealth);

        health = GameManager.Instance.playerHealth;
        HealthBar.SetHealth(health);

        //  print(moveValue.x);
        if (attackValue.x != 0 || attackValue.y != 0)
        {
            Shoot(attackValue);
        }

        if(moveValue.x > moveValue.y)
        {
            timeSpeed = moveValue.x;
        }
        else
        {
            timeSpeed = moveValue.y;
        }

        if(timeSpeed == 0)
        {
            timeSpeed = 0.1f;
        }
        if (moveValue.x > 0)
        {
            anim.SetBool("walkingRight", true);
            anim.SetBool("walkingLeft", false);
            anim.SetBool("walkingUp", false);
            anim.SetBool("walkingDown", false);
        }

        if (moveValue.x < 0)
        {
            anim.SetBool("walkingRight", false);
            anim.SetBool("walkingLeft", true);
            anim.SetBool("walkingUp", false);
            anim.SetBool("walkingDown", false);
        }

        if (moveValue.y > 0)
        {
            anim.SetBool("walkingRight", false);
            anim.SetBool("walkingLeft", false);
            anim.SetBool("walkingUp", true);
            anim.SetBool("walkingDown", false);
        }

        if (moveValue.y < 0)
        {
            anim.SetBool("walkingRight", false);
            anim.SetBool("walkingLeft", false);
            anim.SetBool("walkingUp", false);
            anim.SetBool("walkingDown", true);
        }

        if (moveValue.x == 0)
        {
            anim.SetBool("walkingRight", false);
            anim.SetBool("walkingLeft", false);
        }

        if (moveValue.y == 0)
        {
            anim.SetBool("walkingUp", false);
            anim.SetBool("walkingDown", false);
        }

        shootCooldown += Time.deltaTime;

       
    }

    private void FixedUpdate()
    {
        if(KBCounter <= 0)
        {
            rb.linearVelocity = moveValue * speed;
        }
        else
        {
            if (KnockFromRight)
            {
                rb.linearVelocity = new Vector2(-KBForce, 0);
            }
            if (!KnockFromRight)
            {
                rb.linearVelocity = new Vector2(KBForce, 0);
            }
            if (KnockFromUp)
            {
                rb.linearVelocity = new Vector2(0,-KBForce);
            }
            if (!KnockFromUp)
            {
                rb.linearVelocity = new Vector2(0, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }
    }

    public void Shoot( Vector2 attackDirection )
    {
        GameObject obj;

        if (shootCooldown > GameManager.Instance.playerFireCooldown)
        {
            


            obj = Instantiate(bulletPrefab, firingPoint.position, transform.rotation);
            obj.GetComponent<playerProjectileScript>().attackValue = attackDirection;

            shootCooldown = 0;
        }

    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Enemy") || collision.gameObject.tag == ("EnemyBullet"))
        {
            if(immunityTimer > 1.5f)
            {
                KBCounter = KBTotalTime;
                if(collision.transform.position.x <= transform.position.x)
                {
                    KnockFromRight = false;
                }
                if (collision.transform.position.x >= transform.position.x)
                {
                    KnockFromRight = true;
                }
                if (collision.transform.position.y <= transform.position.x)
                {
                    KnockFromUp = false;
                }
                if (collision.transform.position.x >= transform.position.x)
                {
                    KnockFromUp = true;
                }
                immunityTimer = 0;
                GameManager.Instance.playerHealth -= 1;
                health = GameManager.Instance.playerHealth;
                HealthBar.SetHealth(health);

                if (health == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }



}
