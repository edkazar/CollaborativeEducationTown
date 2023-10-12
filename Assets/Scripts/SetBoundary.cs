using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoundary : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform teacher;
    [SerializeField] GameObject dome;

    void Update()
    {
        Vector3 domeScale = dome.transform.localScale;
        float radius = (domeScale.x) / 2f;
        float dist = Vector3.Distance(player.position, teacher.position);

        //This "if" cicle prevents the student to walk past the boundary
        if (dist > radius)
        {
            Vector3 fromOriginToObject = player.position - teacher.position;
            fromOriginToObject *= radius / dist;
            player.position = teacher.position + fromOriginToObject;
            transform.position = player.position;
        }
    }
}
