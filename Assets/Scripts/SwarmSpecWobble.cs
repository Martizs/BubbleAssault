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
    float wobbleFactor = 1f;

    [SerializeField]
    float period = 2f;

    private int lastCycle = 0;

    Vector3 wobbleVector;
    float[] wobbleVectorArray;

    int wobblePositionIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition;

        wobbleVectorArray = new float[] { 0, 0, 0 };

        wobbleVectorArray[wobblePositionIndex] = wobbleFactor;

        wobbleVector = new Vector3(
            wobbleVectorArray[0],
            wobbleVectorArray[1],
            wobbleVectorArray[2]
        );
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
            wobbleVectorArray = new float[] { 0, 0, 0 };
            wobblePositionIndex++;

            wobblePositionIndex =
                wobblePositionIndex >= wobbleVectorArray.Length ? 0 : wobblePositionIndex;

            wobbleVectorArray[wobblePositionIndex] = wobbleFactor;

            wobbleVector = new Vector3(
                wobbleVectorArray[0],
                wobbleVectorArray[1],
                wobbleVectorArray[2]
            );
        }

        // Debug.Log(" cycles " + cycles);

        float rawSinWave = Mathf.Sin(cycles * TAU);

        // So that it would go from 0 to 1 instead of -1 to 1
        float movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = wobbleVector * movementFactor;
        transform.localPosition = startingPosition + offset;
    }
}
