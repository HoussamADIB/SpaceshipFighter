using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //--------------------------------------------------------------Properties
    [SerializeField] List<EnemyWaveConfig> waves;
    [SerializeField] bool loopingWaves=false;
    //--------------------------------------------------------------Functions
    private void Start()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            if (waves[i].getLooping())
            {
                StartCoroutine(SpawnLoopingWave(waves[i]));
            }
            else
            {
                StartCoroutine(SpawnOneWave(waves[i]));
            }
        }
    }
    private IEnumerator SpawnOneWave(EnemyWaveConfig wave)
    {
        //enemies in this wave
        for (int i = 0; i < wave.getNumberOfEnemies(); i++)
        {
            GameObject enemy = Instantiate(
                wave.getEnemyPrefab(),
                wave.getWayPoints()[0].transform.position,//start path
                Quaternion.identity
                );
            //wave's enemy prefab has been instantiated, but the movement speed and path must be assigned dynamicly 
            enemy.GetComponent<Enemy>().setEnemyWaveConfig(wave);
            yield return new WaitForSeconds(wave.getSpawnFrequency());
        }
    }
    private IEnumerator SpawnLoopingWave(EnemyWaveConfig wave)
    {
        do
        {
            GameObject enemy = Instantiate(
                wave.getEnemyPrefab(),
                wave.getWayPoints()[0].transform.position,//start path
                Quaternion.identity
                );
            //wave's enemy prefab has been instantiated, but the movement speed and path must be assigned dynamicly 
            enemy.GetComponent<Enemy>().setEnemyWaveConfig(wave);
            yield return new WaitForSeconds(wave.getSpawnFrequency());
        }
        while (wave.getLooping()) ;
    }
}
