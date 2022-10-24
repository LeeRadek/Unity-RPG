using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public float pitch = 2f;

    public float zoomSpeed = 4f;
    public float minZoomSpeed = 5f;
    public float maxZoomSpeed = 15f;

    public float yawSpeed = 100f;
    private float currentYaw = 0f;

    private float currentZoom = 10;

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoomSpeed, maxZoomSpeed);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
