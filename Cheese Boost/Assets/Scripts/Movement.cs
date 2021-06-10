using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb; 
    AudioSource audioSource;
    [SerializeField] float velocity = 100f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem leftBoost;
    [SerializeField] ParticleSystem rightBoost;
    [SerializeField] ParticleSystem mainBoost;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    { 
        if (Input.GetKey(KeyCode.Space))
        {
            if(!mainBoost.isPlaying){
                mainBoost.Play();
            }
            
            rb.AddRelativeForce(Vector3.up * velocity * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            } 
        } else 
        {
            audioSource.Stop();
            mainBoost.Stop();
        }
        
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        { 
            if(!rightBoost.isPlaying){
                rightBoost.Play();
            }
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        { 
            if(!leftBoost.isPlaying){
                leftBoost.Play();
            }
            ApplyRotation(-rotationSpeed);
        } 
        else {
            rightBoost.Stop();
        }
    }

    void ApplyRotation(float rotationThisframe)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisframe * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over

    }
}
