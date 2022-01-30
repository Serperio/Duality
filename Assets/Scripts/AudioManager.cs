using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
	// Audio players components.
	public AudioSource EffectsSource;
	public AudioSource MusicSourceA;
	public AudioSource MusicSourceB;

	[SerializeField] private AudioClip musicA;
	[SerializeField] private AudioClip musicB;

	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;


	[SerializeField] private AudioClip[] SFXList;

	// Singleton instance.
	public static AudioManager Instance = null;

	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);
	}

	// Play a single clip through the sound effects source.
	public void Play(int clipNumber)
	{
		EffectsSource.clip = SFXList[clipNumber];
		EffectsSource.Play();
	}

	public void MuteMusic(string type)
	{
		if (type == "A")
        {
			DOTween.To(() => MusicSourceA.volume, x => MusicSourceA.volume = x, 0f, 0.5f);
        }
        else
        {
			DOTween.To(() => MusicSourceB.volume, x => MusicSourceB.volume = x, 0f, 0.5f);
		}
	}

	public void UnmuteMusic(string type)
	{
		if (type == "A")
		{
			DOTween.To(() => MusicSourceA.volume, x => MusicSourceA.volume = x, 1f, 0.5f);
			//MusicSourceA.volume = 1;
		}
		else
		{
			DOTween.To(() => MusicSourceB.volume, x => MusicSourceB.volume = x, 1f, 0.5f);
			//MusicSourceB.volume = 1;
		}
	}

	// Play a single clip through the music source.
	public void PlayMusic(string type)
	{
		if (type == "A")
		{
			MusicSourceA.clip = musicA;
			MusicSourceA.Play();
        }
        else
        {
			MusicSourceB.clip = musicB;
			MusicSourceB.Play();
		}
	}

	// Play a random clip from an array, and randomize the pitch slightly.
	public void RandomSoundEffect(params AudioClip[] clips)
	{
		int randomIndex = Random.Range(0, clips.Length);
		float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

		EffectsSource.pitch = randomPitch;
		EffectsSource.clip = clips[randomIndex];
		EffectsSource.Play();
	}

}