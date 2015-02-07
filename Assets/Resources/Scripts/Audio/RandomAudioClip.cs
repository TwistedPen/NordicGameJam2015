using UnityEngine;
using System.Collections;

public class RandomAudioClip : AudioComponent {

	[SerializeField] private AudioClip[] audioClips;
	[SerializeField] private float minRandomPitch;
	[SerializeField] private float maxRandomPitch;
	private bool randomizePitch = true;

	private AudioSource audioSource;

	void Start()
	{
		audioSource = audio;

		if(maxRandomPitch == 0 && minRandomPitch == 0)
		{
			randomizePitch = false;
		}
	}

	public override void Play ()
	{
		if(audioClips.Length < 1) return;

		int randomClip = Random.Range(0, audioClips.Length);
	
		if(randomizePitch) audioSource.pitch = Random.Range(minRandomPitch, maxRandomPitch);

		audioSource.PlayOneShot(audioClips[randomClip]);
	}
}
