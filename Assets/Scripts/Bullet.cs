using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject; // Gameobject
        var health = hit.GetComponent<Health>(); // Health

        if (health != null)
        {
            health.TakeDamage(10);
        }

        Destroy(gameObject);
    }
}
