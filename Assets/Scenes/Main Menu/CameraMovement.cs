using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /// Move the camera on the x axis per second 
        transform.position += new Vector3(0.25f,0.0f) * Time.deltaTime;

    }
}
