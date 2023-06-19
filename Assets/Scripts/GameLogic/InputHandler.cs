using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Screen movement:")]
    [SerializeField] private float speed = 50f;
    //[SerializeField] private float padding = 10f;
    //[SerializeField] private float padding = 10f;

    [Header("Zoom controls:")]
    [SerializeField] private float zoomFactor = 50f;
    [SerializeField] private float zoomLerpSpeed = 10f;

    private float targetZoom;
    private Camera cam;

    [Header ("Camera boundaries:")]
    [SerializeField] private float leftLimit = -50f;
    [SerializeField] private float rightLimit = 130f;
    [SerializeField] private float topLimit = 135f;
    [SerializeField] private float bottomLimit = -60f;

    private void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    void Update()
    {
        if (GameContoller.gameOver)
        {
            enabled = false;
            return;
        }


        // Limit camera movement to set boundaries
        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit), 
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit), 
            transform.position.z
            );

        // Zoom logic
        float zoomAxis = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= zoomAxis * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, 10, 45);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoom, ref zoomAxis, Time.deltaTime * zoomLerpSpeed);

        // Camera movement logic
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) //|| Input.mousePosition.y >= Screen.height - padding
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) //|| Input.mousePosition.y <= padding
        {
            transform.Translate(-Vector2.up * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //|| Input.mousePosition.x <= padding
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //|| Input.mousePosition.x >= Screen.width - padding
        {
            transform.Translate(-Vector2.left * Time.deltaTime * speed, Space.World);
        }
    }

    // Draw camera boundaries according to set limits
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
    }
}
