using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Shooting;
using static SkillTree;
using static characterHealth;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner WaveControls;
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    public GameObject panel;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    public int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 10;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        WaveControls = this;

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawnpoints have been placed");
        }
        waveCountdown = timeBetweenWaves;
        panel.SetActive(false);
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemeyIsAlive())
            {

                Debug.Log("Wave completed");
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                panel.SetActive(false);
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

    }

    public IEnumerator Count()
    {
        waveCountdown -= 1;
        Debug.Log("help");
        yield return new WaitForSeconds(1f);
    }

    void WaveCompleted()
    {
        panel.SetActive(true);
        skillTree.skillPoint += 1;
        charHealth.health = charHealth.maxHealth;
        skillTree.UpdateAllSkillUi();
        Debug.Log("Wave Completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("all waves completed");
        }

        nextWave++;
    }

    bool EnemeyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
        
     
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i ++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning enemy");

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
