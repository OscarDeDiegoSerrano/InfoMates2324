using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject NauJugador;
    public GameObject textGameOver;
    public GameObject titolJoc;
    public GameObject botoInici;
    public GameObject generadorNumeros;
    public GameObject generadorOperacions;
    public GameObject botoTornarPantallaInici;
    public enum EstatsGameManager
    {
        Inici,
        Jugant,
        GameOver
    }

    private EstatsGameManager _estatGameManager;

    // Start is called before the first frame update
    void Start()
    {
        _estatGameManager = EstatsGameManager.Inici;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActualitzaEstatGameManager()
    {
        switch (_estatGameManager)
        {
            case EstatsGameManager.Inici:
                NauJugador.SetActive(false);
                titolJoc.SetActive(true);
                textGameOver.SetActive(false);
                botoInici.SetActive(true);
                generadorNumeros.GetComponent<GeneradorNumeros>().AturaGeneradorNumeros();
                generadorOperacions.GetComponent<GeneradorOperacions>().AturaGeneradorOperacions();
                botoTornarPantallaInici.SetActive(false);
                break;

            case EstatsGameManager.Jugant:
                NauJugador.SetActive(true);
                titolJoc.SetActive(false);
                textGameOver.SetActive(false);
                botoInici.SetActive(false);
                generadorNumeros.GetComponent<GeneradorNumeros>().IniciaGeneradorNumeros();
                generadorOperacions.GetComponent<GeneradorOperacions>().IniciaGeneradorOperacions();
                botoTornarPantallaInici.SetActive(false);
                break;

            case EstatsGameManager.GameOver:
                NauJugador.SetActive(false);
                titolJoc.SetActive(false);
                textGameOver.SetActive(true);
                botoInici.SetActive(false);
                generadorNumeros.GetComponent<GeneradorNumeros>().AturaGeneradorNumeros();
                generadorOperacions.GetComponent<GeneradorOperacions>().AturaGeneradorOperacions();
                botoTornarPantallaInici.SetActive(true);
                break;
        }
    }

    public void SetEstatGameManager(EstatsGameManager estat)
    {
        _estatGameManager = estat;
        ActualitzaEstatGameManager();
    }

    public void PassarAEstatInici()
    {
        _estatGameManager = EstatsGameManager.Inici;
        ActualitzaEstatGameManager();
    }

    public void PassarAEstatJugant()
    {
        _estatGameManager = EstatsGameManager.Jugant;
        ActualitzaEstatGameManager();    
    }

    public void PassarAEstatGameOver()
    {
        _estatGameManager = EstatsGameManager.GameOver;
        ActualitzaEstatGameManager();
    }


}
