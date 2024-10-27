using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private float _originalWalkSpeed;
    private float _originalRunSpeed;

    public float WaterSpeedMultiplier = 0.5f; // Multiplicador para reducir la velocidad en agua

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();

        // Guardamos las velocidades originales
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
            // Ajusta las velocidades según el multiplicador de agua
            _playerMovement.WalkSpeed = _originalWalkSpeed * WaterSpeedMultiplier;
            _playerMovement.RunSpeed = _originalRunSpeed * WaterSpeedMultiplier;
        }
    }

    public void Reset()
    {
        if (_playerMovement != null)
        {
            // Restaura las velocidades originales
            _playerMovement.WalkSpeed = _originalWalkSpeed;
            _playerMovement.RunSpeed = _originalRunSpeed;
        }
    }
}
