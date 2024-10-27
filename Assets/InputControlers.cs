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

    //private bool _runend;
    //public bool RunEnd => _runend;

    //public bool isRunning;

    //public Vector2 GetMove()
    //{
    //    return _move;
    //}
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
        // Actualiza _run en cada frame según el estado de la tecla de correr (Shift)
        _runstart = Keyboard.current.shiftKey.isPressed;
    }


    private void LateUpdate()//preguntar
    {
        _jump = false;
    }

    //controls = new GameControls();
    //controls.Player.Run.performed += RunPerformed;
    //controls.Player.Run.canceled += RunCanceled;

    //private void RunPerformed()
    //{
    //    _run = true;
    //}

    //private void RunCanceled()
    //{
    //    _run = false;
    //}

    //private void OnRun()
    //{
    //    isRunning = true;
    //}

    //private void OffRun()
    //{
    //    isRunning = false;
    //}

    //private void OnRun(InputValue input)
    //{


    //    //_run = input.isPressed;

    //    //if (input.isPressed)
    //    //{
    //    //    _run = true;
    //    //}
    //    //else
    //    //{

    //    //    _run = false;
    //    //}
    //    //_run = true;
    //}

    //public bool GetRun()
    //{
    //    return running;
    //}


}
