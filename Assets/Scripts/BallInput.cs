using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInput : MonoBehaviour
{
    public float speed = 3.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = speed * Time.deltaTime * new Vector3(horizontal, 0, vertical);
        Rigidbody rb = GetComponent<Rigidbody>();
        
        rb.AddForce(movement, ForceMode.Impulse);
    }
}