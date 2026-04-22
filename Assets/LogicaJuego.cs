using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro; // Obligatorio para tus nuevos textos

public class LogicaJuego : MonoBehaviour
{
    [Header("Configuración de Niveles (Progresión)")]
    public int nivelActual = 1;
    public int monedasActuales = 0;
    public int metaDelNivel = 5; // Nivel 1 = 5, Nivel 2 = 10, Nivel 3 = 15
    public int incrementoPorNivel = 5;
    public float tiempoInicial = 45f;
    public float tiempoRestante;
    private bool juegoTerminado = false;

    [Header("Posición de Inicio (Reset)")]
    public Vector3 posicionDeInicio = new Vector3(9.57f, -4.03f, 0);

    [Header("Sonidos (Feedback Auditivo)")]
    public AudioSource miAltavoz; 
    public AudioClip sonidoClin;  

    [Header("Interfaz de Usuario (Feedback Visual)")]
    public TextMeshProUGUI textoMonedas; 
    public TextMeshProUGUI textoTiempo;

    [Header("Referencias Técnicas")]
    private GeneradorMonedas miGenerador;

    void Start()
    {
        // Buscamos el generador en la escena
        miGenerador = Object.FindAnyObjectByType<GeneradorMonedas>();
        
        // Iniciamos el primer nivel
        tiempoRestante = tiempoInicial;
        ConfigurarNivel();
        ActualizarInterfaz();
    }

    void Update()
    {
        if (!juegoTerminado)
        {
            // Lógica del Reloj
            if (tiempoRestante > 0)
            {
                tiempoRestante -= Time.deltaTime;
                // Actualizamos el texto del tiempo (Ceil para que no muestre decimales feos)
                if (textoTiempo != null)
                {
                    textoTiempo.text = "Tiempo: " + Mathf.Ceil(tiempoRestante).ToString() + "s";
                }
            }
            else
            {
                Morir(); // Se acabó el tiempo
            }
        }
    }

    // GESTIÓN DE COLISIONES (Tags: Moneda y Obstaculo)
    void OnTriggerEnter2D(Collider2D other)
    {
        // 1. RECOGER MONEDA
        if (other.CompareTag("Moneda"))
        {
            miAltavoz.PlayOneShot(sonidoClin); // ¡CLINNN!
            monedasActuales++;
            ActualizarInterfaz();
            Destroy(other.gameObject);
            
            // ¿Completó la meta del nivel actual?
            if (monedasActuales >= metaDelNivel)
            {
                AvanzarNivel();
            }
        }

        // 2. CHOQUE CON CAMIÓN (Tag exacto de tu foto: Obstaculo)
        if (other.CompareTag("Obstaculo"))
        {
            Morir();
        }
    }

    void AvanzarNivel()
    {
        if (nivelActual < 3)
        {
            nivelActual++;
            metaDelNivel += incrementoPorNivel; // Sube la dificultad
            monedasActuales = 0; // Reinicia contador para el nuevo nivel
            tiempoRestante = tiempoInicial; // Opcional: Resetear tiempo al pasar nivel
            
            Debug.Log("¡Pasaste al Nivel " + nivelActual + "!");
            ConfigurarNivel();
            ActualizarInterfaz();
        }
        else
        {
            // VICTORIA TOTAL
            juegoTerminado = true;
            if (textoMonedas != null) textoMonedas.text = "¡CALABOZO COMPLETADO!";
            Debug.Log("¡Ganaste los 3 niveles!");
            // Aquí podrías cargar una escena de créditos o victoria
        }
    }

    void ConfigurarNivel()
    {
        // Regresamos al Pato Real al punto de INICIO
        transform.position = posicionDeInicio;

        // Mandamos a crear las monedas nuevas
        if (miGenerador != null) 
        {
            miGenerador.GenerarNuevasMonedas(metaDelNivel);
        }

        Time.timeScale = 1; 
    }

    void ActualizarInterfaz()
    {
        if (textoMonedas != null)
        {
            textoMonedas.text = "Nivel " + nivelActual + " - Monedas: " + monedasActuales + " / " + metaDelNivel;
        }
    }

    void Morir()
    {
        Debug.Log("Game Over. Reiniciando...");
        // Reinicia la escena completa (vuelve al Nivel 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}