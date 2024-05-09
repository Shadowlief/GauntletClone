using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/08/2024]
 * [Script that handles the magic]
 */

public class PlayerMagic : MonoBehaviour
{
    private PlayerController _playerController;
    private PlayerData _playerData;
    private PlayerInventory _playerInventory;

    [SerializeField]private Camera _camera;

    private bool _canUsePotion = true;

    private void OnEnable()
    {
        _playerController = GetComponent<PlayerController>();
        _playerData = GetComponent<PlayerData>();
        _playerInventory = GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (_playerController.hasChosenClass)
        {
            HandleMagic();
        }
    }

    private void HandleMagic()
    {
        //Debug.Log(_playerInventory.numOfPotions);
        if (_playerController.usePotion && _canUsePotion && _playerInventory.numOfPotions > 0)
        {
            StartCoroutine(ThrowPotion());
        }
    }

    private IEnumerator ThrowPotion()
    {
        _canUsePotion = false;
        _playerInventory.UsePotion();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Plane[] cameraFrustum = GeometryUtility.CalculateFrustumPlanes(_camera);
        foreach (GameObject enemy in enemies)
        {
            var bounds = enemy.GetComponent<Collider>().bounds;
            if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds) && enemy.GetComponent<EnemeyHealthScript>())
            {
                EnemeyHealthScript health = enemy.GetComponent<EnemeyHealthScript>();

                health.Damage(_playerData.currentMagicStrength * 2);
            }
        }

        yield return new WaitForSeconds(1.5f);
        _canUsePotion = true;
    }
}
