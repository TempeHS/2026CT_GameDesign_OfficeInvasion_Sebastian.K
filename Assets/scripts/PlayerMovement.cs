using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 5f;
   private Rigidbody2D rb;
   private Vector2 moveInput;
   private bool leftPunch;
   private bool rightPunch;
   public float Health, MaxHealth;
   private Animator anim;
   private float move;
   private float speed;
   private Animator isWalking;
   private Animator isAttacking;
   public GameObject attackPoint;
   public float radius;
   [SerializeField] public LayerMask enemies;

   [SerializeField]
    private HealthBarUI healthBar;
   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      healthBar.SetMaxHealth(MaxHealth);
   }

   // Update is called once per frame
   void Update()
   {
       rb.linearVelocity = moveInput * moveSpeed;

        move = Input.GetAxisRaw("Horizontal");
        //rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
        if (move > .1f || move > -.1f)
               {
                   anim.SetBool("isWalking", true);
               }
        else
            {
                anim.SetBool("isWalking", false);
            }
         if (Input.GetMouseButtonDown(0))
               {
                   anim.SetBool("isAttacking", true);
               }

       if (Input.GetKeyDown("l"))
        {
            SetHealth(-10f);
        }

        if (Input.GetKeyDown("p"))
        {
            SetHealth(10f);
        }
   }

    public void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D enemyGameobject in enemy)
        {
            Debug.Log("Hit enemy");
        }
    }
   public void Move(InputAction.CallbackContext context)
   {
       moveInput = context.ReadValue<Vector2>();
   }

   public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        healthBar.SetHealth(Health);
    }

    IEnumerator Pause1sec()
    {
        yield return new WaitForSeconds (1f);
    }
}
