using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    public float _velNau; //variable velocitat Nau

    // Start is called before the first frame update
    void Start()
    {
        _velNau = 5f; //f de float
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxis acelera poco a poco
        //GetAxisRaw de golpe
        float direccioHorizontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxisRaw("Vertical");
        //Para hacer un println
        //Debug.Log(direccioHorizontal);

        Vector2 direccioIndicada = new Vector2(direccioHorizontal, direccioVertical).normalized;

        SpriteRenderer SpriteRenderer = GetComponent<SpriteRenderer>();
        float anchura = SpriteRenderer.bounds.size.x/2;
        float altura = SpriteRenderer.bounds.size.y/2;

        //orthographicSize es la distancia desde el centro de la pantalla al borde.
        //Camera.main.aspect devuelve cuanto mas de anchura hay respecto a la altura ya que no todas las pantallas tienen la altura = a la anchura. R = ANCHURA / ALTURA.
        float limitEsquerraX = -Camera.main.orthographicSize * Camera.main.aspect + anchura;
        float limitDretaX = Camera.main.orthographicSize * Camera.main.aspect - anchura;

        float limitSuperiorY = Camera.main.orthographicSize - altura;
        float limitInferiorY = -Camera.main.orthographicSize + altura;

        //Ens retorna la posició actual de la nau
        Vector2 novaPos = transform.position;
        novaPos += direccioIndicada * _velNau * Time.deltaTime;
        //Time.deltaTime fa que el joc vagi en la mateixa velocitat en ordinadors diferents.

        novaPos.x = Mathf.Clamp(novaPos.x, limitEsquerraX, limitDretaX);
        novaPos.y = Mathf.Clamp(novaPos.y, limitInferiorY, limitSuperiorY);

        Debug.Log(novaPos.x);

        transform.position = novaPos;
    }
}
