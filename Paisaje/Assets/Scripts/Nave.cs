using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField]
    GameObject[] ruta;

    [SerializeField]
    int i = 1, speed = 5;

    [SerializeField]
    float posicionX, posicionY, posicionZ;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(ruta[i].transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(i > ruta.Length - 1)
        {
            i = 0;
        }        

        posicionX = ruta[i].transform.position.x;
        posicionY = ruta[i].transform.position.y;
        posicionZ = ruta[i].transform.position.z;

        transform.position += transform.forward * Time.deltaTime * speed;             
    }

    private void OnTriggerEnter(Collider punto)
    {
        i++;
        transform.LookAt(ruta[i].transform);
        Debug.Log(i);
    }
}

/*
 Crear un sistema de caminios para naves enemigas
- Requiere el uso de un array de GameObjects vacios (GameObject[] ruta)
- Acceder a cada punto del array y dirigir la nave hacia el siguiente (ruta[siguientePunto])
- Usar transform.LookAt(ruta[siguientePunto].transform) para que la nave mire hacia ese punto
- Tenemos que modificar la posición del objeto (transform.position) 
 */