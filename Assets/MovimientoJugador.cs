using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Ajustes de Velocidad")]
    public float velocidad = 6f;

    [Header("Límites del Mapa (Ajustar en Inspector)")]
    // Basado en tu posición de 9.5 y -4.0
    public float limiteX = 9.6f;
    public float limiteY = 4.1f;

    void Update()
    {
        // 1. Obtener movimiento de flechas o WASD
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        // 2. Calcular nueva posición
        Vector3 movimiento = new Vector3(movH, movV, 0);
        transform.position += movimiento * velocidad * Time.deltaTime;

        // 3. LIMITAR BORDES (El "Clamp" evita que se salga del cuadro)
        float xSegura = Mathf.Clamp(transform.position.x, -limiteX, limiteX);
        float ySegura = Mathf.Clamp(transform.position.y, -limiteY, limiteY);

        transform.position = new Vector3(xSegura, ySegura, 0);
    }

    // Función extra por si necesitas teletransportarlo desde otro script
    public void ResetearPosicion()
    {
        transform.position = new Vector3(9.57f, -4.03f, 0);
    }
}