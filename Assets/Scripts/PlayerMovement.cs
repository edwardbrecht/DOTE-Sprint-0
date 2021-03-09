using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float up;
    private float right;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        up = Input.GetAxisRaw("Vertical");
        right = Input.GetAxisRaw("Horizontal");

        transform.TransformDirection(Vector3.forward);
        transform.Translate(right * speed * Time.deltaTime, 0, up * speed * Time.deltaTime, Space.World);


    }
}
