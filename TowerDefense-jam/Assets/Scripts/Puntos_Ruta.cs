using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Puntos_Ruta : MonoBehaviour
{
    public static Transform[] Puntos;

    void Awake()
    {
        Puntos = new Transform[transform.childCount];
        for(int i = 0; i < Puntos.Length; i++)
        {
            Puntos[i] = transform.GetChild(i);
        }
    }
}
