using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _win;


    public void Finish()
    {
        _win.text = "YOU WIN!";
    }
}
