using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField] Camera camera;
    [SerializeField] float speedMoveCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPosition = camera.transform.position;
        if(camPosition.x > -5.9)
        {
            camera.transform.position = new Vector3(camPosition.x - speedMoveCamera * Time.deltaTime, camPosition.y, camPosition.z);
        }
        if (camPosition.x < -3 && speedMoveCamera > 0)
        {
            speedMoveCamera -= 0.001f * Time.deltaTime;
        }

    }
}
