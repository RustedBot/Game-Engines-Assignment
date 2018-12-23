using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analyser : MonoBehaviour {

    AudioSource audioSource;
    float[] spectrum;
    const int NUM_BINS = 1024;
    float subBassMin, subBassMax;
    float bassMin, bassMax;
    float lowMidrangeMin, lowMidrangeMax;
    float midrangeMin, midrangeMax;
    float upperMidrangeMin, upperMidrangeMax;
    float presenceMin, presenceMax;
    float brillianceMin, brillianceMax;
    public float subBassAmplitude, bassAmplitude, lowMidrangeAmplitude, midrangeAmplitude, upperMidrangeAmplitude, presenceAmplitude, brillianceAmplitude;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        spectrum = new float[NUM_BINS];

        subBassMin = 20f;
        subBassMax = 60f;

        bassMin = 60f;
        bassMax = 250f;

        lowMidrangeMin = 250f;
        lowMidrangeMax = 500f;

        midrangeMin = 500f;
        midrangeMax = 2000f;

        upperMidrangeMin = 2000f;
        upperMidrangeMax = 4000f;

        presenceMin = 4000f;
        presenceMax = 6000f;

        brillianceMin = 6000f;
        brillianceMax = 20000f;
	}
	
	// Update is called once per frame
	void Update () {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
	}

    
}
