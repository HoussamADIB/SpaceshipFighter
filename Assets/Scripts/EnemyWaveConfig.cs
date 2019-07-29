using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is A Scriptable Object Used as an wave config instance//
[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class EnemyWaveConfig : ScriptableObject
{
    //--------------------------------------------------------------Properties
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float spawnFrequency;
    [SerializeField] float randomFactor;
    [SerializeField] float moveSpeed;
    [SerializeField] int numberOfEnemies;
    [SerializeField] bool looping;
    //--------------------------------------------------------------Functions
    /*Getters For Spawner*/
    public bool             getLooping()            { return looping; }
    public GameObject       getEnemyPrefab()        { return enemyPrefab; }
    public float            getSpawnFrequency()     { return spawnFrequency; }
    public float            getRandomFactor()       { return randomFactor; }
    public int              getNumberOfEnemies()    { return numberOfEnemies; }
    /*Getters For Each Enemy*/
    public float            getMoveSpeed()          { return moveSpeed; }
    public List<Transform>  getWayPoints()
        {
            List<Transform> wayPoints = new List<Transform>();
            for (int i = 0; i < pathPrefab.GetComponent<Transform>().childCount; i++)
            {
                wayPoints.Add(pathPrefab.transform.GetChild(i).transform);
            }
            return wayPoints;
        }
    //
}
