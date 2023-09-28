using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorOperacions : MonoBehaviour
{
    public GameObject PrefabOperacio;

    public void IniciaGeneradorOperacions()
    {
        InvokeRepeating("GenerarOperacio", 1f, 3f);
    }

    public void AturaGeneradorOperacions()
    {
        CancelInvoke("GenerarOperacio");
    }

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("GenerarOperacions", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerarOperacio()
    {
        GameObject Operacio = Instantiate(PrefabOperacio);
        Vector2 CostatSuperiorDret = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 CostatInferiorEsquerra = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Operacio.transform.position = new Vector2(
            Random.Range(CostatInferiorEsquerra.x, CostatSuperiorDret.x), // x
            CostatSuperiorDret.y                                          // y
            );
    }

}
