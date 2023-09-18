using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 5f;
    public float upperBoundary = 10f; // Límite superior de la pantalla

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Transform representa el objeto en la escena de Unity.
        Vector2 novaPos = transform.position;
        // Guardamos el objeto en la siguiente nueva posición.
        novaPos.y += velocity * Time.deltaTime;
        // Igualamos la posición con transform.position.
        transform.position = novaPos;

        // Verificamos si la posición del objeto ha superado el límite superior.
        if (transform.position.y >= upperBoundary)
        {
            // Destruir el objeto cuando llega al borde superior de la pantalla.
            Destroy(this);
        }
    }
}
