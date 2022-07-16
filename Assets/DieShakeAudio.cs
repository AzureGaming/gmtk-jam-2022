using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieShakeAudio : MonoBehaviour
{
    [SerializeField] AudioSource shake1;
    [SerializeField] AudioSource shake2;
    [SerializeField] AudioSource shake3;
    AudioSource currentlyPlaying;

    public void PlayShake()
    {
        int randomShake = Random.Range(0, 3);
        if (randomShake == 0)
        {
            PlayShake1();
        }
        else if (randomShake == 1)
        {
            PlayShake2();
        }
        else
        {
            PlayShake3();
        }
    }

    void PlayShake1()
    {
        currentlyPlaying = shake1;
        shake1.loop = true;
        shake1.Play();
    }

    void PlayShake2()
    {
        currentlyPlaying = shake2;
        shake2.loop = true;
        shake2.Play();
    }

    void PlayShake3()
    {
        currentlyPlaying = shake3;
        shake3.loop = true;
        shake3.Play();
    }



    public void StopPlayingShake()
    {
        currentlyPlaying.Stop();
    }
}
