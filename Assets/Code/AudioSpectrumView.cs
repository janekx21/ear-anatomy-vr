using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrumView : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSourceGetSpectrumData spectrumData;
    private LineRenderer lineRenderer;
    public float freqHint = 500;
    public Transform marker;
    public TMPro.TextMeshPro markerText;
    
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = spectrumData.spectrum.Length - 2;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(Mathf.Log(i+1), 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update maker pos
        var p = marker.localPosition;
        p.x = Mathf.Log(spectrumData.IndexFromFreq(freqHint));
        marker.localPosition = p;
        markerText.text = $"{freqHint}hz";

        for (int i = 1; i < spectrumData.spectrum.Length - 1; i++)
        {
            var pos = new Vector3(Mathf.Log(i), Mathf.Log(spectrumData.spectrumSmooth[i]+0.0000001f), 0);
            lineRenderer.SetPosition(i - 1, Vector3.Lerp(lineRenderer.GetPosition(i-1), pos, 0.1f));
        }
    }

    public void SetFreqHint(float value)
    {
        freqHint = value;
    }
}
