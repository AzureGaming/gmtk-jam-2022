using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAudio : MonoBehaviour
{
    [SerializeField] AudioSource[] bounces;

    public void Play()
    {
        AudioClip clip = bounces[Random.Range(0, bounces.Length)].clip;
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
