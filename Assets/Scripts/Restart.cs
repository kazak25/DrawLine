using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _player;
    // Start is called before the first frame update
    public void RestartGame()
    {
        Instantiate(_prefab, _player.transform);
    }   
}
