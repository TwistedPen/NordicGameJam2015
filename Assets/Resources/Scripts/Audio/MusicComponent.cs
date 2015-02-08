using UnityEngine;
using System.Collections;

public class MusicComponent : AudioComponent {

	private bool fading = false;

	private float fadeInTime = 2.5f;
	private float fadeCounter;

	private float maxVolume;
	private float currentVolume;

	private AudioSource audioSource;

	void Start()
	{
		audioSource = audio;
		maxVolume = audioSource.volume;
	}

	public override void Play ()
	{
		StartFadeIn();
	}

	void StartFadeIn()
	{
		if(fading) return;

		audioSource.volume = 0f;
		audioSource.Play();
		fadeCounter = 0f;
		StartCoroutine(FadeIn());
	}

	IEnumerator FadeIn()
	{
		yield return new WaitForSeconds(0.01f);

		if(fadeCounter <= fadeInTime)
		{
			fadeCounter += 0.01f;
			currentVolume = Mathf.Lerp(0f, maxVolume, fadeCounter / fadeInTime);
			audioSource.volume = currentVolume;
			StartCoroutine(FadeIn());
		}
		else
		{
			currentVolume = maxVolume;
		}
	}

}
