using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class CollisionHandler : MonoBehaviour
{
    const string FINISH_TAG = "Finish";

    [SerializeField]
    float afterCrashDelay = 1f;

    [SerializeField]
    GameObject crashAnimation;

    AudioSource starShipAudio;

    [SerializeField]
    GameObject[] lasers;

    ScoreBoard scoreBoard;

    private void Start()
    {
        starShipAudio = GetComponent<AudioSource>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("PlayerRig").GetComponent<Animator>().enabled = false;

        GetComponent<PlayerControls>().enabled = false;

        foreach (GameObject laser in lasers)
        {
            laser.GetComponent<ParticleSystem>().Stop();
        }

        if (other.gameObject.tag != FINISH_TAG)
        {
            StartCrashSequence();
        }
        else
        {
            InitiateWin();
        }
    }

    void InitiateWin()
    {
        scoreBoard.Finish();
    }

    void StartCrashSequence()
    {
        GetComponent<MeshRenderer>().enabled = false;
        starShipAudio.Play();
        crashAnimation.SetActive(true);

        Delayed("ReloadScene", afterCrashDelay);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Delayed(string methodName, float delay)
    {
        Invoke(methodName, delay);
    }
}
