using System;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioSourceGetSpectrumData : MonoBehaviour
{
    const int Resolution = 1024;
    AudioSource m_MyAudioSource;
    float[] spectrum = new float[Resolution];

    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        m_MyAudioSource.GetSpectrumData(spectrum, 0, FFTWindow.Hanning);

        // Loop through the populated array
        // Start the loop from 1 and to 1 less than the length, so the loop can draw lines between adjacent bins. 
        //Debug.Log(spectrum);
        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            //Gizmos.color = Color.red;
            //Gizmos.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0));

            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);


            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);


            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);

            
        }

        foreach(var f in new float[] { 100, 200, 500, 800, 1000, 10000 })
        {
            var x = SinFromFreq(f);
            var freq_i = IndexFromFreq(f);
            Debug.DrawLine(new Vector3(Mathf.Log(freq_i), 0, 3), new Vector3(Mathf.Log(freq_i), x * 10, 3), Color.red);
        }

    }

    int IndexFromFreq(float freq)
    {
        var sampleRate = AudioSettings.outputSampleRate;
        return (int)Mathf.Floor(freq * Resolution / (sampleRate * 0.5f));
    }

    // saw: -4 to -25 (this is probibly in db or something)
    float MagnitudeAtFreq(float freq)
    {
        var freq_i = IndexFromFreq(freq);
        return Mathf.Log(spectrum[freq_i - 1]);
    }

    public float SinFromFreq(float f)
    {
        var mag = MagnitudeAtFreq(f);
        var sin = Mathf.Sin(Time.time * 2);
        var from = 5;
        var to = 24;
        return Mathf.Clamp01(Mathf.Pow((mag + to) / (to-from), 8)) * sin;
    }
}
