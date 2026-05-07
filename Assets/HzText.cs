using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HzText : MonoBehaviour
{
    private Text text;
    float freqHint = 500;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{freqHint}hz";
    }

    public void SetFreq(float value)
    {
        freqHint = value;
    }
}
