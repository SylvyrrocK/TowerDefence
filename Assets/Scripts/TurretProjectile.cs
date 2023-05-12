using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    [Header ("Projectile Stats:")]
    [SerializeField] private float projectileSpeed = 100f;
    [SerializeField] private float impactRadius = 0f;
    [SerializeField] private int damage = 10;

    [Header ("Unity Stuff:")]
    public GameObject projectileImpact;
    private Transform projectileTarget;

    public void Chase (Transform target)
    {
        projectileTarget = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (projectileTarget == null)
        {
            if (impactRadius > 0)
            {
                Explode();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            return;
        }

        Vector2 dirrection = projectileTarget.position - transform.position;
        float tickDistance = projectileSpeed * Time.deltaTime;

        // Preventing moving over target on hit
        if (dirrection.magnitude <= tickDistance)
        {
            ProjectileCollision();
            return;
        }
        transform.Translate(dirrection.normalized * tickDistance, Space.World);
    }

    public void ProjectileCollision()
    {
        GameObject hitAfterWave = Instantiate(projectileImpact, transform.position, transform.rotation);
        Destroy(hitAfterWave, 1.5f); // Projectile animation

        if (impactRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(projectileTarget);
        }

        Destroy(gameObject); // Projectile

        // DELETE LATER
        //Destroy(projectileTarget.gameObject); // Enemy
        //Debug.Log("HIT LANDED");
    }

    void Damage(Transform projectileTarget)
    {
        Enemy enemy = projectileTarget.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.damageCalculation(damage);
            return;
        }
        else
        {
            return;
        }
        //Destroy(projectileTarget.gameObject); // Enemy
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, impactRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactRadius);
    }
}