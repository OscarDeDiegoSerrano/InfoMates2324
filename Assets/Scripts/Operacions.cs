using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operacions : MonoBehaviour
{
    private float _vel;
    private int _valorOperacio;
    public Sprite[] _SpritesOperacions = new Sprite[5];

    // Start is called before the first frame update
    void Start()
    {
        _vel = 2f;
        System.Random Aleatori = new System.Random();
        _valorOperacio = Aleatori.Next(0, 5); //Aleatori entre 0 i 5.
        //Accedim al component Sprite Renderer i dins d'aquest, a l'atribut Sprite.
        gameObject.GetComponent<SpriteRenderer>().sprite = _SpritesOperacions[_valorOperacio];
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

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Bullet" || objecteTocat.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    private void DestrueixSiSurtFora()
    {
        //Viewport: Qualsevol pantalla que mostra els grafics (tota la pantalla blava).    
        Vector2 costatInferiorEsquerra = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y <= costatInferiorEsquerra.y)
        {
            Destroy(gameObject);
        }
    }
}
