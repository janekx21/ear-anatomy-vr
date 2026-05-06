using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEarMovement : MonoBehaviour
{
    [SerializeField] private float pos;
    [SerializeField] public SineWave sineWave;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = sineWave.SampleTarget() * 0.5f + 0.5f;
        _animator.speed = 0;
        _animator.Play("Armature|BoneMovementLinera", 0, pos);
    }
}
