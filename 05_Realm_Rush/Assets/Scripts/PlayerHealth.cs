using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int health = 100;
    [SerializeField] int healthPerHit = 10;
    [SerializeField] Text healthText;

    [SerializeField] AudioClip playerDamageSFX;

    void Start()
    {
        healthText.text = "Castle Health: " + health.ToString();
    }

    void OnTriggerEnter(Collider other)
    {

        DecreaseHealth();
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        if (health < 1)
        {
            print("You've been defeated");
            SceneManager.LoadScene(2);
        }
    }

    private void DecreaseHealth()
    {
        health = health - healthPerHit;
        healthText.text = "Castle Health: " + health.ToString();
        print("You've been hit");
    }
}
