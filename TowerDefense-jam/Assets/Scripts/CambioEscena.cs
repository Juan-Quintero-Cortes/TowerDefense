using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CambioEscena : MonoBehaviour
{
    public UnityEngine.UI.Image imagen;
    public AnimationCurve curva;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string Escena)
    {
        StartCoroutine(FadeOut(Escena));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while(t > 0f)
        {
            t -= Time.deltaTime;
            float a = curva.Evaluate(t);
            imagen.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string Escena)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curva.Evaluate(t);
            imagen.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        SceneManager.LoadScene(Escena);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
