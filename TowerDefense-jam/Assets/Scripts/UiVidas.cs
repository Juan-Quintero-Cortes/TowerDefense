using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiVidas : MonoBehaviour
{
    public Text TxtVida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TxtVida.text = StatsJugagor.Vidas + "/" + StatsJugagor.Vida_Inicial_UI;
    }
}
