using UnityEngine;
using System.Collections;

public class Moneda : MonoBehaviour
{
    public int valor = 50;
    public float tiempoDeVida = 6f;

    private bool Clicked = false;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(Desaparecer());
    }

    void OnMouseDown()
    {
        if (!Clicked)
        {
            Clicked = true;
            StatsJugagor.Dinero += valor;
            Destroy(gameObject);
        }
    }

    IEnumerator Desaparecer()
    {
        yield return new WaitForSeconds(tiempoDeVida);


        if (!Clicked)
        {
            Destroy(gameObject);
        }
    }
}