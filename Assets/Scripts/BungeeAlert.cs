using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BungeeAlert : MonoBehaviour
{
    public Transform student;
    public Transform teacher;
    //public GameObject dome;
    [SerializeField] float radius = 20f;

    [SerializeField] AudioSource warningSound;
    bool soundPlayed;

    void Start()
    {
        soundPlayed = false;
    }


    void Update()
    {
        //Vector3 domeScale = dome.transform.localScale;
        //float radius = (domeScale.x) / 2f;
        float dist = Vector3.Distance(student.position, teacher.position);

        if (!soundPlayed && dist > radius)
        {
            warningSound.Play();
            soundPlayed = true;
        } else if (soundPlayed && dist < radius)
        {
            soundPlayed = false;
        }
    }
}
