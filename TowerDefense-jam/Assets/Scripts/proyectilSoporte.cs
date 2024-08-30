using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectilSoporte : MonoBehaviour
{
    private Transform objetivo;

    public float velocidad = 70f;

    public int Daño = 20;

    public void Perseguir(Transform _objetivo)
    {
        objetivo = _objetivo;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (objetivo == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = objetivo.position - transform.position;
        float DistanciaEnFrame = velocidad * Time.deltaTime;

        if (dir.magnitude <= DistanciaEnFrame)
        {
            AlcanzaObjetivo();
            return;
        }
        transform.Translate(dir.normalized * DistanciaEnFrame, Space.World);
        transform.LookAt(objetivo);
    }

    void AlcanzaObjetivo()
    {
        Debug.Log("Alcanzo objetivo");

        Damage(objetivo);
        Destroy(gameObject);
    }
    void Damage(Transform enemigo)
    {
        Enemigos e = enemigo.GetComponent<Enemigos>();
        if (e != null)
        {
            e.Lento();
        }
    }
}
