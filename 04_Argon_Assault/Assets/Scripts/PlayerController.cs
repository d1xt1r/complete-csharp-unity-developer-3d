using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 13f; //X movement
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 8f; //Y movement
    [Tooltip("In ms")] [SerializeField] float xRange = 6.5f; //X movement
    [Tooltip("In ms")] [SerializeField] float yRange = 3.5f; //Y movement

    [Header("Weapons")]
    [SerializeField] GameObject[] guns;

    [Header("Screen Position Parameters")]
    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float positionYawFactor = 5f;
    
    [Header("Control Throw Parameters")]
    [SerializeField] float controlPitchFactor = -12f;
    [SerializeField] float controlRollFactor = -10f;

    float xThrow;
    float yThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update ()
    {
        if (isControlEnabled)
        {
            ProcessTranslation(); // X and Y movement
            ProcesRotation();
            ProcessFiring();
        }
    }

    void OnPlayerDeath() // called by string reference
    {
        isControlEnabled = false;
    }

    private void ProcesRotation()
    {
        //float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        //float yaw = transform.localPosition.x * positionYawFactor + xThrow;
        //float roll = transform.localPosition.z * controlRollFactor;

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor; // only have position factor

        float roll = xThrow * controlRollFactor; // only have control factor


        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //X movement
        yThrow = CrossPlatformInputManager.GetAxis("Vertical"); //Y movement

        float xOffset = xThrow * xSpeed * Time.deltaTime; //X movement
        float yOffset = yThrow * ySpeed * Time.deltaTime; //Y movement

        float rawXPos = transform.localPosition.x + xOffset; //X movement
        float rawYPos = transform.localPosition.y + yOffset; //Y movement

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); //X movement
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange); //Y movement

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns) // may affect death FX
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
