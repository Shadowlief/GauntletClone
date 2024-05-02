using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/25/2024]
 * [Script for camera movement]
 */

public class CameraFallow : MonoBehaviour
{
    [SerializeField] private GameObject fallowObject;

    /// <summary>
    /// fallows player
    /// </summary>
    void Update()
    {
        transform.position = new Vector3(fallowObject.transform.position.x, fallowObject.transform.position.y, transform.position.z);
    }
}
