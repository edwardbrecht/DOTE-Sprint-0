using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xDirection;
    private float yDirection;
    private float xMovement;
    private float yMovement;
    private Vector3 movement;
    private Ray lookRay;
    private RaycastHit rayHit;
    private Vector3 lookPosition;

    public float speedScale;
    public Camera mainCamera;
    public float cameraDistance;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // I don't know if it will really matter using FixedUpdate vs Update. Update is called once per frame, FixedUpdate can be called 0, 1, or several times per frame
    private void FixedUpdate()
    {
        // Player movement using Unity's input manager thing, add speed to direction for the x,y directions, make vector and apply to characters Translate
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
        xMovement = xDirection * speedScale * Time.deltaTime;
        yMovement = yDirection * speedScale * Time.deltaTime;

        movement = new Vector3(xMovement, 0, yMovement);
        transform.Translate(movement, Space.World);

        // Camera follows character with some offset so it's centered and not too close, angle of camera and distance can be changed so it looks nicer
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + cameraDistance, this.transform.position.z - cameraDistance);
        }

        // Character looks at where mouse cursor is, as long as the cursor is not in the void (A ray is shot from the camera and hits a point in the world, character looks at that point)
        lookRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(lookRay, out rayHit))
        {
            lookPosition = new Vector3(rayHit.point.x, this.transform.position.y, rayHit.point.z);
            this.transform.LookAt(lookPosition);
            
        }

        
    }
}
