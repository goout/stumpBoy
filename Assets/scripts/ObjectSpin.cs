using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpin : MonoBehaviour
{

    [SerializeField] private int spinX = 0, spinY = 0, spinZ = 0;

    void Update()
    {
        transform.Rotate(spinX, spinY, spinZ);
    }
}
