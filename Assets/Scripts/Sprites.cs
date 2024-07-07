using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprites : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    void LateUpdate()
    {
        Vector3 cameraPosition = _mainCamera.transform.position;
        cameraPosition.y = transform.position.y;
        transform.LookAt(cameraPosition);
        transform.Rotate(0f, 180f, 0f);
    }
}
