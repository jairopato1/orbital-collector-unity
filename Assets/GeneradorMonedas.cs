using UnityEngine;

public class GeneradorMonedas : MonoBehaviour
{
    public GameObject monedaPrefab;
    public float radioDeSeguridad = 0.8f;

    // Ahora esta función acepta un número (cantidad)
    public void GenerarNuevasMonedas(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            Vector3 posicionPropuesta = Vector3.zero;
            bool lugarVacio = false;
            int intentos = 0;

            while (!lugarVacio && intentos < 100)
            {
                float x = Random.Range(-7.5f, 7.5f);
                float y = Random.Range(-4f, 4f);
                posicionPropuesta = new Vector3(x, y, 0);

                Collider2D hit = Physics2D.OverlapCircle(posicionPropuesta, radioDeSeguridad);
                if (hit == null) lugarVacio = true;
                intentos++;
            }

            if (lugarVacio) Instantiate(monedaPrefab, posicionPropuesta, Quaternion.identity);
        }
    }
}