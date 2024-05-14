using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/13/2024]
 * [Singleton to manage player (also UI stuff)]
 */

public class PlayerManager : Singleton<PlayerManager>
{
    private Dictionary<ClassEnum, bool> _availableClasses = new Dictionary<ClassEnum, bool>();
    private List<GameObject> _currentPlayers = new List<GameObject>();
    private int[] _finalScores = new int[4];

    [SerializeField] private Camera _startCamera;

    //UI stuff
    private TMP_Text[] playerText = new TMP_Text[4];
    [SerializeField] private TMP_Text _p1Text;
    [SerializeField] private TMP_Text _p2Text;
    [SerializeField] private TMP_Text _p3Text;
    [SerializeField] private TMP_Text _p4Text;

    [SerializeField] private GameObject _gameOverUI;
    private bool _isGameOver = false;


    /// <summary>
    /// adds all classes to list
    /// </summary>
    private void OnEnable()
    {
        _availableClasses.Add(ClassEnum.Warrior, true);
        _availableClasses.Add(ClassEnum.Elf, true);
        _availableClasses.Add(ClassEnum.Valkarie, true);
        _availableClasses.Add(ClassEnum.Wizard, true);

        playerText[0] = _p1Text;
        playerText[1] = _p2Text;
        playerText[2] = _p3Text;
        playerText[3] = _p4Text;
    }

    private void Update()
    {
        UpdateUI();
        CheckGameOver();
    }

    /// <summary>
    /// checks if class is available to be selected
    /// </summary>
    /// <param name="check">class being checked</param>
    /// <returns>is class available</returns>
    public bool CheckAvailableClass(ClassEnum check)
    {
        return _availableClasses[check];
    }

    /// <summary>
    /// changes availability of class
    /// </summary>
    /// <param name="claim">class being claimed</param>
    public void ClaimClass(ClassEnum claim)
    {
        _availableClasses[claim] = false;
    }

    /// <summary>
    /// adds player to _current player
    /// </summary>
    /// <param name="player">player being added</param>
    public void AddPlayer(GameObject player)
    {
        _currentPlayers.Add(player);
        DontDestroyOnLoad(player.transform.root.gameObject);
        if (_startCamera.enabled)
        {
            _startCamera.enabled = false;
        }
    }

    /// <summary>
    /// returns the first player that is alive
    /// </summary>
    /// <returns>gameobject of first player alive</returns>
    public GameObject GetFirstAlivePlayer()
    {
        for (int index = 0; index < _currentPlayers.Count; index++)
        {
            if (_currentPlayers[index] != null)
            {
                return _currentPlayers[index];
            }
        }
        return null;
    }

    /// <summary>
    /// updates ui
    /// </summary>
    public void UpdateUI()
    {
        for (int i = 0; i < _currentPlayers.Count; i++)
        {
            //change later so not destroyed
            if (_currentPlayers[i] != null)
            {
                playerText[i].text = "Player " + (i + 1) + ": Health: " + _currentPlayers[i].GetComponent<PlayerData>().currentHp + " Score: " + _currentPlayers[i].GetComponent<PlayerScore>().currentScore;
            }
            else
            {
                playerText[i].text = "Player " + (i + 1) + ": Health: DEAD Score: " + _finalScores[i];
            }
        }
    }

    public void CheckGameOver()
    {
        if (_currentPlayers.Count > 0)
        {
            bool gameOver = true;
            for (int i = 0; i < _currentPlayers.Count; i++)
            {
                if (_currentPlayers[i] != null)
                {
                    gameOver = false;
                }
            }

            if (gameOver)
            {
                _startCamera.enabled = true;
                _gameOverUI.SetActive(true);
                _isGameOver = true;
            }
        }
    }

    public void OnReset()
    {
        _gameOverUI.SetActive(false);
        _currentPlayers = new List<GameObject>();
        _finalScores = new int[4];

        for (int i = 0; i < playerText.Length; i++)
        {
            playerText[i].text = "Player " + (i + 1) + ": Press Esc or Y to Enter";
        }

        _availableClasses[ClassEnum.Warrior] = true;
        _availableClasses[ClassEnum.Valkarie] = true;
        _availableClasses[ClassEnum.Elf] = true;
        _availableClasses[ClassEnum.Wizard] = true;

        _isGameOver = false;
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void UpdateFinalScore(GameObject player, int score)
    {
        _finalScores[_currentPlayers.IndexOf(player)] = score;
    }

    //gets player count
    public int GetPlayerCount()
    {
        return _currentPlayers.Count;
    }

    public bool isGameOver
    {
        get { return _isGameOver; }
    }
}
