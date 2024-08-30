using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawn_Enemigo : MonoBehaviour
{
    public Transform PrefabEnemigo1;
    public Transform PrefabEnemigo2;

    public Transform PuntoSpawn;

    public Text TxtNumeroOleada;
    public int NumeroOleada = 0;
    public int TotalOleada = 5;
    public static int NumeroOleadaW = 0;
    public static int TotalOleadaW;
    public float Delay_Oleadas = 3f;
    private float Cuenta_Atras = 2f;
    private int TipoEnemigo;

    private int Indice_Oleada = 0;
    // Start is called before the first frame update
    void Start()
    {
        TotalOleadaW = TotalOleada;
        NumeroOleada = 0;
        NumeroOleadaW = NumeroOleada;
    }

    // Update is called once per frame
    void Update()
    {
        if(NumeroOleada <= TotalOleada-1)
        {
            if (Cuenta_Atras <= 0)
            {
                StartCoroutine(SpawnOleada());
                Cuenta_Atras = Delay_Oleadas;
                NumeroOleada++;
                NumeroOleadaW++;
            }
        }
        Cuenta_Atras -= Time.deltaTime;
        TxtNumeroOleada.text = "oleada #" + NumeroOleada;
    }

    IEnumerator SpawnOleada()
    {
        
        Indice_Oleada++;
        StatsJugagor.Oleadas++;
        Debug.Log("Oleada!!!");
        int NumeroEnemigo = UnityEngine.Random.Range(1, 5);
        for(int i = 0; i < NumeroEnemigo; i++)
        {
            SpawnEnemigo();
            yield return new WaitForSeconds(0.5f);
        }
        if (TipoEnemigo == 1)
        {
            TipoEnemigo = 2;
        }
        else
        {
            TipoEnemigo = 1;
        }

    }
    void SpawnEnemigo()
    {
        
        if(TipoEnemigo == 1)
        {
            Instantiate(PrefabEnemigo1, PuntoSpawn.position, PuntoSpawn.rotation);
        }
        else
        {
            Instantiate(PrefabEnemigo2, PuntoSpawn.position, PuntoSpawn.rotation);
        }
        

    }    
}
