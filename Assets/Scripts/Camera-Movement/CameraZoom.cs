using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Adds a zoom to the camera.
 */
public class CameraZoom : MonoBehaviour
{

    float zoomSpeed = 25f;
    float scrollData;
    float target;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        target = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        scrollData = Input.GetAxis("Mouse ScrollWheel");

        target -= scrollData * zoomSpeed;
        target = Mathf.Clamp(target, 10, 100);

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, target, Time.deltaTime * 10);
    }
}
