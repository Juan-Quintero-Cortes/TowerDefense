using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausaUI;

    public CambioEscena cambioescena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cambio();
        }
    }

    public void Cambio()
    {
        menuPausaUI.SetActive(!menuPausaUI.activeSelf);

        if (menuPausaUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Reiniciar()
    {
        Cambio();
        cambioescena.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Cambio();
        cambioescena.FadeTo("MenuPrincipal");
        Debug.Log("Menu");
    }
}
