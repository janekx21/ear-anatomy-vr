using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CochleaMovement : MonoBehaviour
{
    [SerializeField] private float pos;
    [SerializeField] public AudioSourceGetSpectrumData spectrumData;
    private Animator _animator;
    public AudioSpectrumView view;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = spectrumData.SinFromFreq(view.freqHint) * 0.5f + 0.5f;
        _animator.speed = 0;
        _animator.Play("Armature|ArmatureAction", 0, pos);
    }
}
