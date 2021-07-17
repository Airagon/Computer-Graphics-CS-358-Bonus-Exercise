using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotareBar : MonoBehaviour
{
    public float rotateSpeed = 5.0f;

    void Update()
    {
       transform.Rotate(0.0f, rotateSpeed * Time.deltaTime, 0.0f); 
    }
}
