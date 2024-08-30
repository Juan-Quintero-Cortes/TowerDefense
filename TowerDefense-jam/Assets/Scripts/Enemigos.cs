using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigos : MonoBehaviour
{
    public float velocidad = 10f;

    public float vidaInicial = 100f;
    public float vida;

    public bool Detenido= false;

    public Image BarraVida;

    private bool EstaMuerto = false;

    public int daño;

    public int DineroGanado = 50;
    private Transform objetivo;
    private int Indice_Punto_Ruta = 0;
    // Start is called before the first frame update
    void Start()
    {
        objetivo = Puntos_Ruta.Puntos[0];
        vida = vidaInicial;
    }

    public void Daño(int cantidad)
    {
        vida -= cantidad;

        BarraVida.fillAmount = vida/vidaInicial;
        Debug.Log(vida / vidaInicial);

        if(vida<=0 && !EstaMuerto)
        {
            Muerte();
        }
    }

    public void Lento()
    {
        if(Detenido!=true)
        {
            velocidad -= 5f;
            Detenido = true;
        }
    }

    void Muerte()
    {
        EstaMuerto = true;
        StatsJugagor.Dinero += DineroGanado;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Dir = objetivo.position - transform.position;
        transform.Translate(Dir.normalized * velocidad * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, objetivo.position) <= 0.2f)
        {
            SiguientPunto_Ruta();
        }
    }

    void SiguientPunto_Ruta()
    {
        if (Indice_Punto_Ruta >=Puntos_Ruta.Puntos.Length - 1) 
        {
            FinDelCamino();
            return;
        }
        Indice_Punto_Ruta++;
        objetivo = Puntos_Ruta.Puntos[Indice_Punto_Ruta];
    }

    void FinDelCamino()
    {
        StatsJugagor.Vidas = StatsJugagor.Vidas - daño;
        Destroy(gameObject);
    }
}
