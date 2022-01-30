using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager S;

    public AudioSource audioSource;
    public AudioClip jumpClip, coinClip, pushClip, pullClip;
    
    // hitClip, fallClip, deathClip, powerUpClip, checkpointClip, fanfareClip, gameoverClip;

    private void Awake()
    {
        // assign this object to the singleton
        S = this;
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpClip);
    }

    public void PlayPushSound()
    {
        audioSource.PlayOneShot(pushClip);
    }

    public void PlayPullSound()
    {
        audioSource.PlayOneShot(pullClip);
    }

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinClip);
    }

/*
    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitClip);
    }

    public void PlayFallSound()
    {
        audioSource.PlayOneShot(fallClip);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathClip);
    }

    public void PlayPowerUpSound()
    {
        audioSource.PlayOneShot(powerUpClip);
    }

    public void PlayCheckpointClip()
    {
        audioSource.PlayOneShot(checkpointClip);
    }

    public void PlayFanfareClip()
    {
        audioSource.PlayOneShot(fanfareClip);
    }

    public void PlayGameoverClip()
    {
        audioSource.PlayOneShot(gameoverClip);
    }
*/

}
