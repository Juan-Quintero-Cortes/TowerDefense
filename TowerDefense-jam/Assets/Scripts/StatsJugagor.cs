using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StatsJugagor : MonoBehaviour
{
    public static int Dinero;
    public int DineroInicial = 600;

    public static int Oleadas;
    public static int Vidas;
    public int Vida_Inicial = 20; 
    public static int Vida_Inicial_UI;
    // Start is called before the first frame update
    void Start()
    {
        Dinero = DineroInicial;
        Vidas = Vida_Inicial;
        Vida_Inicial_UI = Vida_Inicial;
        Oleadas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
