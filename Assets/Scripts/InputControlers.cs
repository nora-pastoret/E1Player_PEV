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

    private bool _runstart;
    public bool RunStart => _runstart;

    private bool _zoom;
    public bool Zoom => _zoom;


    private void OnMove(InputValue input)
    {
        _move = input.Get<Vector2>();
    }

    private void OnJump()
    {
        _jump = true;
    }

    private void OnZoom(InputValue input)
    {
        _zoom = input.isPressed;
    }

    private void Update()
    {
        _runstart = Keyboard.current.shiftKey.isPressed;
    }


    private void LateUpdate()//preguntar
    {
        _jump = false;
    }
}
