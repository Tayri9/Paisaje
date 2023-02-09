using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;

    [SerializeField]
    float speedRotationVertical = 50f;

    [SerializeField]
    float speedRotationHorizontal = 30f;

    [SerializeField]
    float speedRotationHorizontal2 = 20f;

    [SerializeField]
    GameObject bala;

    [SerializeField]
    Vector3 posicionInicial, rotacionInicial;

    bool vivo = true;
    float time = 0;
    float max, min, t;


    void Update()
    {
        //transform.position += (transform.forward * Time.deltaTime * speed);
        if (vivo)
        {
            //Movimiento nave
            float rotationX = Input.GetAxis("Vertical") * speedRotationVertical * Time.deltaTime;
            float rotationY = Input.GetAxis("Horizontal") * speedRotationHorizontal * Time.deltaTime;
            float rotationZ = -Input.GetAxis("Horizontal") * speedRotationHorizontal2 * Time.deltaTime;

            
            if(Input.GetAxis("Vertical") == 0)
            {
                t = 0;
            }
            
            transform.Rotate(Mathf.LerpAngle(min, max, t), rotationY, rotationZ, Space.Self);
            transform.position += (transform.forward * Time.deltaTime * speed);

            //Disparar
            if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
            {
                Instantiate(bala, gameObject.transform.position, gameObject.transform.rotation);
            }
        }
        //Cuando se choca
        else
        {
            time += Time.deltaTime;

            if (time >= 3)
            {   
                
                transform.SetPositionAndRotation(posicionInicial, Quaternion.Euler(rotacionInicial));
                gameObject.GetComponent<Collider>().attachedRigidbody.useGravity = false;
                vivo = true;
                time = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        vivo = false;
        gameObject.GetComponent<Collider>().attachedRigidbody.useGravity = true;
    }

}

