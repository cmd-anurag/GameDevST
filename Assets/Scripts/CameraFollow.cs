using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform ballTransform;
    public Vector3 positionOffset;


    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            ballTransform = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player object with tag 'Player' not found in the scene.");
        }

    }

    void Update()
    {
        transform.position = ballTransform.position + positionOffset;
    }
}
