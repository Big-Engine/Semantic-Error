using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Level01 : MonoBehaviour
{
    public AudioSource Music;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Music.volume < 1)
        {
            if (Music.isPlaying == false)
            {
                Music.Play();
            }
            StartCoroutine(StartFade(Music, 3, 1));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && Music.volume > 0)
        {
            StartCoroutine(StartFade(Music, 3, 0));
        }
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
