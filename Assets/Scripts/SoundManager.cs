using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager S;

    public AudioSource audioSource;
    public AudioClip jumpClip, hitClip, fallClip, deathClip, coinClip, powerUpClip, checkpointClip, fanfareClip, gameoverClip;

    private void Awake()
    {
        // assign this object to the singleton
        S = this;
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpClip);
    }

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

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinClip);
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

    //egchan:adding sound slider
    [SerializeField] Slider volumeSlider;

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
