using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;
    public AudioClip spawnSound;

    private Wave currentWave;
    public int currentWaveIndex;
    private bool waveSpawnComplete;
    private SoundManager sm;
    private GmManager gm;

    public void Start()
    {
        currentWaveIndex = 0;
        sm = FindObjectOfType<SoundManager>();
        gm = FindObjectOfType<GmManager>();
        gm.UpdateWaveText(currentWaveIndex+1);
        StartCoroutine(StartNextWave(currentWaveIndex));

        
    }
    private void Update()
    {
        if(gm.gameOver == false)
        {
            if (waveSpawnComplete && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                waveSpawnComplete = false;
                if (currentWaveIndex + 1 < waves.Length)
                {
                    currentWaveIndex++;
                    gm.UpdateWaveText(currentWaveIndex + 1);
                    StartCoroutine(StartNextWave(currentWaveIndex));
                }
                else
                {
                    gm.GameOver();
                }
            }
        }
      
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave= waves[index];
        for (int i = 0; i < currentWave.count; i++)
        {
            //Put Game Over Check Here

            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
            sm.OneShot(spawnSound);
            Instantiate(randomEnemy, randSpot.position, Quaternion.identity);
            if(i==currentWave.count - 1)
            {
                waveSpawnComplete = true;
            }
            else
            {
                waveSpawnComplete = false;
            }
            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }
    }
}
