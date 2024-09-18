using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torreta_Defensa : MonoBehaviour
{

    public float TiempoVida = 3f;
    public float Delay;

    
    // Start is called before the first frame update
    void Start()
    {
        Delay = TiempoVida;
    }

    // Update is called once per frame
    void Update()
    {
        if(Delay <= 0)
        {
            Destroy(gameObject);
        }
        Delay -= Time.deltaTime;
    }
}
