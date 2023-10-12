using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherMovementController : MonoBehaviour
{
    [SerializeField] Transform teacherTransform;

    [SerializeField] float movementSpeed = 3.0f;

    private int currentTargetPos;

    private List<Transform> WayPoints;
    // Start is called before the first frame update
    void Start()
    {
        WayPoints = new List<Transform>();
        WayPoints.Add(GameObject.Find("TeacherMovementWaypoint1").transform);
        WayPoints.Add(GameObject.Find("TeacherMovementWaypoint2").transform);
        WayPoints.Add(GameObject.Find("TeacherMovementWaypoint3").transform);

        currentTargetPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        teacherTransform.position = Vector3.MoveTowards(teacherTransform.position, WayPoints[currentTargetPos].position, movementSpeed * Time.deltaTime);
        teacherTransform.LookAt(WayPoints[currentTargetPos].position);

        updateTargetPosition();
    }

    void updateTargetPosition()
    {
        if (teacherTransform.position == WayPoints[currentTargetPos].position)
        {
            currentTargetPos++;
        }

        if (currentTargetPos > 2)
        {
            currentTargetPos = 0;
        }
    }
}
