using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentMovement : MonoBehaviour
{

    [SerializeField] Rigidbody myRigidBody;
    [SerializeField] int myVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, myRigidBody.velocity.y, myVelocity);
        }

        if (Input.GetKey("down"))
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, myRigidBody.velocity.y, -myVelocity);
        }

        if (Input.GetKey("right"))
        {
            myRigidBody.velocity = new Vector3(myVelocity, myRigidBody.velocity.y, myRigidBody.velocity.z);
        }

        if (Input.GetKey("left"))
        {
            myRigidBody.velocity = new Vector3(-myVelocity, myRigidBody.velocity.y, myRigidBody.velocity.z);
        }
    }
}
