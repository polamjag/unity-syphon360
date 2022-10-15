using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManipulator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")) {
            Camera.main.transform.Rotate(Vector3.left, 20.0f * Time.deltaTime);
        }
        if (Input.GetKey("a")) {
            Camera.main.transform.Rotate(Vector3.down, 20.0f * Time.deltaTime);
        }
        if (Input.GetKey("s")) {
            Camera.main.transform.Rotate(Vector3.right, 20.0f * Time.deltaTime);
        }
        if (Input.GetKey("d")) {
            Camera.main.transform.Rotate(Vector3.up, 20.0f * Time.deltaTime);
        }

        if (Input.GetKey("q")) {
            Camera.main.transform.Rotate(Vector3.forward, 20.0f * Time.deltaTime);
        }
        if (Input.GetKey("e")) {
            Camera.main.transform.Rotate(Vector3.back, 20.0f * Time.deltaTime);
        }

        if (Input.GetKey("t")) {
            Camera.main.fieldOfView *= 0.9994f;
        }
        if (Input.GetKey("y")) {
            Camera.main.fieldOfView *= 1.0004f;
        }
    }
}
