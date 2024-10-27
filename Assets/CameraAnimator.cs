using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraAnimator : MonoBehaviour
{
    InputControlers _inputs;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        _inputs = GetComponent<InputControlers>();
    }


    void Update()
    {
        if (_inputs.Zoom)
        {
            anim.SetBool("Zoommed", true);
        }
        else
        {
            anim.SetBool("Zoommed", false);
        }

    }
}