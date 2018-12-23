using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analyser : MonoBehaviour {

    const int NUM_BINS = 1024;
    AudioSource audioSource;
    float[] spectrum;
    public float maxFrequency, binRange;
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
        maxFrequency = AudioSettings.outputSampleRate / 2f;
        binRange = maxFrequency / spectrum.Length;

        subBassAmplitude = 0f;
        bassAmplitude = 0f;
        lowMidrangeAmplitude = 0f;
        midrangeAmplitude = 0f;
        upperMidrangeAmplitude = 0f;
        presenceAmplitude = 0f;
        brillianceAmplitude = 0f;

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

        float currentFrequency = 0f;
        int numSubBassAmplitudes = 0;
        int numBassAmplitudes = 0;
        int numLowMidrangeAmplitudes = 0;
        int numMidrangeAmplitudes = 0;
        int numUpperMidrangeAmplitudes = 0;
        int numPresenceAmplitudes = 0;
        int numBrillianceAmplitudes = 0;

        ResetAmplitudes();

        for (int i = 0; i < spectrum.Length; ++i)
        {
            if (currentFrequency >= subBassMin && currentFrequency <= subBassMax)
            {
                subBassAmplitude += spectrum[i];
                ++numSubBassAmplitudes;
            }

            if (currentFrequency >= bassMin && currentFrequency <= bassMax)
            {
                bassAmplitude += spectrum[i];
                ++numBassAmplitudes;
            }

            if (currentFrequency >= lowMidrangeMin && currentFrequency <= lowMidrangeMax)
            {
                lowMidrangeAmplitude += spectrum[i];
                ++numLowMidrangeAmplitudes;
            }

            if (currentFrequency >= midrangeMin && currentFrequency <= midrangeMax)
            {
                midrangeAmplitude += spectrum[i];
                ++numMidrangeAmplitudes;
            }

            if (currentFrequency >= upperMidrangeMin && currentFrequency <= upperMidrangeMax)
            {
                upperMidrangeAmplitude += spectrum[i];
                ++numUpperMidrangeAmplitudes;
            }

            if (currentFrequency >= presenceMin && currentFrequency <= presenceMax)
            {
                presenceAmplitude += spectrum[i];
                ++numPresenceAmplitudes;
            }

            if (currentFrequency >= brillianceMin && currentFrequency <= brillianceMax)
            {
                brillianceAmplitude += spectrum[i];
                ++numBrillianceAmplitudes;
            }

            currentFrequency += binRange;
        }

        subBassAmplitude /= numSubBassAmplitudes;
        bassAmplitude /= numBassAmplitudes;
        lowMidrangeAmplitude /= numLowMidrangeAmplitudes;
        midrangeAmplitude /= numMidrangeAmplitudes;
        upperMidrangeAmplitude /= numUpperMidrangeAmplitudes;
        presenceAmplitude /= numPresenceAmplitudes;
        brillianceAmplitude /= numBrillianceAmplitudes;
    }

    /*float CalculateAmplitude(float rangeMin, float rangeMax, float currentBinAmplitude)
    {
        float amplitude = 0f, numAmplitudes = 0f;

        if (currentFrequency >= rangeMin && currentFrequency <= rangeMax)
        {
            subBassAmplitude += currentBinAmplitude;
            ++numAmplitudes;
        }

        return amplitude;
    }*/

    void ResetAmplitudes()
    {
        subBassAmplitude = 0f;
        bassAmplitude = 0f;
        lowMidrangeAmplitude = 0f;
        midrangeAmplitude = 0f;
        upperMidrangeAmplitude = 0f;
        presenceAmplitude = 0f;
        brillianceAmplitude = 0f;
    }
}
