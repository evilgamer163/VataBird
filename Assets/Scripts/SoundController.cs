using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    AudioClip clip;
    public AudioSource source;

    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        clip = gameObject.GetComponent<AudioClip>();

        clip = clips[Random.Range(0, clips.Length)];
        source.PlayOneShot(clip);
    }
}
