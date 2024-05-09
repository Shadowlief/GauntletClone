using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/09/2024]
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

    /// <summary>
    /// gets componetns
    /// </summary>
    private void OnEnable()
    {
        _playerController = GetComponent<PlayerController>();
        _playerData = GetComponent<PlayerData>();
    }

    /// <summary>
    /// calls to handle shot every frame
    /// </summary>
    private void Update()
    {
        if (_playerController.hasChosenClass)
        {
            HandledShot();
        }
    }

    /// <summary>
    /// calls to start coroutine to shoot when can
    /// </summary>
    private void HandledShot()
    {
        if (_playerController.shoot && _canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    /// <summary>
    /// makes shot gameobject and sets it
    /// </summary>
    /// <returns></returns>
    private IEnumerator Shoot()
    {
        _canShoot = false;

        Vector3 spawn = transform.position + (transform.up * _spawnFrom);
        GameObject projectile = Instantiate(_projectile, spawn, transform.rotation);
        projectile.GetComponent<PlayerProjectileScript>().SetUp(_playerData.currentShotSpeed, _playerData.currentShotStrength, _playerData.currentMagicStrength);

        yield return new WaitForSeconds(_fireRate);
        _canShoot = true;
    }
}
