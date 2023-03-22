using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Created a basic WASD camera movement system
 */
public class CameraMovement : MonoBehaviour
{

    Vector3 cPosition;
    Vector3 difference;

    bool drag;

    public float cameraSpeed = 50f;
        
    // Start is called before the first frame update
    void Start()
    {
        cPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            cPosition.x -= cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            cPosition.x += cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            cPosition.z += cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            cPosition.z -= cameraSpeed * Time.deltaTime;
        }
 

        this.transform.position = cPosition;
    }


}
