using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Animator _controller;
    private const string Enemy = "Box";
    
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        //Physics.IgnoreCollision(_player.GetComponent<Collider>(),gameObject.GetComponent<Collider>());
        if (collision.gameObject.CompareTag(Enemy))
        {
            Debug.Log("Мы тут");
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.transform.SetParent(null);
            gameObject.GetComponent<RigBuilder>().enabled = false;
            _controller.SetTrigger("Death");
        }
    }
    

}
