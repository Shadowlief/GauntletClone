using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/18/2024]
 * [Script that handles the player's shooting]
 */

public class PlayerShoot : MonoBehaviour
{
    private PlayerController _playerController;
    private PlayerData _playerData;

    [SerializeField] private GameObject _projectile;

    private bool _canShoot = true;
    [SerializeField] private float _fireRate = .5f;

    private void OnEnable()
    {
        _playerController = GetComponent<PlayerController>();
        _playerData = GetComponent<PlayerData>();
    }

    private void Update()
    {
        HandledShot();
    }

    private void HandledShot()
    {
        if (_playerController.shoot && _canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        _canShoot = false;
        Debug.Log("Bang");
        yield return new WaitForSeconds(_fireRate);
        _canShoot = true;
    }
}
