using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControlers : MonoBehaviour
{
    private Vector2 _move;
    public Vector2 Move => _move;

    private bool _jump;
    public bool Jump => _jump;

    private bool _run;
    public bool Run => _run;


    public Vector2 GetMove()
    {
        return _move;
    }
    private void OnMove(InputValue input)
    {
        _move = input.Get<Vector2>();
    }

    private void OnJump()
    {
        _jump = true;
    }

  
    private void OnRun(InputValue input)
    {
        _run = input.isPressed;
    }

    private void LateUpdate()//preguntar
    {
        _jump = false;
    }
}
