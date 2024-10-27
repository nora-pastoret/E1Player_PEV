using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float Density = 2;

    private void OnTriggerEnter(Collider other)
    {
        var slower = other.GetComponent<Slower>();
        if (slower != null)
        {
            slower.SlowDown(Density); // Activa la ralentización
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var slower = other.GetComponent<Slower>();
        if (slower != null)
        {
            slower.Reset(); // Restaura la velocidad al salir del agua
        }
    }
}
