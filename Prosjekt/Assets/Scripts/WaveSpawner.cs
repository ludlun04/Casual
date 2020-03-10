using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum spawnState { SPAWNING, WAITING, COUNTING}

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate; //Per second
    }
    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private spawnState state = spawnState.COUNTING;
    private void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if (state == spawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                //begin new round
                
                WaveCompleted();
                return;
            } 
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != spawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    private void WaveCompleted()
    {
        Debug.Log("Wave completed");
        
        state = spawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All waves complete, looping");
        }
        nextWave++;
    }

    private bool EnemyIsAlive()
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
        Debug.Log("Spawning wave" + _wave.name);
        state = spawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = spawnState.WAITING;
        yield break;
    }

    private void SpawnEnemy(Transform _enemy)
    {
        //Spawn enemy
        Debug.Log("Spawning enemy" + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
        
    }
}
