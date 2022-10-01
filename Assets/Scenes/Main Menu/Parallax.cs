using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Automatic Parallax scrolling script.
/// </summary>
public class Parallax : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastcameraPosition;


    /// <summary>
    /// The parallax effect is based on the difference between the camera's current position and the position in the previous frame.
    /// </summary>
    [SerializeField] private float parrallaxEffectMultiplier = 0;

    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastcameraPosition = cameraTransform.position;

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastcameraPosition;
        transform.position += deltaMovement * parrallaxEffectMultiplier;
        lastcameraPosition = cameraTransform.position;
    }
}
