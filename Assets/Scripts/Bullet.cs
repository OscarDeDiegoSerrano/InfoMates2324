using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 5f;

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

        float limitSuperiorY = Camera.main.orthographicSize;

        // Verificamos si la posici�n del objeto ha superado el l�mite superior.
        if (transform.position.y >= limitSuperiorY)
        {
            // Destruir el objeto cuando llega al borde superior de la pantalla.
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Numero" || objecteTocat.tag == "Operacio")
        {
            Destroy(gameObject);
        }
    }

}
