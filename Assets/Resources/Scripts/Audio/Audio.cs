using UnityEngine;
using System.Collections;

public static class Audio {

	public static AudioManager audioManager;

	public static void Play(SoundEvent soundEvent)
	{
		if(audioManager != null) audioManager.Play(soundEvent);
	}

}
