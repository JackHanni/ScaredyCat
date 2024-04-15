using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetSound : MonoBehaviour
{ 
    AudioSource source;
    BoxCollider soundTrigger;
    public Transform player;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<BoxCollider>();
    }

    // Called on when object walks on top of game object
    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform == player)
        {
            source.Play();
        }
        
    }
}
