using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float x = 1;
    [SerializeField] float y = 1;
    [SerializeField] float z = 1;
    void Update()
    {
        transform.Rotate(x, y, z);
    }
}
