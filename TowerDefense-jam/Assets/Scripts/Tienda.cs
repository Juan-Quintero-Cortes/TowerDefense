using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{

    public BlueprintTorreta TorretaFuego;
    public BlueprintTorreta TorretaAmetralladora;
    public BlueprintTorreta TorretaFrancotirador;
    public BlueprintTorreta TorretaSoporte;
    public BlueprintTorreta TorretaDefensa;
    Construccion construccion;
    void Start()
    {
        construccion = Construccion.instance;
    }
    public void SeleccionarTorretaFuego()
    {
        Debug.Log("Compra de torreta de fuego");
        construccion.SeleccionarTorretaAConstruir(TorretaFuego);
    }
    public void SeleccionarTorretaAmetralladora()
    {
        Debug.Log("Compra de torreta ametralladora");
        construccion.SeleccionarTorretaAConstruir(TorretaAmetralladora);
    }
    public void SeleccionarTorretaFrancotirador()
    {
        Debug.Log("Compra de torreta Francotirador");
        construccion.SeleccionarTorretaAConstruir(TorretaFrancotirador);
    }
    public void SeleccionarTorretaSoporte()
    {
        Debug.Log("Compra de torreta Soporte");
        construccion.SeleccionarTorretaAConstruir(TorretaSoporte);
    }
    public void SeleccionarTorretaDefensa()
    {
        Debug.Log("Compra de torreta Defensa");
        construccion.SeleccionarTorretaAConstruir(TorretaDefensa);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
