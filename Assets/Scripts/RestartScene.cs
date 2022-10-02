using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("It may Works");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("It Works");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
