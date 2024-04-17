using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/16/2024]
 * [Script to pick up item on trigger enter]
 */

public class PickUp : MonoBehaviour
{
    [SerializeField] private Item _item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerVisitorController>())
        {
            other.GetComponent<PlayerVisitorController>().Accept(_item);
            Destroy(gameObject);
        }
    }
}
