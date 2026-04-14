using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public playerProjectileScript projectileScript;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    private PlayerInput playerInput;

    Vector2 attackValue;
    Vector2 moveValue;
    InputAction moveAction;
    InputAction attackAction;

    public Animator anim;
    private Rigidbody2D rb;

    public float speed;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");
        
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
        moveValue = moveAction.ReadValue<Vector2>();
        attackValue = attackAction.ReadValue<Vector2>();

        if(moveValue.x > 0)
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

       
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveValue * speed;
    }

     public void InstantiateBullet()
    {
        Instantiate(bulletPrefab,transform.position,firingPoint.rotation);
    }
    
}
