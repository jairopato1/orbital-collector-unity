using UnityEngine;
using UnityEngine.SceneManagement; // Esta línea es obligatoria para cambiar escenas

public class ControladorEscenas : MonoBehaviour
{
    // Esta función la llamará el botón
    public void IniciarJuego()
    {
        // "SampleScene" es el nombre por defecto de la escena del juego.
        // Si tu escena del calabozo tiene otro nombre, cámbialo aquí.
        SceneManager.LoadScene("SampleScene");
    }
}