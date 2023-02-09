using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField]
    GameObject[] ruta;

    [SerializeField]
    int i = 0, speed = 11, vida = 5;

    bool vivo = true;

    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(ruta[i].transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

        if (!vivo)
        {
            time += Time.deltaTime;

            if(time >= 3)
            {
                Destroy(gameObject);
            }
        }                  
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Punto"))
        {
            i++;
            if (i >= ruta.Length)
            {
                i = 0;
            }
            transform.LookAt(ruta[i].transform);
            //Debug.Log("punto: " + col + " i: " + i);
        }

        if (col.CompareTag("Bala"))
        {
            //Debug.Log("Tocado");
            vida--;
            if (vida == 0)
            {
                vivo = false;
                gameObject.GetComponent<Collider>().attachedRigidbody.useGravity = true;
                speed -= 5;
                //Destroy(gameObject);                
            }
        }
       
    }
}

/*
 Crear un sistema de caminios para naves enemigas
- Requiere el uso de un array de GameObjects vacios (GameObject[] ruta)
- Acceder a cada punto del array y dirigir la nave hacia el siguiente (ruta[siguientePunto])
- Usar transform.LookAt(ruta[siguientePunto].transform) para que la nave mire hacia ese punto
- Tenemos que modificar la posición del objeto (transform.position) 
 */