using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{

    private bool isThisBlock = false;
    private bool lessDestroy = false;

   

    private void Update()
    {
        if (lessDestroy)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        }
        if (transform.position.x < -100)
        {
            Destroy(gameObject);
            lessDestroy = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.gameObject.tag);
            isThisBlock = true;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (isThisBlock && Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Destroy");
            lessDestroy = true;
            isThisBlock = false;
        }

        // if(collision.gameobject.tag)

    }


}
