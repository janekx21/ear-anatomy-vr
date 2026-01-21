using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class SineWave : MonoBehaviour
{
    [SerializeField]
    float sinScale = 
        1.0f;
    [SerializeField]
    float speed =
    1.0f;
    [SerializeField]
    float height =
1.0f;
    LineRenderer line;

    [SerializeField]
    Transform target;
    [SerializeField]
    Transform source;

    [SerializeField]
    AudioClip clip;

    float progress = 0.0f;

    float[] data = new float[1000];
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1000;


    }

    // Update is called once per frame
    int off = 0;
    void Update()
    {
        Debug.Assert(off >= 0);
        Debug.Assert(speed >= 0);
        clip.GetData(data, off % (clip.samples - data.Length));
        off += Mathf.RoundToInt(speed);
        var dist = (source.position - target.position).magnitude;
        for (int i = 0; i < line.positionCount; i++)
        {
            var t = (float)i / (float)line.positionCount;
            var amp = data[i % data.Length];
            //line.SetPosition(i, Vector3.Lerp(source.position, target.position, t) + Vector3.up * height * Mathf.Sin((float)i * sinScale* dist + progress));

            line.SetPosition(i, Vector3.Lerp(target.position, source.position, t) + Vector3.up * height * amp);

        }
        progress += Time.deltaTime * speed;
    }

    void setFreq(float freq)
    {
        this.sinScale = freq;
    }
}
