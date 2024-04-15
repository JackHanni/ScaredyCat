using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;
    public ParticleSystem dust;
    public float moveSpeed = 100f;
    
    public float turnSpeed = 15f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        m_AudioSource = GetComponent<AudioSource> ();
        
        MoveAction.Enable();
    }

    void FixedUpdate ()
    {
        var pos = MoveAction.ReadValue<Vector2>();
        // Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        float horizontal = pos.x;
        float vertical = pos.y;
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);
        
        if (isWalking)
        {
            CreateDust(); // Add Dust Particle Effects
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop ();
        }

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    void OnAnimatorMove ()
    {
        // Change to Lerp Movement
        Vector3 targetPosition = m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude;
        m_Rigidbody.MovePosition(Vector3.Lerp(m_Rigidbody.position, targetPosition, Time.deltaTime * moveSpeed));
        
        // Change to Lerp Rotation
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, m_Rotation, Time.deltaTime * turnSpeed);
        m_Rigidbody.MoveRotation(targetRotation);
        
    }

    void CreateDust() {
        dust.Play();
    }

}