using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private GameObject _finish;
    
    public void Finish()
    {
        _finish.SetActive(true);
    }
    
}
