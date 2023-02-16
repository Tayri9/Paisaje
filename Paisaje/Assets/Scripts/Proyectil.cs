using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField]
    float speed = 60, time = 0;

    //Vector3 direccionFuerza;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<Rigidbody>().AddForce(direccionFuerza, ForceMode.Impulse);

        transform.position += transform.forward * Time.deltaTime * speed;
        time += Time.deltaTime;

        if (time > 10)
        {
            Destroy(gameObject);
        }
    }
}
