using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    //--------------------------------------------------------------Functions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        //sound Laser Hit player TODO
    }
}
