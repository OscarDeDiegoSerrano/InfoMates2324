using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNumeros : MonoBehaviour
{
    public GameObject PrefabNumero;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke crida al metode GenerarNumero al segon d'iniciar-se y cada tres segons es repetirà l'acció.
        InvokeRepeating("GenerarNumero", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerarNumero()
    {
        GameObject numero = Instantiate(PrefabNumero);
        Vector2 CostatSuperiorDret = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 CostatInferiorEsquerra = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        numero.transform.position = new Vector2(
            Random.Range(CostatInferiorEsquerra.x, CostatSuperiorDret.x), // x
            CostatSuperiorDret.y                                          // y
            );

    }
}
