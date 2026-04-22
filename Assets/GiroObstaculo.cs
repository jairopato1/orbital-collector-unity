using UnityEngine;

public class GiroObstaculo : MonoBehaviour
{
    [Header("Ajustes de Giro")]
    public float velocidadGiro = 100f; // Puedes subirlo para que sea más difícil

    void Update()
    {
        // Gira sobre el eje Z (el que importa en 2D)
        transform.Rotate(0, 0, velocidadGiro * Time.deltaTime);
    }
}