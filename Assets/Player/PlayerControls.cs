using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Header("Speed Setup Settings")]
    [Tooltip("How fast ship moves horizontally")]
    [SerializeField]
    int xSpeed = 250;

    [Tooltip("How fast ship moves vertically")]
    [SerializeField]
    int ySpeed = 250;

    [Header("Other Settings")]
    [SerializeField]
    float xRange = 10f;

    [SerializeField]
    float yRange = 7f;

    [SerializeField]
    GameObject[] lasers;

    [SerializeField]
    float positionPitchFactor = -2f;

    [SerializeField]
    float controlPitchFactor = -100f;

    [SerializeField]
    float yawPositionFactor = -1f;

    [SerializeField]
    float rollControlFactor = -100f;

    [SerializeField]
    float pitchRange = 28f;

    [SerializeField]
    float rollRange = 26f;

    float xThrow,
        yThrow;

    float clampedXPos,
        clampedYPos;

    // [SerializeField]
    // ParticleSystem laserLeftParticles,
    //     laserRightParticles;

    // New Input System
    // [SerializeField]
    // InputAction movement;

    // New Input System
    // private void OnEnable()
    // {
    //     movement.Enable();
    // }

    // private void OnDisable()
    // {
    //     movement.Disable();
    // }

    void Update()
    {
        // New Input System
        // float horizontalThrow = movement.ReadValue<Vector2>().x;
        // Debug.Log(" horizontalThrow " + horizontalThrow);

        // float verticalThrow = movement.ReadValue<Vector2>().y;
        // Debug.Log(" verticalThrow " + verticalThrow);

        // Old Input System
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        float xOffset = xThrow * Time.deltaTime * xSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        yThrow = Input.GetAxis("Vertical");
        float yOffset = yThrow * Time.deltaTime * ySpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = Mathf.Clamp(
            pitchDueToPosition + pitchDueToControlThrow,
            -pitchRange,
            pitchRange
        );
        float yaw = transform.localPosition.x * yawPositionFactor;
        float roll = Mathf.Clamp(xThrow * rollControlFactor, -rollRange, rollRange);

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ToggleLasers(bool enable)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;

            emissionModule.enabled = enable;
        }
    }

    void ProcessFiring()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ToggleLasers(true);

            // laserLeftParticles.Play();
            // laserRightParticles.Play();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            // laserLeftParticles.Stop();
            // laserRightParticles.Stop();

            ToggleLasers(false);
        }
    }
}
