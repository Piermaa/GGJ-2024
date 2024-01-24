using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothFactor;

    void FixedUpdate()
    {

        following();

    }

    void following()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothCamera = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);

        transform.position = smoothCamera;
    }
}
