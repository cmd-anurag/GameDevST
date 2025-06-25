using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallInput : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    Vector3 inputDirecion;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        inputDirecion = new Vector3(horizontal, 0, vertical).normalized;
    }

    void FixedUpdate()
    {
        rb.AddForce(speed * inputDirecion, ForceMode.Force);
    }
}