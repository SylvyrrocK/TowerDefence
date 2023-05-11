using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefabDefault;
    public Transform enemyPrefabRunner;
    public Transform enemyPrefabTank;
    public Transform spawnPoint;
    public Transform endPoint;

    public TextMeshProUGUI waveTimerText;
    public TextMeshProUGUI waveNumberText;

    [SerializeField] private float waveTimer = 5f;
    [SerializeField] private int waveNumber = 0;
    private float timer = 5f;

    void Update()
    {
      if (timer <= 0f)
        {
            StartCoroutine(WaveSpawn());
            timer = waveTimer;
            waveTimer += 1f;
        }

        waveTimerText.text = "Next:" + Mathf.Ceil(timer).ToString();
        timer -= Time.deltaTime; // TODO: format timer so it runs smooth
    }

    IEnumerator WaveSpawn()
    {
        waveNumber++;
        waveNumberText.text = "Wave:" + waveNumber.ToString();
        if (waveNumber <= 4)
        {
            for (int i = 0; i < waveNumber; i++)
            {
                EnemySpawnDefault();
                yield return new WaitForSeconds(0.5f);
                EnemySpawnDefault();
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber >= 4 && waveNumber <= 10)
        {
            for (int i = 0; i < waveNumber; i++)
            {
                EnemySpawnDefault();
                yield return new WaitForSeconds(0.1f);
                EnemySpawnRunner();
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber >=10)
        {
            for (int i = 0; i < waveNumber/2; i++)
            {
                EnemySpawnTank();
                yield return new WaitForSeconds(0.3f);
                EnemySpawnDefault();
                yield return new WaitForSeconds(0.3f);
                EnemySpawnRunner();
                yield return new WaitForSeconds(0.2f);
                EnemySpawnRunner();
                yield return new WaitForSeconds(0.2f);
                EnemySpawnRunner();
                yield return new WaitForSeconds(0.2f);
                EnemySpawnDefault();
                yield return new WaitForSeconds(1f);
            }
        }
    }

    void EnemySpawnDefault()
    {
        Instantiate(enemyPrefabDefault, spawnPoint.position, spawnPoint.rotation);
    }

    void EnemySpawnRunner()
    {
        Instantiate(enemyPrefabRunner, spawnPoint.position, spawnPoint.rotation);
    }

    void EnemySpawnTank()
    {
        Instantiate(enemyPrefabTank, spawnPoint.position, spawnPoint.rotation);
    }
}
