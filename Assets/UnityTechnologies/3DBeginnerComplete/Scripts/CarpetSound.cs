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

    private void OnTriggerStay(Collider collider)
    {
        // only plays the sound when the player is walking on carpet
        if (collider.transform == player)
        {
            Animator playerAnimator = player.GetComponent<Animator>();
            if (playerAnimator.GetBool("IsWalking"))
            {
                if (!source.isPlaying)
                {
                    source.Play();
                }
            }
            else
            {
                source.Stop();
            }
        }
    }
}
