using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public CambioEscena Cambioescena;
    public void Play()
    {
        Cambioescena.FadeTo("SeleccionNivel");
        Debug.Log("Play");
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
