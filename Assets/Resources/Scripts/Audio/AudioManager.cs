using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	private Dictionary<SoundEvent, AudioComponent> audioComponents = new Dictionary<SoundEvent, AudioComponent>();

	[SerializeField] private AudioComponent collide; 

	void Awake()
	{
		Audio.audioManager = this;

		audioComponents.Add(SoundEvent.Collide, collide);
	}

	public void Play(SoundEvent soundEvent)
	{
		audioComponents[soundEvent].Play();
	}
}

public enum SoundEvent
{
	Jump,
	Reward,
	Collide
}
