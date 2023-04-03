using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

namespace Player
{
    public class PlayerBehavior : MonoBehaviour
    {
        public UnityEvent Death;

        [SerializeField] private Animator _controller;

        private const string Enemy = "Box";


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(Enemy))
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.transform.SetParent(null);
                gameObject.GetComponent<RigBuilder>().enabled = false;
                _controller.SetTrigger("Death");
                Death.Invoke();
            }
        }
    }
}