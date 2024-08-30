using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool FinJuego;
    public GameObject GameOverUI;
    public GameObject WinLevelUI;
    public MenuPausa menupausa;
    public string TagEnemigo = "Enemigo";
    // Start is called before the first frame update
    void Start()
    {
        FinJuego = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(TagEnemigo);
        for (int i = 0; i < enemigos.Length; i++)
        {
            Debug.Log(enemigos.Length);
            Debug.Log(enemigos[i]);
        }
        
        if (FinJuego)
        {
            return;
        }
        if (Input.GetKeyDown("e"))
        {
            FinDelJuego();
        }
        if(StatsJugagor.Vidas <= 0)
        {
            FinDelJuego();
        }
        if(Spawn_Enemigo.NumeroOleadaW >= Spawn_Enemigo.TotalOleadaW && enemigos.Length == 0)
        {
            GanarNivel();
        }
        
    }

    void FinDelJuego()
    {
        FinJuego = true;
        Debug.Log("Fin del juego");
        GameOverUI.SetActive(true);
    }
    public void GanarNivel()
    {
        FinJuego = true;
        Debug.Log("Fin del juego");
        WinLevelUI.SetActive(true);
    }
}
