//using UnityEngine;
//
//public class EnemyMovement : MonoBehaviour
//{
//    public float moveSpeed = 10f;
//    Rigidbody2D rb;
//    public Transform target;
//    Vector2 moveDirection;
//
//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//       target = GameObject.Find("Player").transform;
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        if (target)
//        {
//            Vector3 direction = (target.position - target.position).normalized;
//            moveDirection = direction;
//
//            // enemy rotation to face player
//           //float angle = MathF.Atanz(direction.y, direction.x) * Mathf.Rad2Deg;
//           //rb = rotation.angle;
//        }
//    }
//
//    private void FixedUpdate()
//    {
//        if (target)
//        {
//            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
//        }
//    }
//}

using UnityEngine;

public class SimpleEnemyChase : MonoBehaviour
{
    public Transform playerTarget;
    public float moveSpeed = 3.5f;
    public float detectionRadius = 8.0f;

    void Update()
    {
        if (playerTarget == null) return;

        // Calculate direction and distance
        float distanceToPlayer = Vector2.Distance(transform.position, playerTarget.position);

        // Move only if the player is within range
        if (distanceToPlayer <= detectionRadius)
        {
            Vector3 direction = (playerTarget.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}