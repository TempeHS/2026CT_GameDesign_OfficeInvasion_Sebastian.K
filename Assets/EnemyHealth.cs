using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float health;
    private float hurt;
    IEnumerator Pause5sec()
    {
        yield return new WaitForSeconds (5f);
    }
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(health <= 0)
        {
            Debug.Log("enemy is dead");
            Destroy(gameObject);
        }

        if (hurt != health)
        {
            spriteRenderer.color = Color.red;
            Pause5sec();
            spriteRenderer.color = Color.white;
            hurt = health;
        } 
    }
}
