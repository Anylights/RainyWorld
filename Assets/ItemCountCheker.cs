using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCountChecker : MonoBehaviour
{
    public AudioClip itemRemovedSound;
    private AudioSource audioSource;
    private int previousItemCount;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = itemRemovedSound;
        previousItemCount = GameObject.FindGameObjectsWithTag("item").Length;
    }

    void Update()
    {
        int currentItemCount = GameObject.FindGameObjectsWithTag("item").Length;

        if (currentItemCount < previousItemCount)
        {
            PlaySound();
            previousItemCount = currentItemCount;
        }
    }

    void PlaySound()
    {
        audioSource.Play();
    }
}
