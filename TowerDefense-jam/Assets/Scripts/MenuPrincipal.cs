using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public string Nivel = "SeleccionNivel";
    public CambioEscena Cambioescena;
    public void Play()
    {
        Cambioescena.FadeTo("Tutorial");
        Debug.Log("Play");
    }

    public void Quit()
    {
        Debug.Log("Saliendo");
        Application.Quit();
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

