using UnityEngine;
using UnityEngine.Events;

namespace Controllers
{
    public class WinController : MonoBehaviour
    {
        public UnityEvent WinEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                WinEvent.Invoke();
            }
        }
    }
}