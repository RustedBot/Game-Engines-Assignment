using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analyser : MonoBehaviour {

    AudioSource audioSource;
    float[] spectrum;
    const int NUM_BINS = 1024;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        spectrum = new float[NUM_BINS];
	}
	
	// Update is called once per frame
	void Update () {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
	}
}
