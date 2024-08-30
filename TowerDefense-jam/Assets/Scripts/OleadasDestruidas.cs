using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OleadasDestruidas : MonoBehaviour
{
    public Text TxtOleadas;

    void OnEnable()
    {
        StartCoroutine(AnimarTexto());
        TxtOleadas.text = StatsJugagor.Oleadas.ToString();
    }

    IEnumerator AnimarTexto()
    {
        TxtOleadas.text = "0";
        int oleada = 0;

        yield return new WaitForSeconds(0.7f);

        while (oleada < StatsJugagor.Oleadas)
        {
            oleada++;
            TxtOleadas.text = oleada.ToString();

            yield return new WaitForSeconds(0.05f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
