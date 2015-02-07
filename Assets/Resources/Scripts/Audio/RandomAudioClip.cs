using UnityEngine;
using System.Collections;

public class RandomAudioClip : AudioComponent {

	[SerializeField] private AudioClip[] audioClips;

	private AudioSource audioSource;

	void Start()
	{
		audioSource = audio;
	}

	public override void Play ()
	{
		int randomClip = Random.Range(0, audioClips.Length);

		audioSource.PlayOneShot(audioClips[randomClip]);
	}
}
