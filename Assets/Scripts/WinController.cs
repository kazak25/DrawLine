using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WinController : MonoBehaviour
{
    

    public UnityEvent _Event;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Finish");
            Debug.Log(2%6);
            _Event.Invoke();
            
        }
    }
}
