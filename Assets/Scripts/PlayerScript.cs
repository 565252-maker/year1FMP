using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public playerProjectileScript projectileScript;

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
        projectileScript = GetComponent<playerProjectileScript>();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        projectileScript.
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveValue * speed;
    }

     
    
}
