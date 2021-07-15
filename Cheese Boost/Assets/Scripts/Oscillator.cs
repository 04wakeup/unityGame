using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
     float movmentFactor;
    [SerializeField] float period = 2f;

    int goBack = 1;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; // current position 
      
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;  // continually growing over time
        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        movmentFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1

        Vector3 offset = movementVector * movmentFactor;
      
        transform.position = startingPosition + offset * goBack; 
    }
}
