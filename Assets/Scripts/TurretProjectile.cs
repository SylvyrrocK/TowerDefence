using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 100f;
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
            Destroy(gameObject);
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
        Instantiate(projectileImpact, transform.position, transform.rotation);
        Destroy(gameObject);
 
        // Debug.Log("HIT LANDED");
    }
}