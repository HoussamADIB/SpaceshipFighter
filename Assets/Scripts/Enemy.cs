using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //--------------------------------------------------------------Properties
    /*Set Settings*/
    private EnemyWaveConfig enemyWaveConfig;
    /*Imported Settings from Setters*/
    private float moveSpeed;
    private List<Transform> wayPoints;
    /*Editor Inputs*/
    [SerializeField] GameObject laserPrefab;
    [SerializeField] GameObject explosionParticleEffect;
    [SerializeField] float laserSpeed=2f;
    [SerializeField] AudioClip LaserSound;
    [SerializeField] AudioClip EnemyDeathSound;
    [SerializeField] int health;
    /*Utils*/
    private int checkPoint;
    //--------------------------------------------------------------Functions
    private void Start()
    {
        Initialization();
    }
    private void Update()
    {
        Path();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit(collision);
        
    }
    private void Initialization()
    {
        checkPoint = 0;
        if (enemyWaveConfig != null)
        {
            wayPoints = enemyWaveConfig.getWayPoints();
            moveSpeed = enemyWaveConfig.getMoveSpeed();
            StartCoroutine(fireContiniously());
        }
        else
        {
            moveSpeed = 0;
        }
    }
    private void Hit(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser100")
        {
            this.health -= 100;
            //int myScore = int.Parse(GameManager.score.text);
            //myScore += 100;
            //GameManager.score.text = myScore.ToString();
        }
        else if (collision.gameObject.tag == "Laser200")
        {
            this.health -= 200;
        }
        if (this.health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        Instantiate(explosionParticleEffect, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(EnemyDeathSound, Camera.main.transform.position);
    }
    private void Path()
    {
        if (wayPoints != null)
        {
            if (checkPoint < wayPoints.Count)
            {
                MoveTo(wayPoints[checkPoint].position);
                if (transform.position == wayPoints[checkPoint].position)
                {
                    checkPoint++;
                }
            }
            if (transform.position == wayPoints[wayPoints.Count - 1].position)
            {
                Destroy(gameObject);
            }
        }
    }
    private void MoveTo(Vector3 newPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }
    private IEnumerator fireContiniously()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0f, 10f));
                GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
                laser.GetComponent<Rigidbody2D>().velocity += new Vector2(0, -laserSpeed);
                AudioSource.PlayClipAtPoint(LaserSound, Camera.main.transform.position);
        }
    }
    /*Setters*/
    public void setEnemyWaveConfig(EnemyWaveConfig waveConfig)
    {
        this.enemyWaveConfig = waveConfig;
    }
    //
}
