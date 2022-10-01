using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currWayPt = 0;
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        if(Vector2.Distance(waypoints[currWayPt].transform.position,transform.position)<.1f)
        {
            currWayPt++;
            if(currWayPt>=waypoints.Length)
            {
                currWayPt = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currWayPt].transform.position, Time.deltaTime * speed);
    }
}
