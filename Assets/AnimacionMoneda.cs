using UnityEngine;

public class AnimacionMoneda : MonoBehaviour
{
    public float velocidadGiro = 200f;
    public bool efectoFlotar = true;
    
    private float posicionInicialY;

    void Start()
    {
        posicionInicialY = transform.position.y;
    }

    void Update()
    {
        // 1. Giro sobre el eje Y (da el efecto de que la moneda da vueltas sobre sí misma)
        transform.Rotate(Vector3.up * velocidadGiro * Time.deltaTime);

        // 2. Efecto de flotar (sube y baja un poquito)
        if (efectoFlotar)
        {
            float nuevoY = posicionInicialY + Mathf.Sin(Time.time * 5f) * 0.1f;
            transform.position = new Vector3(transform.position.x, nuevoY, transform.position.z);
        }
    }
}