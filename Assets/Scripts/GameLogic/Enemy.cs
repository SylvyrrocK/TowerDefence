using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats:")]
    [SerializeField] public float speed = 10f;
    [SerializeField] private int damageToCore = 1;
    [SerializeField] private int bounty = 10;
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private float rotationSpeed = 5f;

    public float startHealth = 50;
    private float health;

    private Transform target;
    private int wayPointIndex = 0;

    [Header("Unity Stuff (Dont Change):")]
    public GameObject deathAnimation;
    public Image enemyHealthBar;

    void Start()
    {
        target = Waypoints.waypoints[0];
        health = startHealth;
    }

    void Update()
    {
        Vector2 dirrection = target.position - transform.position;
        transform.Translate(dirrection.normalized * speed * Time.deltaTime, Space.World);

        //Enemy sprite rotation according to dirrectional vector
        if (dirrection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dirrection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, target.position) <=0.2f )
        {
            GetNextWaypoint();
        }
    }

    public void DamageCalculation(int damage)
    {
        health -= damage;
        enemyHealthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        GameObject effect = (GameObject)Instantiate(deathAnimation, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effect, 0.5f);
  
        PlayerStats.score += scoreValue;
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
