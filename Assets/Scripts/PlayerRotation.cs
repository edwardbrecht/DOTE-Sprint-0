using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private float z;
    private float x;
    public float yaw;
    public float TargetYaw;
    //Do not set speed to values that do divide 45 evenly
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //grabs the input axis of keys
        z = Input.GetAxisRaw("Vertical");
        x = Input.GetAxisRaw("Horizontal");

        //sets the target angle of rotation to end at
        switch (z) {
            case 1 :
                switch (x) {
                case 1 :
                    TargetYaw = 45f;
                    break;
                case -1 :
                    TargetYaw = -45f;
                    break;
                case 0 :
                    TargetYaw = 0f;
                    break;
                }
                break;
            case -1 :
                switch (x) {
                case 1 :
                    TargetYaw = 135f;
                    break;
                case -1 :
                    TargetYaw = -135f;
                    break;
                case 0 :
                    TargetYaw = 180f;
                    break;
                }
                break;
            case 0 :
                switch (x) {
                case 1 :
                    TargetYaw = 90f;
                    break;
                case -1 :
                    TargetYaw = -90f;
                    break;
                case 0 :
                    break;
                }
                break;
        }

        //current value of yaw that is used for calculations (0 < yaw <= 360)
        yaw = transform.rotation.eulerAngles[1];

        //Checks if yaw is not at the target direction
        if (yaw != TargetYaw) {
            //calculates the change (delta) in direction until the targeted yaw position, takes the path of least distance to target
            float delta = ((TargetYaw <= 0 ? 360 + TargetYaw : TargetYaw) - yaw);
            if (delta > 180)
                delta = delta - 360;
            else if (delta < -180)
                delta = 360f + delta;

            //actually rotates at rate speed, goes in direction indicated by delta
            if (delta > 0) {
                transform.Rotate(0, speed, 0);
            } else {
                transform.Rotate(0, -speed, 0);
            }
        }
    }
}
