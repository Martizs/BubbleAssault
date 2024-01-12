using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPLayer : MonoBehaviour
{
    void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPLayer>().Length;

        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
