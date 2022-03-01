using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector;
    [SerializeField] [Range(0, 1)] private float movementFactor;
    [SerializeField] private float period = 2f;

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log(Mathf.Epsilon);*/
        if(period <= Mathf.Epsilon){ return; } //Mathf.Epsilon is the smallest float
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        
        movementFactor = (rawSinWave + 1f)/2f;
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startPosition + offset;
    }
}
