using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
   // [SerializeField] private float padding = 10f;
    [SerializeField] private bool windowInFocus = true;

    private Camera cam;
    private float targetZoom;
    [SerializeField] private float zoomFactor = 50f;
    [SerializeField] private float zoomLerpSpeed = 10f;
 
    private void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    void Update()
    {
        // Refactor or remove later (Constraining inputs when coursore is out of bound)
        //Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
        //if (!screenRect.Contains(Input.mousePosition))
        //    return;
        
        // Escape menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            windowInFocus = !windowInFocus;
            // TODO: Escape menu
        }

        if (!windowInFocus)
        {
            return;
        }

        // Pause menu
        if (Input.GetKey(KeyCode.P))
        {
            // TODO: Pause 
        }

        // Zoom logic
        float zoomAxis = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= zoomAxis * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, 10, 50);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoom, ref zoomAxis, Time.deltaTime * zoomLerpSpeed);

        // Camera movement logic                                         Add code for mouse movement later.
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // || Input.mousePosition.y >= Screen.height - padding
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // || Input.mousePosition.y <= padding
        {
            transform.Translate(-Vector2.up * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // || Input.mousePosition.x <= padding
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // || Input.mousePosition.x >= Screen.width - padding
        {
            transform.Translate(-Vector2.left * Time.deltaTime * speed, Space.World);
        }
    }
}
