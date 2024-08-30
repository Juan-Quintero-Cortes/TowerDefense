using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TorretaSoporte : MonoBehaviour
{
    private Transform objetivo;
    [Header("Atributos")]
    public float rango = 10f;
    public float VelocidadDisparo = 1f;
    private float ConteoDisparo = 0f;

    [Header("Cosas unity, No tocar")]
    public string TagEnemigo = "Enemigo";

    public Transform PartesRotatorias;
    public float velocidadRotacion = 10f;

    public GameObject PrefabProyectil;
    public Transform SalidaProyectil;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateObjetivo", 0f, 0.5f);
    }

    void UpdateObjetivo()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(TagEnemigo);
        float DistaciaCercana = Mathf.Infinity;
        GameObject EnemegoMasCercano = null;

        foreach (GameObject enemigo in enemigos)
        {
            Enemigos e = enemigo.GetComponent<Enemigos>();
            float DistanciaAlEnemigo = Vector3.Distance(transform.position, enemigo.transform.position);
            if (DistanciaAlEnemigo < DistaciaCercana &&  e.Detenido != true)
            {
                DistaciaCercana = DistanciaAlEnemigo;
                EnemegoMasCercano = enemigo;
            }
        }

        if (EnemegoMasCercano != null && DistaciaCercana <= rango)
        {
            objetivo = EnemegoMasCercano.transform;
        }
        else
        {
            objetivo = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (objetivo == null)
            return;

        Vector3 dir = objetivo.position - transform.position;
        Quaternion RotacionVista = Quaternion.LookRotation(dir);
        Vector3 rotacion = Quaternion.Lerp(PartesRotatorias.rotation, RotacionVista, Time.deltaTime * velocidadRotacion).eulerAngles;
        PartesRotatorias.rotation = Quaternion.Euler(0f, rotacion.y, 0f);

        if (ConteoDisparo <= 0f)
        {
            Disparo();
            ConteoDisparo = 1f / VelocidadDisparo;
        }
        ConteoDisparo -= Time.deltaTime;
    }

    void Disparo()
    {
        GameObject ProyectilSoporteGo = (GameObject)Instantiate(PrefabProyectil, SalidaProyectil.position, SalidaProyectil.rotation);
        proyectilSoporte proyectilSoporte = ProyectilSoporteGo.GetComponent<proyectilSoporte>();

        if (proyectilSoporte != null)
            proyectilSoporte.Perseguir(objetivo);
        Debug.Log("Disparo");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
