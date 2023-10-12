using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineRenderer : MonoBehaviour
{
	public GameObject objectOne;    // The first object you instantiate
	public GameObject objectTwo;    // The second object you instantiate

	public LineRenderer lineRend;   // The linerenderer component, remember to assign this in the inspector!

	void Start()
	{
		// Set the position count of the linerenderer to two
		lineRend.positionCount = 2;

		// Instantiate the two objects
		//objectOne = Instantiate(objectOne, objectOne.transform.position, Quaternion.identity);
		//objectTwo = Instantiate(objectTwo, objectTwo.transform.position, Quaternion.identity);

		// Get the transform of the two objects
		Transform first = objectOne.transform;
		Transform second = objectTwo.transform;

		//DrawLineBetweenObjects(first, second);
	}

	void DrawLineBetweenObjects(Transform firstT, Transform secondT)
	{
		// Set the positions of the LineRenderer
		lineRend.SetPosition(0, firstT.position);
		lineRend.SetPosition(1, secondT.position);
	}

	void Update()
    {
		float distance = Vector3.Distance(objectOne.transform.position, transform.position);
		line();
		/*if (distance >= 10f)
		{
			line();
		}*/

	}
	public void line()
	{
		List<Vector3> pos = new List<Vector3>();
		pos.Add(objectOne.transform.position);
		pos.Add(objectTwo.transform.position);
		//GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 1f, 1f, 0.01f));
		lineRend.startWidth = 0.1f;
		lineRend.endWidth = 0.1f;
		lineRend.SetPositions(pos.ToArray());
		lineRend.useWorldSpace = true;
	}
}
