using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numero : MonoBehaviour
{
    private float _vel;
    private int _valorNumero;

    public Sprite[] _SpritesNumeros = new Sprite[10];

    // Start is called before the first frame update
    void Start()
    {
        _vel = 2f;

        //Carreguem una imatge de número aleatori.
        System.Random Aleatori = new System.Random();
        _valorNumero = Aleatori.Next(0, 10); //Aleatori entre 0 i 9.
        //Accedim al component Sprite Renderer i dins d'aquest, a l'atribut Sprite.
        gameObject.GetComponent<SpriteRenderer>().sprite = _SpritesNumeros[_valorNumero];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos = transform.position;
        // Fem que la velocitat es multipliqui per Time.deltaTime perque es normalitzi la velocitat de caiguda.
        novaPos.y = novaPos.y - _vel * Time.deltaTime;
        transform.position = novaPos;
        DestrueixSiSurtFora();
    }

    //Numero:
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Bullet" || objecteTocat.tag == "Player") 
        {
            GameObject.Find("NumText").GetComponent<NumText>().AfegirNum(_valorNumero);
            Destroy(gameObject);
        }
    }

    private void DestrueixSiSurtFora()
        {
        //Viewport: Qualsevol pantalla que mostra els grafics (tota la pantalla blava).    
        Vector2 costatInferiorEsquerra = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            if(transform.position.y <= costatInferiorEsquerra.y) 
            {
                Destroy(gameObject);
            }
        }


}
