using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    public Transform student;
    public Transform teacher;
    [SerializeField] Material objectMaterial;

    void Update()
    {
        float dist = Vector3.Distance(teacher.position, student.position);
        float alphaNumber = dist / 50f; //line = 50f
        Color mainColor = new Color(1, 1, 1, alphaNumber);

        objectMaterial.SetColor("_Color", mainColor);

    }
}
