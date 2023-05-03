using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLogic : MonoBehaviour
{
    public Transform target;
    public Transform partToRotate;

    public string enemyTag = "Enemy";
    public float range = 10f;
    public float turnSpeed = 10f;

    void Start()
    {
        InvokeRepeating("TargetLock", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        // Calculation for rotation point in unity units
        Vector3 dir = target.position - transform.position;
        Vector3 rotatedVectorDir = Quaternion.Euler(0, 0, 0) * dir;
        Quaternion lookRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorDir);
        Quaternion rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);
        partToRotate.rotation = rotation;

        // Second option ?
        //Vector3 dirrection = target.position - transform.position;
        //Quaternion dirrectionToRotate = Quaternion.LookRotation(dirrection);
        //Vector3 targetRotation = dirrectionToRotate.eulerAngles;
        //rotataionPoint.rotation = Quaternion.Euler (0f, targetRotation.y, 0f);
    }

    // Draw radius of selected tower
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void TargetLock()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float closestEnemyDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestEnemyDistance)
            {
                closestEnemyDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && closestEnemyDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}
