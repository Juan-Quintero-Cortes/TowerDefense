using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celda : MonoBehaviour
{
    public Color hoverColor;
    public Color ColorNoHayPlata;
    public Vector3 PosicionOffset;

    [Header("Opcional")]
    public GameObject Torreta;

    private Renderer rend;
    public Color StartColor;

    Construccion construccion;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        construccion = Construccion.instance;
    }

    public Vector3 PosicionConstruccion()
    {
        return transform.position + PosicionOffset;
    }

    void OnMouseDown()
    {
        if (!construccion.SePuedeConstruir)
            return;
        if(Torreta != null)
        {
            Debug.Log("No puedes construir aqui");
            return;
        }
        //Construir torreta
        construccion.ConstruirTorreta(this);
    }

    void OnMouseEnter()
    {
        if (!construccion.SePuedeConstruir)
            return;

        if (construccion.TieneDinero)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = ColorNoHayPlata;
        }

        
    }

    void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
