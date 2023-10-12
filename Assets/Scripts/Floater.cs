using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frecuency = 1f;

    public Transform objectToFollow;
    public Vector3 offset;

    Vector3 posOffset = new Vector3();
    Vector3 temPos = new Vector3();

    //public Transform player;     <- player = objectToFollow
    public Transform teacher;
    public GameObject dome;

    private Rigidbody rb;

    public Transform cameraTransform;
    public float distanceFromCamera;

    void Start()
    {
        posOffset = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        temPos = posOffset;
        temPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frecuency) * amplitude;

        // Input to obtain dist
        Vector3 domeScale = dome.transform.localScale;
        float radius = (domeScale.x) / 2f;
        float dist = Vector3.Distance(objectToFollow.position, teacher.position);

        Vector3 resultingPosition = cameraTransform.position + cameraTransform.forward * distanceFromCamera;

        if (dist >= 7f)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            temPos.x = resultingPosition.x;
            temPos.z = resultingPosition.z;
            transform.position = temPos + offset; // used to be: transform.position = temPos + offset;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
