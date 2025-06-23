using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform ballTransform;
    public Vector3 positionOffset = new(0, 4, -5);


    void Start()
    {
        // instead of referencing this script during instantiation to set ballTransform, retrieve it using Tag. i have no idea if its a bad pattern.
        ballTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = ballTransform.position + positionOffset;
    }
}
