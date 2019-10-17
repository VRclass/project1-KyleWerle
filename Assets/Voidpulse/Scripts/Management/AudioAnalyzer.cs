using System.Collections;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioAnalyzer : MonoBehaviour {

	AudioSource _audioSource;
	public float[] _samples = new float[512];

	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}

	void Update () {
		GetSpectrumAudioSource();
	}

	void GetSpectrumAudioSource () {
		_audioSource.GetSpectrumData(_samples, 0, FFTWindow.Hanning);
	}
}
