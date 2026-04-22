using UnityEngine;

public class ControlGiro : MonoBehaviour
{
    public float velocidad = 200f; 

    void Update()
    {
        // Detecta las flechas del teclado o las teclas A y D
        float horizontal = Input.GetAxis("Horizontal");

        // Aplica la rotación al objeto
        transform.Rotate(0, 0, -horizontal * velocidad * Time.deltaTime);
    }
}