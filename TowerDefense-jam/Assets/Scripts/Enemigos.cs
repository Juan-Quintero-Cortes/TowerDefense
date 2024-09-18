using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemigos : MonoBehaviour
{
    private float velocidad = 3.5f;
    public float vidaInicial = 100f;
    public float vida;
    public bool Detenido = false;
    public Image BarraVida;
    public int daño;
    public int DineroGanado = 50;
    public Vector3 destinoFinal;
    public GameObject monedaPrefab; // Prefab de la moneda que aparecerá
    private float rango = 3f;


    private bool EstaMuerto = false;
    private NavMeshAgent agente;
    private float radioDestino = 0.5f;
    public string TagDefensa = "Defensa";
    public Transform TDefensa;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        vida = vidaInicial;
        agente.stoppingDistance = radioDestino;
        agente.SetDestination(destinoFinal);
        InvokeRepeating("Defensas", 0f, 0.5f);
    }

    void Defensas()
    {
        GameObject[] Defensas = GameObject.FindGameObjectsWithTag(TagDefensa);
        float DistaciaCercana = Mathf.Infinity;
        GameObject DefensaMasCercana = null;

        foreach (GameObject Defensa in Defensas)
        {
            float DistanciaAlEnemigo = Vector3.Distance(transform.position, Defensa.transform.position);
            if (DistanciaAlEnemigo <= DistaciaCercana)
            {
                DistaciaCercana = DistanciaAlEnemigo;
                DefensaMasCercana = Defensa;
            }
        }
        if (DefensaMasCercana != null && DistaciaCercana <= rango)
        {
            Debug.Log("Defensa");
            agente.speed = 0f;
            TDefensa = DefensaMasCercana.transform;
        }
        else
        {
            agente.speed = velocidad;
            TDefensa = null;
        }
    }

    public void Daño(int cantidad)
    {
        vida -= cantidad;
        BarraVida.fillAmount = vida / vidaInicial;
        if (vida <= 0 && !EstaMuerto)
        {
            Muerte();
        }
    }

    public void Lento()
    {
        if (!Detenido)
        {
            agente.speed -= 5f;
            Detenido = true;
        }
    }

    void Muerte()
    {
        EstaMuerto = true;
        SpawnMoneda();
        Destroy(gameObject);
    }

    void SpawnMoneda()
    {
        Vector3 spawnPosition = GetCenterPositionOnSueloLayer();
        if (spawnPosition != Vector3.zero)
        {
            GameObject monedaObj = Instantiate(monedaPrefab, spawnPosition, Quaternion.identity);
            Moneda moneda = monedaObj.GetComponent<Moneda>();
            if (moneda != null)
            {
                moneda.valor = DineroGanado;
            }
            else
            {
                Debug.LogError("El prefab de moneda no tiene el componente Moneda adjunto.");
            }
        }
        else
        {
            Debug.LogWarning("No se pudo encontrar una posición válida para spawner la moneda.");
        }
    }

    Vector3 GetCenterPositionOnSueloLayer()
    {
        // Obtener todos los colliders en la capa "suelo"
        Collider[] sueloColliders = Physics.OverlapSphere(Vector3.zero, Mathf.Infinity, LayerMask.GetMask("suelo"));
        
        if (sueloColliders.Length > 0)
        {
            // Elegir un collider aleatorio
            Collider randomCollider = sueloColliders[Random.Range(0, sueloColliders.Length)];
            
            // Obtener el centro del collider
            Vector3 centerPoint = randomCollider.bounds.center;
            
            // Ajustar la altura
            centerPoint.y = randomCollider.bounds.max.y + 3f;
            
            return centerPoint;
        }
        
        return Vector3.zero; // Retornar Vector3.zero si no se encuentra ningún objeto en la capa "suelo"
    }

    void Update()
    {
        if (!agente.pathPending && agente.remainingDistance <= agente.stoppingDistance)
        {
            if (!agente.hasPath || agente.velocity.sqrMagnitude == 0f)
            {
                FinDelCamino();
            }
        }
    }


    void FinDelCamino()
    {
        StatsJugagor.Vidas -= daño;
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}