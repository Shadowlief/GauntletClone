using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/30/2024]
 * [script for selecting character]
 */

public class ClassSelect : MonoBehaviour
{
    private PlayerData _playerData;
    private PlayerController _playerController;
    private MeshRenderer _meshRenderer;

    [SerializeField] private ClassStats[] _stats = new ClassStats[4];
    [SerializeField] private Material[] _materials = new Material[4];

    private void OnEnable()
    {
        _playerData = GetComponent<PlayerData>();
        _playerController = GetComponent<PlayerController>();
        _meshRenderer = GetComponent<MeshRenderer>();

        GameObject loc = PlayerManager.Instance.GetFirstAlivePlayer();
        if (loc != null)
        {
            transform.position = loc.transform.position;
        }
    }

    private void HandleClassSelection()
    {
        ClassEnum selectedClass = ClassEnum.Warrior;
        bool hasSelected = false;

        if (_playerController.horMovement == 1 && PlayerManager.Instance.CheckAvailableClass(ClassEnum.Elf))
        {
            //elf
            selectedClass = ClassEnum.Elf;
            _playerData.SetStats(_stats[0]);
            _meshRenderer.material = _materials[0];
            hasSelected = true;
        }
        else if (_playerController.horMovement == -1 && PlayerManager.Instance.CheckAvailableClass(ClassEnum.Valkarie))
        {
            //valk
            selectedClass = ClassEnum.Valkarie;
            _playerData.SetStats(_stats[1]);
            _meshRenderer.material = _materials[1];
            hasSelected = true;
        }
        else if (_playerController.virMovement == 1 && PlayerManager.Instance.CheckAvailableClass(ClassEnum.Warrior))
        {
            //war
            selectedClass = ClassEnum.Warrior;
            _playerData.SetStats(_stats[2]);
            _meshRenderer.material = _materials[2];
            hasSelected = true;
        }
        else if (_playerController.virMovement == -1 && PlayerManager.Instance.CheckAvailableClass(ClassEnum.Wizard))
        {
            //wiz
            selectedClass = ClassEnum.Wizard;
            _playerData.SetStats(_stats[3]);
            _meshRenderer.material = _materials[3];
            hasSelected = true;
        }

        if (hasSelected)
        {
            _playerController.ChosenClass();
            PlayerManager.Instance.ClaimClass(selectedClass);
            PlayerManager.Instance.AddPlayer(gameObject);
        }
    }

    /// <summary>
    /// waits for a character select first
    /// </summary>
    private void Update()
    {
        if (!_playerController.hasChosenClass)
        {
            HandleClassSelection();
        }
    }
}
