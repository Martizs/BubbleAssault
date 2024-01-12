using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSingleton : MonoBehaviour
{
    void Awake()
    {
        int numScoreBoards = FindObjectsOfType<CanvasSingleton>().Length;

        if (numScoreBoards > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
