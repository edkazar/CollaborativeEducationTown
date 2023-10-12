using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassController : MonoBehaviour
{
    public GameObject player;
    public Transform[] waypoints;
    private int currentWaypointIndex;

    public float detectionDistance = 3f;

    public float rotationSpeed = 3f;

    private Transform arrowPivot;

    void Start()
    {
        waypoints = new Transform[4];
        waypoints[0] = GameObject.Find("Waypoint0").transform;
        waypoints[1] = GameObject.Find("Waypoint1").transform;
        waypoints[2] = GameObject.Find("Waypoint2").transform;
        waypoints[3] = GameObject.Find("Waypoint3").transform;

        currentWaypointIndex = 0;
        arrowPivot = transform.Find("ArrowPivot");
    }

    void Update()
    {
        Vector3 direction = waypoints[currentWaypointIndex].position - player.transform.position;
        direction.y = 0f; //ensure the direction is horizontal

        //check if the player is within the detection distance of the current waypoint
        if (direction.magnitude <= detectionDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                gameObject.SetActive(false);
                return;
            }
        }

        //rotate the arrow pivot towards the current waypoint
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion finalRotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f); //lock rotation in Y
        arrowPivot.rotation = Quaternion.Slerp(arrowPivot.rotation, finalRotation, rotationSpeed * Time.deltaTime);

        //update the position of the compass relative to the player
        transform.position = player.transform.position;
    }
}
