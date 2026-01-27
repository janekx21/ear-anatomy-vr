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
    
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1000;
        time = skip * clip.frequency;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Assert(speed >= 0);
        var off = Mathf.FloorToInt(time);
        var offFrag = time - off;
        clip.GetData(data, off % (clip.samples - data.Length));
        // var dist = (source.position - target.position).magnitude;
        for (int i = 0; i < line.positionCount; i++)
        {
            var amp = (sample(offFrag + i) + sample(offFrag + i + 1)) / 2;
            var t = (float)i / (float)line.positionCount;
            // var amp1 = data[i % data.Length];
            // var amp2 = data[(i + 1) % data.Length];
            // var amp = Mathf.Lerp(amp1, amp2, offFrag);

            line.SetPosition(i, Vector3.Lerp(target.position, source.position, t) + Vector3.up * height * amp);

        }
        // progress += Time.deltaTime * speed;
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
}
