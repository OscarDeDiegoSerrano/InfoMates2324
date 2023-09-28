using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TornarInici : MonoBehaviour
{
    public void TornarPantallaPrincipal()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().SetEstatGameManager(GameManager.EstatsGameManager.Inici);
    }
    

// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
