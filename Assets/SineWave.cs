using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class SineWave : MonoBehaviour
{
    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    float skip = 1.0f;
    [SerializeField]
    float height = 1.0f;

    [SerializeField]
    Transform target;
    [SerializeField]
    Transform source;

    [SerializeField]
    AudioClip clip;

    LineRenderer line;
    float time = 0.0f;
    float[] data = new float[1000];
    Vector3[] positions = new Vector3[1000];

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1000;
        time = skip * 44000;
    }

    // Update is called once per frame
    void Update()
    {
        if (clip == null) return;
        Debug.Assert(speed >= 0);
        var off = Mathf.FloorToInt(time);
        var offFrag = time - off;
        clip.GetData(data, off % (clip.samples - data.Length));
        Vector3 targetPos = target.position;
        Vector3 sourcePos = source.position;
        for (int i = 0; i < line.positionCount; i++)
        {
            var amp = (sample(offFrag + i) + sample(offFrag + i + 1)) * 0.5f;
            var t = (float)i / (float)line.positionCount;

            positions[i] = Vector3.Lerp(targetPos, sourcePos, t) + amp * height * Vector3.up;
        }
        line.SetPositions(positions);
        time += Time.deltaTime * speed;
    }

    float sample(float t)
    {
        var i = Mathf.FloorToInt(t);
        var frag = t - i;
        var amp1 = data[i % data.Length];
        var amp2 = data[(i + 1) % data.Length];
        return Mathf.Lerp(amp1, amp2, frag);
    }

    void setFreq(float freq)
    {
        speed = freq;
    }

    public float SampleTarget()
    {
        var off = Mathf.FloorToInt(time);
        var offFrag = time - off;
        return sample(offFrag);
    }

    public void setAudioClip(AudioClip newClip)
    {
        clip = newClip;
    }

    public void stopAudioClip()
    {
        clip = null;
    }

    public void setHeight(float newHeight)
    {
        height = newHeight;
    }

}
