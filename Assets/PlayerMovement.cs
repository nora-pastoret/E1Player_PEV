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

    //public Rigidbody RigB;

    public float WalkSpeed = 5;

    public float JumpSpeed = 10;
    public float AirControl = 0.1f; //Perqu? hi hagi fricci? (que costi moure's a l'aire quan est? saltant)

    public float TurnSpeed = 1;

    public float RunSpeed = 30; // Multiplicador de velocidad al correr

    private Vector3 _lastVelocity; //Per la gravetat, perqu? hi hagi acceleraci? i variar la velocitat


    public Animator doorAnimator;
    public bool key_collected;

    void Awake()
    {
        key_collected = false;
    }

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
        var localInput = transform.right * _inputs.Move.x + transform.forward * _inputs.Move.y;
        Vector3 direction = new Vector3(localInput.x, 0, localInput.z); //A y D giren el personatge

        //Vector3 direction = new Vector3(_inputs.Move.x, 0, _inputs.Move.y); //A y D avancen dreta i esquerra
        Vector3 velocity = new Vector3();

        float smoothFactor = _groundChecker.Grounded ? 1 : AirControl * Time.deltaTime; //?=if, :=sino --> EST? GROUNDED? SI SI, MOVE NRMAL, SINO FEM AIRCONTROL

        float currentSpeed = _inputs.RunStart ? RunSpeed : WalkSpeed;
   
        //float currentSpeed = _inputs.Run ? WalkSpeed * RunSpeed : WalkSpeed;

        //Per fer un moviment uniformement accelerat
        velocity.x = Mathf.Lerp(_lastVelocity.x, direction.x * currentSpeed, smoothFactor);
        velocity.y = _lastVelocity.y;
        velocity.z = Mathf.Lerp(_lastVelocity.z, direction.z * currentSpeed, smoothFactor);

        velocity.y = GetGravity();
        if (ShouldJump())
            Jump(ref velocity);


        _characterController.Move(velocity * Time.deltaTime);

        //Turn QUE QUAN CANVIIS DE DIRECCI? EL PERSONATGE GIRI/ROTI
        if (direction.magnitude > 0)
        {
            Vector3 target = transform.position + direction;
            //Vector3 current = transform.position + transform.forward;
            //Vector3 look = Vector3.Lerp(current, target, TurnSpeed * Time.deltaTime);
            //transform.LookAt(target);
            Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
        }
        _lastVelocity = velocity;
    }

    private float GetGravity()
    {
        return _lastVelocity.y + Physics.gravity.y * Time.deltaTime;
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DoorCollider")
        {
            key_collected = true;
            doorAnimator.SetTrigger("key_collected");
        }
    }
}