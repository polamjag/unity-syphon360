using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

enum CameraRotateOperation
{
    Incr, Decr, ZeroConverge

}


public class CameraManipulator : MonoBehaviour
{
    private const float GLOBAL_RATE = 0.00004f;

    private float lrSpeed = 0.0f;
    private float udSpeed = 0.0f;

    private float ChangeSpeed(float current, CameraRotateOperation op, float rate)
    {
        if ((current > 3.0f && op == CameraRotateOperation.Incr) || (current < -3.0f && op == CameraRotateOperation.Decr))
        {
            return current;
        }

        switch (op) {
            case CameraRotateOperation.Incr:
                return current + rate;
            case CameraRotateOperation.Decr:
                return current - rate;
            case CameraRotateOperation.ZeroConverge:
                return current * rate;
            default:
                return current;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Camera.main.transform.Rotate(Vector3.left, lrSpeed * Time.deltaTime);
        Camera.main.transform.Rotate(lrSpeed, udSpeed, 0f);

        if (Input.GetKey("w"))
        {
            lrSpeed = ChangeSpeed(lrSpeed, CameraRotateOperation.Decr, GLOBAL_RATE);
        }
        if (Input.GetKey("a"))
        {
            udSpeed = ChangeSpeed(udSpeed, CameraRotateOperation.Incr, GLOBAL_RATE);
        }
        if (Input.GetKey("s"))
        {
            lrSpeed = ChangeSpeed(lrSpeed, CameraRotateOperation.Incr, GLOBAL_RATE);
        }
        if (Input.GetKey("d"))
        {
            udSpeed = ChangeSpeed(udSpeed, CameraRotateOperation.Decr, GLOBAL_RATE);
        }

        if (Input.GetKey("1")) {
            lrSpeed = ChangeSpeed(lrSpeed, CameraRotateOperation.ZeroConverge, GLOBAL_RATE);
            udSpeed = ChangeSpeed(udSpeed, CameraRotateOperation.ZeroConverge, GLOBAL_RATE);
        }

        if (Input.GetKey("q"))
        {
            Camera.main.transform.Rotate(Vector3.forward, 20.0f * Time.deltaTime);
        }
        if (Input.GetKey("e"))
        {
            Camera.main.transform.Rotate(Vector3.back, 20.0f * Time.deltaTime);
        }

        if (Input.GetKey("t"))
        {
            Camera.main.fieldOfView *= 0.9994f;
        }
        if (Input.GetKey("y"))
        {
            Camera.main.fieldOfView *= 1.0004f;
        }

        var gamepad = Gamepad.current;
        if (gamepad == null)
        {
            // return; // No gamepad connected.
        }
        else
        {
            if (gamepad.buttonEast.isPressed)
            {
                // 'Use' code here
                lrSpeed = ChangeSpeed(lrSpeed, CameraRotateOperation.ZeroConverge, 0.998f);
                udSpeed = ChangeSpeed(udSpeed, CameraRotateOperation.ZeroConverge, 0.998f);
            }

            Vector2 move = gamepad.leftStick.ReadValue();
            {
                lrSpeed = ChangeSpeed(lrSpeed, CameraRotateOperation.Incr, GLOBAL_RATE * move.y);
                udSpeed = ChangeSpeed(udSpeed, CameraRotateOperation.Decr, GLOBAL_RATE * move.x);
            }
        }
    }
}
