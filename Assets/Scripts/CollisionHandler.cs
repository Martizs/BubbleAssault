using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    float afterCrashDelay = 1f;

    [SerializeField]
    GameObject crashAnimation;

    AudioSource starShipAudio;

    private void Start()
    {
        starShipAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        GameObject.FindGameObjectsWithTag("PlayerRig")[0].GetComponent<Animator>().enabled = false;

        GetComponent<PlayerControls>().enabled = false;
        starShipAudio.Play();
        crashAnimation.SetActive(true);

        GetComponent<MeshRenderer>().enabled = false;

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
