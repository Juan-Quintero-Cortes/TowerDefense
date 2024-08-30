using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganar : MonoBehaviour
{
    public CambioEscena cambioescena;

    public void Continuar()
    {
        cambioescena.FadeTo("SecondLevel");
    }

    public void menu()
    {
        cambioescena.FadeTo("MenuPrincipal");
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
