using UnityEngine;

public class Recolector : MonoBehaviour
{
    // Esta función se ejecuta sola cuando el triángulo toca un "Trigger"
    private void OnTriggerEnter2D(Collider2D otro)
    {
        // ¿Lo que tocamos tiene la etiqueta "Moneda"?
        if (otro.CompareTag("Moneda"))
        {
            Destroy(otro.gameObject); // Borra la moneda de la escena
            Debug.Log("¡Pum! Moneda recogida");
        }
    }
}