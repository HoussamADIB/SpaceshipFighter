using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Test
 */

public class Player : MonoBehaviour
{
    //--------------------------------------------------------------Properties
    /*Editor Inputs*/




    [SerializeField] float padding;
    [SerializeField] float moveSpeed;
    [SerializeField] float laserSpeed;
    [SerializeField] int health;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioClip PlayerDeathSound;
    [SerializeField] AudioClip PlayerFiringSound;
    //
    private Rigidbody2D rb;
    private Vector3 initialPos;
    private Vector3 actualPos;
    private Coroutine firingCoroutine;

    private bool touchStart = false;
    

    [SerializeField] public Transform circle;
    [SerializeField] public Transform outerCircle;

    /*Boundaries*/
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    //--------------------------------------------------------------Functions//

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetUpBoundaries();
        firingCoroutine = StartCoroutine(fireContiniously());
    }
    private void Update()
    {
        if (Time.timeScale != 0)//Move only when in-game (when in-menu timescale = 0)
        {
            Move();
        }
        
        Fire();
    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            actualPos = Input.mousePosition;
            Vector3 diff = actualPos - initialPos;
            Vector2 directionJoy = Vector2.ClampMagnitude(diff, 40f);
            Vector2 directionPlayer = Vector2.ClampMagnitude(diff, 1f);
            movePlayer(directionPlayer);
            //move joystick
            circle.position = Camera.main.ScreenToWorldPoint(new Vector3(initialPos.x + directionJoy.x, initialPos.y + directionJoy.y, 1));
            //
        }
        
    }
    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialPos = Input.mousePosition;
            //display joystick
            circle.position = Camera.main.ScreenToWorldPoint(new Vector3(initialPos.x, initialPos.y,1));
            outerCircle.position = Camera.main.ScreenToWorldPoint(new Vector3(initialPos.x, initialPos.y, 1));
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
            //
        }
        if(Input.GetMouseButton(0))
        {
            touchStart = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            touchStart = false;
            //hide joystick
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
            //
        }
    }
    void movePlayer(Vector2 direction)
    {
        Vector2 actualPos = transform.position;
        Vector2 nextPosition = actualPos + direction * Time.deltaTime * moveSpeed;
        Vector2 restrictedPosition = new Vector2(Mathf.Clamp(nextPosition.x, xMin, xMax),Mathf.Clamp(nextPosition.y, yMin, yMax));
        transform.position = new Vector3(restrictedPosition.x, restrictedPosition.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyLaser100")
        {
            this.health -= 100;
            if(this.health <= 0)
            {
                Die();
            }
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("player died");
        AudioSource.PlayClipAtPoint(PlayerDeathSound, Camera.main.transform.position);
        Level.instance.LoadGameOver();
    }
    private void Fire()
    {

        
        if (Input.GetButtonDown("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            firingCoroutine = StartCoroutine(fireContiniously());
        }
    }
    private IEnumerator fireContiniously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity += new Vector2(0, laserSpeed);
            AudioSource.PlayClipAtPoint(PlayerFiringSound, Camera.main.transform.position);
            yield return new WaitForSeconds(0.05f);
        }
        
    }
    private void SetUpBoundaries()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
