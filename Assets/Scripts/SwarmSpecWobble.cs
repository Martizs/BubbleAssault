using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmSpecWobble : MonoBehaviour
{
    // So this is one complete cycle
    const float TAU = Mathf.PI * 2;

    Vector3 startingPosition;

    [SerializeField]
    float wobbleFactor = 10f;

    [SerializeField]
    float period = 1f;

    private int lastCycle = 0;

    Vector3 wobbleVector;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition;

        wobbleVector = UnityEngine.Random.insideUnitSphere;
    }

    // Update is called once per frame
    void Update()
    {
        Wobble();
    }

    void Wobble()
    {
        // continualy growing over time
        float cycles = Time.time / (period <= Mathf.Epsilon ? 1 : period);

        int checkCycle = (int)Math.Floor(cycles);

        if (lastCycle < checkCycle)
        {
            lastCycle = checkCycle;

            wobbleVector = UnityEngine.Random.insideUnitSphere;
        }

        // Debug.Log(" cycles " + cycles);

        float rawSinWave = Mathf.Sin(cycles * TAU);

        // So that it would go from 0 to 1 instead of -1 to 1
        float movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = wobbleVector * movementFactor * wobbleFactor;
        transform.localPosition = startingPosition + offset;
    }
}
