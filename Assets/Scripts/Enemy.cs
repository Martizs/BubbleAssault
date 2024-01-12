using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    GameObject explosion,
        explosionSound,
        hitAnimation,
        hitSound,
        spawnObject;

    ScoreBoard scoreBoard;

    [SerializeField]
    int hp = 1;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(true);

        explosion = GameObject.FindWithTag("EnemyExplosion");
        ParticleSystem.MainModule mainer = explosion.GetComponent<ParticleSystem>().main;
        mainer.playOnAwake = true;

        hitAnimation = GameObject.FindWithTag("HitAnimation");
        ParticleSystem.MainModule mainerz = hitAnimation.GetComponent<ParticleSystem>().main;
        mainerz.playOnAwake = true;

        explosionSound = GameObject.FindWithTag("EnemyExplosionSound");
        explosionSound.GetComponent<AudioSource>().playOnAwake = true;

        hitSound = GameObject.FindWithTag("HitSound");
        hitSound.GetComponent<AudioSource>().playOnAwake = true;

        spawnObject = GameObject.FindWithTag("SpawnObject");

        // gameObject.AddComponent<Rigidbody>().useGravity = false;
    }

    private void CreateCloneAtObject(GameObject cloneGameObject)
    {
        GameObject newClone = Instantiate(cloneGameObject, transform.position, Quaternion.identity);
        newClone.name = "Clone destroy me";
        newClone.transform.parent = spawnObject.transform;
    }

    private void handleCollision()
    {
        if (hp - 1 == 0)
        {
            handleDestruction();
        }
        else
        {
            hp--;
            CreateCloneAtObject(hitAnimation);
            CreateCloneAtObject(hitSound);
        }
    }

    private void handleDestruction()
    {
        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().enabled = false;
        }

        CreateCloneAtObject(explosion);
        CreateCloneAtObject(explosionSound);

        scoreBoard.IncreaseScore();

        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        handleCollision();
    }
}
