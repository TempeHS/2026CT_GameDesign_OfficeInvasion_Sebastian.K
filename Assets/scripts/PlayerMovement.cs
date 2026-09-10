using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 5f;
   private float MovementX;
   private Rigidbody2D rb;
   private Vector2 moveInput;
   public float Health, MaxHealth;
   Animator anim;
   private float move;
   private float speed;
   private Animator WalkingAnim;
   private Animator AttackingAnim;
   private bool LeftPunch;
   private bool RightPunch;
   public GameObject attackPoint;
   public float radius;
   public float damage;
   [SerializeField] public LayerMask enemies;
   [SerializeField] private string MainMenuName;
   [SerializeField] private HealthBarUI healthBar;
   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      healthBar.SetMaxHealth(MaxHealth);
      anim = gameObject.GetComponent<Animator>();
   }

   // Update is called once per frame
   void Update()
   {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        move = Input.GetAxisRaw("Horizontal");
       rb.linearVelocity = moveInput * moveSpeed;
       rb.linearVelocity = new Vector2(move * speed,rb.linearVelocity.y);
       moveInput = new Vector2(moveX, moveY).normalized;
        if (Health <= 0)
        {
            SceneManager.LoadScene(MainMenuName);
        }
       if (Input.GetKeyDown("w"))
        {
            anim.SetBool("Walking", true);
        } else
        {
            anim.SetBool("Walking", false);
        }
        if (Input.GetKeyDown("a"))
        {
            anim.SetBool("Walking", true);
        } else
        {
            anim.SetBool("Walking", false);
        }
        if (Input.GetKeyDown("s"))
        {
            anim.SetBool("Walking", true);
        } else
        {
            anim.SetBool("Walking", false);
        }
        if (Input.GetKeyDown("d"))
        {
            anim.SetBool("Walking", true);
        } else
        {
            anim.SetBool("Walking", false);
        }

    if (Input.GetMouseButton(0))
        {
            anim.SetBool("Leftpunch", true);
        } else{
            anim.SetBool("Leftpunch", false);
        }
    if (Input.GetMouseButton(1))
        {
            anim.SetBool("Rightpunch", true);
        } else {
            anim.SetBool("Rightpunch", false);
        }

    if (Input.GetKeyDown("l"))
    {
        SetHealth(-10f);
    }
    if (Input.GetKeyDown("p"))
    {
        SetHealth(10f);
    }

    
    if(Input.GetKeyDown("a"))
    {
        transform.localScale = new Vector3(-1f, 1f, 1f);
    }
     if(Input.GetKeyDown("d"))
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
   }

    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D enemyGameobject in enemy)
        {
            Debug.Log("Hit enemy");
            enemyGameobject.GetComponent<EnemyHealth>().health -= damage;
        }
    }

    public void endAttack()
    {
        anim.SetBool("Rightpunch", false);
        anim.SetBool("Leftpunch", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
   public void Move(InputAction.CallbackContext context)
   {
       moveInput = context.ReadValue<Vector2>();
   }

   private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
    }

   public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        healthBar.SetHealth(Health);
    }

    IEnumerator Pause2sec()
    {
        yield return new WaitForSeconds (2f);
    }
}
