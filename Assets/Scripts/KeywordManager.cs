using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeywordManager : MonoBehaviour
{
    // Create a Dictionary. The key value would be the string and the value would be the int
    // 0- stands for the value hasn't been set yet
    // 1- stands for the value has been set
    public Dictionary<string, int> keywords = new Dictionary<string, int>();

    [SerializeField] private int level;

    [SerializeField] private SpriteState spriteState;

 public   SpriteRenderer spriteRenderer;
 public Sprite sprite1;


    // Start is called before the first frame update
    void Start()
    {
        var something = gameObject.GetComponent<TextMesh>();
        // Add the keywords to the dictionary
        if (level == 1)
        {
            keywords.Add("f", 0);
            keywords.Add("o", 0);
            keywords.Add("r", 0);
            keywords.Add("m", 0);
        }
        else if (level == 2)
        {
            keywords.Add("i", 0);
            keywords.Add("n", 0);
            keywords.Add("p", 0);
            keywords.Add("u", 0);
            keywords.Add("t", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(keywords["f"] == 1)
        {


        }

    }
}
