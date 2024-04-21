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
    [SerializeField] private float _spawnFrom = .75f;

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

        Vector3 spawn = transform.position + (transform.up * _spawnFrom);
        GameObject projectile = Instantiate(_projectile, spawn, transform.rotation);
        projectile.GetComponent<PlayerProjectileScript>().SetUp(_playerData.currentShotSpeed, _playerData.currentShotStrength);

        yield return new WaitForSeconds(_fireRate);
        _canShoot = true;
    }
}
