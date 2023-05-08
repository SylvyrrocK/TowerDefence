using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats:")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 1;
    private Transform target;
    private int wayPointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoints[0]; 
    }

    void Update()
    {
        Vector2 dirrection = target.position - transform.position;
        transform.Translate(dirrection.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <=0.5f )
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wayPointIndex >= Waypoints.waypoints.Length - 1)
        {
            FinishReached();
            return;
        }

        wayPointIndex++;
        target = Waypoints.waypoints[wayPointIndex];
    }

    void FinishReached()
    {
        Destroy(gameObject);
        PlayerStats.coreLives -= damage;
        return;
    }
}
