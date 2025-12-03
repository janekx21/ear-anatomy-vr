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
    LineRenderer line;
    
    float progress = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < line.positionCount; i++)
        {
            line.SetPosition(i, Vector3.right * i + Vector3.up * Mathf.Sin((float)i * sinScale + progress));

        }
        progress += Time.deltaTime * speed;
    }

    void setFreq(float freq)
    {
        this.sinScale = freq;
    }
}
