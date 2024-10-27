using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private float _originalWalkSpeed;
    private float _originalRunSpeed;

    public float WaterSpeedMultiplier = 0.5f;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();

        if (_playerMovement != null)
        {
            _originalWalkSpeed = _playerMovement.WalkSpeed;
            _originalRunSpeed = _playerMovement.RunSpeed;
        }
    }

    public void SlowDown(float density)
    {
        if (_playerMovement != null)
        {
            _playerMovement.WalkSpeed = _originalWalkSpeed * WaterSpeedMultiplier;
            _playerMovement.RunSpeed = _originalRunSpeed * WaterSpeedMultiplier;
        }
    }

    public void Reset()
    {
        if (_playerMovement != null)
        {
            _playerMovement.WalkSpeed = _originalWalkSpeed;
            _playerMovement.RunSpeed = _originalRunSpeed;
        }
    }
}
