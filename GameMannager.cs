using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMannager : MonoBehaviour

{
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Sumar(int puntossumar)
    {
        puntosTotales += puntossumar;
        Debug.Log(puntosTotales);
    }
}
