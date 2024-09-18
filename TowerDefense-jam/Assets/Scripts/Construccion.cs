using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construccion : MonoBehaviour
{
    public static Construccion instance;

    void Awake()
    {
        instance = this;
    }

    public GameObject PrefabTorretaFuego;
    public GameObject PrefabTorretaAmetralladora;
    public GameObject PrefabTorretaFrancotirador;
    public GameObject PrefabTorretaSoporte;
    public GameObject PrefabTorretaDefensa;
    public string TagDefensa = "Defensa";
    public string TagCeldaDefensa = "CeldaDefensa";

    private BlueprintTorreta TorretaAConstruir;

   public bool SePuedeConstruir { get { return TorretaAConstruir != null; } }
   public bool TieneDinero { get { return StatsJugagor.Dinero >= TorretaAConstruir.Costo; } }

    public void ConstruirTorreta(Celda celda)
    {
        if(StatsJugagor.Dinero < TorretaAConstruir.Costo)
        {
            Debug.Log("No hay plata");
            return;
        }
        if(celda.CompareTag(TagCeldaDefensa))
        {
            Debug.Log("Celda de defensa");
            if (TorretaAConstruir.prefab.CompareTag(TagDefensa))
            {
                Debug.Log("torreta de defensa");
            }
            else
            {
                Debug.Log("Torreta normal");
                return;
            }
        }
        else
        {
            Debug.Log("Celda normal");
            if (TorretaAConstruir.prefab.CompareTag(TagDefensa))
            {
                Debug.Log("torreta de defensa");
                return;
            }
            else
            {
                Debug.Log("Torreta normal");
            }
        }
        StatsJugagor.Dinero -= TorretaAConstruir.Costo;

        GameObject torreta = (GameObject)Instantiate(TorretaAConstruir.prefab, celda.PosicionConstruccion(), Quaternion.identity);
        celda.Torreta = torreta;

        Debug.Log("Torreta construida, queda " + StatsJugagor.Dinero + " Dinero");
    }

       

    public void SeleccionarTorretaAConstruir(BlueprintTorreta torreta)
    {
        TorretaAConstruir = torreta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

