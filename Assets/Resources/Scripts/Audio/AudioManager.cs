using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	private Dictionary<SoundEvent, AudioComponent> components = new Dictionary<SoundEvent, AudioComponent>();

	[SerializeField] private AudioComponent[] audioComponents;

	void Awake()
	{
		Audio.audioManager = this;

		foreach(AudioComponent ac in audioComponents)
		{
			components.Add(ac.soundEvent, ac);
		}
	}

	void Reset()
	{
		audioComponents = GetComponentsInChildren<AudioComponent>();
	}

	public void Play(SoundEvent soundEvent)
	{
		if(components[soundEvent] != null)
		{
			components[soundEvent].Play();
		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			Audio.Play(SoundEvent.Collide);
		}

		if(Input.GetKeyDown(KeyCode.W))
		{
			Audio.Play(SoundEvent.Jump);
		}

		if(Input.GetKeyDown(KeyCode.E))
		{
			Audio.Play(SoundEvent.Move);
		}

		if(Input.GetKeyDown(KeyCode.R))
		{
			Audio.Play(SoundEvent.Reward);
		}
	}
}

public enum SoundEvent
{
	Jump,
	Reward,
	Collide,
	Move,
	Land
}
