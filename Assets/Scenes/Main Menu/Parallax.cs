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
    [SerializeField] private Vector2 parrallaxEffectMultiplier;

    private float textureUnitSizeX;

    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastcameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;


    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //Update the parallax effect automatically

        Vector3 deltaMovement = cameraTransform.position - lastcameraPosition;
        transform.position += new Vector3(deltaMovement.x * parrallaxEffectMultiplier.x, deltaMovement.y * parrallaxEffectMultiplier.y);
        lastcameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y, transform.position.z);
        }
    }
}
