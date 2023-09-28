using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class NauJugador : MonoBehaviour
{
    public float _velNau; //variable velocitat Nau
    public GameObject _PrefabExplosio;

    // Start is called before the first frame update
    void Start()
    {
        _velNau = 5f; //f de float
    }

    // Update is called once per frame
    void Update()
    {
        MovimentNau();
        DisparaBala();
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        //Quan la Nau toqui algun objecte automàticament es cridarà aquest mètode.
        //El valor del objecteTocat, serà l'objecte que hagim tocat (per exemple el número)
        if (objecteTocat.tag == "Numero" || objecteTocat.tag == "Operacio")
        {
            // Fem que la explosió aparegui just en la posició de la NauJUgador.
            GameObject explosio = Instantiate(_PrefabExplosio);
            explosio.transform.position = transform.position;
            //Destroy(gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().SetEstatGameManager(GameManager.EstatsGameManager.GameOver);
        }
    }

    private void MovimentNau()
    {
        //GetAxis acelera poco a poco
        //GetAxisRaw de golpe
        float direccioHorizontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxisRaw("Vertical");
        //Para hacer un println
        //Debug.Log(direccioHorizontal);

        Vector2 direccioIndicada = new Vector2(direccioHorizontal, direccioVertical).normalized;

        SpriteRenderer SpriteRenderer = GetComponent<SpriteRenderer>();
        float anchura = SpriteRenderer.bounds.size.x / 2;
        float altura = SpriteRenderer.bounds.size.y / 2;

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

        transform.position = novaPos;
    }

    private void DisparaBala()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            GameObject Bullet = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject);
            Vector2 newPos = transform.position;
            newPos.x += 0.2f;
            Bullet.transform.position = newPos;


            GameObject Bullet2 = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject);
            Vector2 newPos2 = transform.position;
            newPos2.x += -0.2f;
            Bullet2.transform.position = newPos2;
        }
    }
}
