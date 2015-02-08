using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	//private Dictionary<AudioComponent, SoundEvent> components = new Dictionary<AudioComponent, SoundEvent>();

	//private List<AudioComponent>() components = new List<AudioComponent>();

	[SerializeField] private AudioComponent[] audioComponents;

	void Awake()
	{
		Audio.audioManager = this;

//		foreach(AudioComponent ac in audioComponents)
//		{
//			components.Add(ac);
//		}
	}

	void Reset()
	{
		audioComponents = GetComponentsInChildren<AudioComponent>();
	}

	public void Play(SoundEvent soundEvent)
	{
		foreach(AudioComponent key in audioComponents)
		{
			if(key.soundEvent == soundEvent)
			{
				key.Play();
			}
		}

//
//		if(components[soundEvent] != null)
//		{
//			components[soundEvent].Play();
//		}
	}
}

public enum SoundEvent
{
	Jump,
	Reward,
	Collide,
	Move,
	Land,
	Swap
}
