using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiDinero : MonoBehaviour
{
    public Text TxtDinero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TxtDinero.text = "$" + StatsJugagor.Dinero.ToString();
    }
}
