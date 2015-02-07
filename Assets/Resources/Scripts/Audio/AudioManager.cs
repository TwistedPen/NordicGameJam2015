using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	private Dictionary<SoundEvent, AudioComponent> audioComponents = new Dictionary<SoundEvent, AudioComponent>();

	[SerializeField] private AudioComponent collide; 
	[SerializeField] private AudioComponent jump; 

	void Awake()
	{
		Audio.audioManager = this;

		audioComponents.Add(SoundEvent.Collide, collide);
		audioComponents.Add(SoundEvent.Jump, jump);
	}

	public void Play(SoundEvent soundEvent)
	{
		if(audioComponents[soundEvent] != null)
		{
			audioComponents[soundEvent].Play();
		}
	}
}

public enum SoundEvent
{
	Jump,
	Reward,
	Collide
}
