using System.Collections;
using System.Collections.Generic;
using Controllers;
using JetBrains.Annotations;
using UnityEngine;

public class RestartController : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _player;
    [SerializeField] private DrawController _draw;
    [SerializeField] private GameObject _newGameView;

    [UsedImplicitly]
    public void RestartGame()
    {
        Instantiate(_prefab, _player.transform);
    }

    public void StartDraw()
    {
        if (_draw.enabled == false)
        {
            _draw.enabled = true;
        }
    }

    public void StartNewGame()
    {
        _newGameView.SetActive(false);
    }
}