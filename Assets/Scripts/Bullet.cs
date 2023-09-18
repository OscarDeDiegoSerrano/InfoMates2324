using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 5f;
    public float upperBoundary = 10f; // L�mite superior de la pantalla

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Transform representa el objeto en la escena de Unity.
        Vector2 novaPos = transform.position;
        // Guardamos el objeto en la siguiente nueva posici�n.
        novaPos.y += velocity * Time.deltaTime;
        // Igualamos la posici�n con transform.position.
        transform.position = novaPos;

        // Verificamos si la posici�n del objeto ha superado el l�mite superior.
        if (transform.position.y >= upperBoundary)
        {
            // Destruir el objeto cuando llega al borde superior de la pantalla.
            Destroy(this);
        }
    }
}
