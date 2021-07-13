using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movmentFactor;

    int goBack = 1;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; // current position 
        movementVector.Set(1,0,0);
        movmentFactor = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = movementVector * movmentFactor;
        Debug.Log(goBack);
        if (transform.position.x < 10 || transform.position.x > 70) {
             goBack = goBack * -1;
        }  
        transform.position = transform.position + offset * goBack; 
    }
}
