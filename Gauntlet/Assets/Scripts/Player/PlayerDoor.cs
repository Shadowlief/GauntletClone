using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/09/2024]
 * [Script that handles running into the doors]
 */

public class PlayerDoor : MonoBehaviour
{
    private PlayerInventory _playerInventory;

    private void OnEnable()
    {
        _playerInventory = transform.parent.gameObject.GetComponent<PlayerInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            if (_playerInventory.numOfKeys > 0)
            {
                Destroy(other.gameObject);
                _playerInventory.UseKey();
            }
        }
    }
}
