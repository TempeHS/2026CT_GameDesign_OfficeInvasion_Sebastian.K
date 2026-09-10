using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    private float hurt;
    public ParticleSystem particleSystem;
    IEnumerator Pause1sec()
    {
        yield return new WaitForSeconds (1f);
    }
    
    void Update()
    {
        if(health <= 0)
        {
            Debug.Log("enemy is dead");
        }

        if (hurt != health)
        {
            particleSystem.Play();
            Pause1sec();
            hurt = health;
        } 
    }
}
