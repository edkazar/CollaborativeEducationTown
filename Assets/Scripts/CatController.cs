using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 8f;   //speed of the cat
    public float detectionDistance = 6f;  //distance at which the cat detects the player
    public float stopDistance = 12f;  //distance at which the cat stops completely

    private int currentWaypointIndex = 0;
    private Transform player;
    private Animator animator;

    private bool playerIsNearby = false;  //flag indicating if the player is nearby
    private bool waiting = false;  //flag indicating if the cat is waiting

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();

        //start the movement towards the first waypoint
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
            currentWaypointIndex = 1;
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (!playerIsNearby)
        {
            //move towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);

            if (distanceToPlayer <= detectionDistance)
            {
                playerIsNearby = true;
                animator.SetBool("IsWalking", true);
            }
        }
        else
        {
            if (!waiting && distanceToPlayer > detectionDistance)
            {
                waiting = true;
                animator.SetBool("IsSitting", true);  //cat sits down when the player is far away
            }
            else if (waiting && distanceToPlayer <= detectionDistance)
            {
                waiting = false;
                animator.SetBool("IsSitting", false);  //cat stands up when the player is nearby again
            }
        }

        // Move towards the current waypoint
        if (distanceToPlayer < stopDistance) //antes >
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
        }

        // Check if the cat has reached the last waypoint
        if (currentWaypointIndex == waypoints.Length - 1 && Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            animator.SetBool("IsWalking", false);  // Cat sits down at the last waypoint
            return;
        }

        //check if the cat has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            if (!playerIsNearby)
            {
                animator.SetBool("IsWalking", true);  // Cat starts walking towards the next waypoint
            }

            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;  //move to the next waypoint
        }

        //rotate the cat to face the movement direction
        if (waypoints.Length > 0)
        {
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
            direction.y = 0f;  // Ignore the y-axis to prevent unwanted tilting
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.5f);
            }
        }
        else
        {
            animator.SetBool("IsWalking", false);  // Cat starts walking towards the next waypoint
        }

    }
}
