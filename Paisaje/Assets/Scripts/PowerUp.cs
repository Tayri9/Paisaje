using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static PowerUp instance;

    [SerializeField]
    GameObject powerUp;

    [SerializeField]
    GameObject[] spawn;

    [SerializeField]
    float tiempoMin=20, tiempoMax=40, tiempo=40;

    float time = 0;

    [SerializeField]
    float tiempoAparecer;
    int puedeAparecer = 2;
    int posicion;

    private void Awake()
    {
        if (PowerUp.instance == null)
        {
            PowerUp.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        tiempoAparecer = Random.Range(tiempoMin, tiempoMax);
        puedeAparecer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeAparecer == 0)
        {
            tiempoAparecer = Random.Range(tiempoMin, tiempoMax) + tiempo;
            posicion = (int) Random.Range(0, spawn.Length - 1);
            puedeAparecer = 1;
        }
        else if (puedeAparecer == 1)
        {
            time += Time.deltaTime;

            if (time >= tiempoAparecer)
            {
                Instantiate(powerUp, spawn[posicion].transform.position, Quaternion.identity);
                puedeAparecer = 2;
                time = 0;
            }
        }

    }

    public void Cogido()
    {        
        puedeAparecer = 0;
    }
    
}
