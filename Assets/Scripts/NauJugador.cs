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
        //Para hacer un println
        //Debug.Log(direccioHorizontal);

        Vector2 direccioIndicada = new Vector2(direccioHorizontal, 0f);

        //Ens retorna la posició actual de la nau
        Vector2 novaPos = transform.position;
        novaPos += direccioIndicada * _velNau * Time.deltaTime; 
        //Time.deltaTime fa que el joc vagi en la mateixa velocitat en ordinadors diferents.

        transform.position = novaPos;
    }
}
