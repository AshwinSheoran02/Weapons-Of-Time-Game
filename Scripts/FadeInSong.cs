using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInSong : MonoBehaviour
{
    public AudioSource music;
    public float duration = 10.0f;
    public float targetVolume = 1.0f;

    void Start()
    {
        music.volume = 0.0f;
    }

    void Update()
    {
        StartCoroutine(StartFade(music, duration, targetVolume));
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
