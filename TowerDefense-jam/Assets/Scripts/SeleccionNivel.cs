using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionNivel : MonoBehaviour
{
    public CambioEscena cambioescena;
    public void Seleccionar (string NombreNivel)
    {
        cambioescena.FadeTo(NombreNivel);
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
