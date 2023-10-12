using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementForBungee : MonoBehaviour
{
	Rigidbody rb;
	[SerializeField] float movementSpeed = 5f;
	GameObject player;
	public GameObject line;
	public Transform target;
	public GameObject student;

	void Start()
    {
		rb = GetComponent<Rigidbody>();
		player = GameObject.Find("Teacher");
	}

	void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		float distance = Vector3.Distance(player.transform.position, transform.position);
	
		if (distance <= 8f)
		{
			Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
			movementDirection.Normalize();

			transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.World);
		}

		if (distance > 8f && distance <= 10f)
		{
			Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
			movementDirection.Normalize();

			transform.Translate(movementDirection * movementSpeed * 0.3f * Time.deltaTime, Space.World);

			//Debug.DrawLine(this.transform.position, target.transform.position, Color.red, 2, false);
		}
		
		if (distance > 10f && distance < 12f)
		{
			Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
			movementDirection.Normalize();

			student.transform.position = Vector3.MoveTowards(student.transform.position, target.transform.position, movementSpeed *2f * Time.deltaTime);

			//Debug.DrawLine(this.transform.position, target.transform.position, Color.red, 2, false);
		}
		
	}
}
