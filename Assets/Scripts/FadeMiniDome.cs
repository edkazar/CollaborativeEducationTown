using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMiniDome : MonoBehaviour
{
    public Transform student;
    public Transform teacher;
    public GameObject dome;
    [SerializeField] Material domeMaterial;

    void Update()
    {
        Vector3 domeScale = dome.transform.localScale;
        float radius = (domeScale.x) / 2f;

        float dist = Vector3.Distance(teacher.position, student.position);
        float alphaNumber = dist / 10f;

        Color colorOne = new Color (0, 0, 0, 0);
        Color colorTwo = new Color(1, 1, 1, alphaNumber);

        if (dist < radius - 0.5f)
        {
            domeMaterial.SetColor("_Color", colorOne); //THIS IS THE GOOD ONE
        }
        else
        {
            domeMaterial.SetColor("_Color", colorTwo);
        }
    }
}
