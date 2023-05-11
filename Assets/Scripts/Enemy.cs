using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats:")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damageToCore = 1;
    [SerializeField] private int health = 50;
    [SerializeField] private int bounty = 10;
    private Transform target;
    private int wayPointIndex = 0;

    public GameObject deathAnimation;

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

    public void damageCalculation(int damage)
    {
        health -= damage;
        HealthBar();
        if (health <= 0)
        {
            Death();
        }
    }

    void HealthBar()
    {
        return;
    }

    void Death()
    {
        GameObject effect = (GameObject)Instantiate(deathAnimation, transform.position, transform.rotation);
        Destroy(effect, 2f);

        Destroy(gameObject);
        PlayerStats.money += bounty;
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
        PlayerStats.coreLives -= damageToCore;
        return;
    }
}
