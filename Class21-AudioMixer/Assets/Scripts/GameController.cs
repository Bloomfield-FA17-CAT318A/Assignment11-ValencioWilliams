using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	private AudioMixer audioMixer;
	private Slider masterVolumeSlider;
	private Slider musicVolumeSlider;
	private Slider fxVolumeSlider;

	float master;
	float music;
	float fx;

	void Awake ()
	{
		audioMixer = Resources.Load ("Audio/GameAudioMixer") as AudioMixer;
		masterVolumeSlider = GameObject.Find ("Master Volume").GetComponent<Slider> ();
		musicVolumeSlider = GameObject.Find ("Music Volume").GetComponent<Slider> ();
		fxVolumeSlider = GameObject.Find ("FX Volume").GetComponent<Slider> ();

	}

	void Start ()
	{
		audioMixer.GetFloat ("masterVolume", out master);
		audioMixer.GetFloat ("musicVolume", out music);
		audioMixer.GetFloat ("soundVolume", out fx);

		Debug.Log ("Master: " + master);
		Debug.Log ("Music: " + music);
		Debug.Log ("SoundFX: " + fx);

		masterVolumeSlider.value = master;
	}

	public void ChangeMasterVolume ()
	{
		audioMixer.SetFloat ("masterVolume", masterVolumeSlider.value);
		// Write to PlayerPrefs if you wanted...
	}

	public void ChangeMusicVolume ()
	{
		audioMixer.SetFloat ("musicVolume", musicVolumeSlider.value);
		// Write to PlayerPrefs if you wanted...
	}

	public void ChangeFXVolume ()
	{
		audioMixer.SetFloat ("soundVolume", fxVolumeSlider.value);
		// Write to PlayerPrefs if you wanted...
	}

	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.F1))
		{
			audioMixer.SetFloat ("masterVolume", master - 5.0f);
			audioMixer.SetFloat ("musicVolume", music - 5.0f);
			audioMixer.SetFloat ("soundVolume", fx - 5.0f);
		}
		if (Input.GetKeyUp (KeyCode.F2))
		{
			audioMixer.SetFloat ("masterVolume", master + 5.0f);
			audioMixer.SetFloat ("musicVolume", music + 5.0f);
			audioMixer.SetFloat ("soundVolume", fx + 5.0f);
		}
	}
}
