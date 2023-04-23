using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWayMove : MonoBehaviour
{
    public float distance;
    public NewWaypoint waypoints;

    public float moveSpeed = 5f;

   private Transform currentWayPoint;


    // Start is called before the first frame update
    void Start()
    {

        currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
        transform.position = currentWayPoint.position;



        currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);

    }

    private void Update()
    {

         

        transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.position, moveSpeed * Time.deltaTime);
      
        if(Vector3.Distance(transform.position, currentWayPoint.position) < distance)
        {
            currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);

        }
    }




}

