using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{


    [SerializeField] private float damage = 100f;

    private AudioSource audioSource;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (BoyCntrl.BoyInstance != null)
        {
            audioSource.Play();
            BoyCntrl.Health -= damage * Time.deltaTime;
        }
    }

}
