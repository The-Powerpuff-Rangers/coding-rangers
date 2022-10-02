using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeywordManager : MonoBehaviour
{
    // Create a Dictionary. The key value would be the string and the value would be the int
    // 0- stands for the value hasn't been set yet
    // 1- stands for the value has been 


    [SerializeField] private int level;

    [SerializeField] private SpriteState spriteState;

 public   SpriteRenderer spriteRenderer;
 public Sprite sprite1;

    private string[] arr = { "F", "O", "R", "M" };
    // Start is called before the first frame update
    void Start()
    {
        var something = gameObject.GetComponent<TextMesh>();
        // Add the keywords to the dictionary
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string currStr = collision.gameObject.tag;
       // for(int i=0;i<4;i++)
        //{
          //  if(currStr != arr[i])
           // {
                
           // }
       // }
    }
}
