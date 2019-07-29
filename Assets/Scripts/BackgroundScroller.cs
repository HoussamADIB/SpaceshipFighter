using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    //--------------------------------------------------------------Properties
    [SerializeField] float speed;
    //--------------------------------------------------------------Functions
    private void Start()
    {
        
    }
    private void Update()
    {
        Material material = GetComponent<Renderer>().material;
        material.mainTextureOffset += new Vector2(0,speed * Time.deltaTime);
    }
}
