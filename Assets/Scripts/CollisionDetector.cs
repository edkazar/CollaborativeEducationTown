using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Student"))
        {
            Debug.Log("student inside the dome");
        }
    }

    private void OnTrigger(Collider other)
    {
        if (other.CompareTag("Student"))
        {
            Debug.Log("student outside the dome");
        }
    }
}
