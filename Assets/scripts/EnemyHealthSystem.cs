using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float enemyhealth;
    public void TakeDamage (float damage)
    {
        enemyhealth -= damage;
        DebugLog(enemyhealth);
    }
}
