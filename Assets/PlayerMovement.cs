using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    CharacterController _characterController;
    InputControlers _inputs;
    GroundChecker _groundChecker;

    public Rigidbody RigB;

    public float Speed = 1;

    public float JumpSpeed = 10;
    public float AirControl=0.1f; //Perqu� hi hagi fricci� (que costi moure's a l'aire quan est� saltant)

    private Vector3 _lastVelocity; //Per la gravetat, perqu� hi hagi acceleraci� i variar la velocitat

    // Start is called before the first frame update
    void Start()
    {
       _characterController = GetComponent<CharacterController>();
       _inputs = GetComponent<InputControlers>();
       _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Jump(ref Vector3 velocity)
    {
        velocity.y = JumpSpeed;
    }

    private bool ShouldJump()
    {
        return _inputs.Jump && _groundChecker.Grounded;
    }

    private void Move()
    {
        Vector3 direction = new Vector3(_inputs.Move.x, 0, _inputs.Move.y);
        //_characterController.SimpleMove(direction * Speed);
        Vector3 velocity = new Vector3();

        float smoothFactor = _groundChecker.Grounded ? 1 : AirControl * Time.deltaTime; //?=if, :=sino --> EST� GROUNDED? SI SI, MOVE NRMAL, SINO FEM AIRCONTROL

        //Per fer un moviment uniformement accelerat
        velocity.x = Mathf.Lerp(_lastVelocity.x, direction.x * Speed, smoothFactor);
        velocity.y = _lastVelocity.y;
        velocity.z = Mathf.Lerp(_lastVelocity.z, direction.z * Speed, smoothFactor);

        velocity.y = GetGravity();
        if (ShouldJump())
            Jump(ref velocity);


        _characterController.Move(velocity * Time.deltaTime);

        //Turn QUE QUAN CANVIIS DE DIRECCI� EL PERSONATGE GIRI/ROTI
        if (direction.magnitude > 0)
        {
            Vector3 target = transform.position + direction;
            transform.LookAt(target);
        }
        _lastVelocity = velocity;
    }

    private float GetGravity()
    {
        return _lastVelocity.y + Physics.gravity.y * Time.deltaTime;
    }
}
