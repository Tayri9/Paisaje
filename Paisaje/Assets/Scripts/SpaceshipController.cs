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
    float timepoReaparicion = 0;

    [SerializeField]
    float tiempoDisparo = 0.75f;

    bool puedeDisparar = true;
    float time = 0;

    bool powerUp;
    float timePower = 0;
    float timeWithPowerUp = 20;

    void Update()
    {
        //transform.position += (transform.forward * Time.deltaTime * speed);
        if (vivo)
        {
            //Movimiento nave
            float rotationX = Input.GetAxis("Vertical") * speedRotationVertical * Time.deltaTime;
            float rotationY = Input.GetAxis("Horizontal") * speedRotationHorizontal * Time.deltaTime;
            float rotationZ = -Input.GetAxis("Horizontal") * speedRotationHorizontal2 * Time.deltaTime;

            /*
            if(Input.GetAxis("Vertical") == 0)
            {
                t = 0;
            }
            transform.Rotate(Mathf.LerpAngle(min, max, t), rotationY, rotationZ, Space.Self);
            */
            transform.Rotate(rotationX, rotationY, rotationZ, Space.Self);
            transform.position += (transform.forward * Time.deltaTime * speed);

            //Disparar
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                if (puedeDisparar)
                {
                    Instantiate(bala, gameObject.transform.position, gameObject.transform.rotation);
                    puedeDisparar = false;
                }

                if (!puedeDisparar)
                {
                    time += Time.deltaTime;
                    if (time >= tiempoDisparo)
                    {
                        puedeDisparar = true;
                        time = 0;
                    }
                }
            }

            if (!puedeDisparar)
            {
                time += Time.deltaTime;
                if(time >= tiempoDisparo)
                {
                    puedeDisparar = true;
                    time = 0;
                }
            }

            if (powerUp)
            {
                timePower += Time.deltaTime;               

                if(timePower >= timeWithPowerUp)
                {
                    powerUp = false;
                    timePower = 0;
                    tiempoDisparo *= 2;
                }
            }

        }
        //Cuando se choca
        else
        {
            timepoReaparicion += Time.deltaTime;

            if (timepoReaparicion >= 3)
            {   
                
                transform.SetPositionAndRotation(posicionInicial, Quaternion.Euler(rotacionInicial));
                //gameObject.GetComponent<Collider>().attachedRigidbody.useGravity = false;
                vivo = true;
                timepoReaparicion = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        vivo = false;
        //gameObject.GetComponent<Collider>().attachedRigidbody.useGravity = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("PowerUp"))
        {
            DestroyPowerUp.instance.Destruir();
            powerUp = true;
            tiempoDisparo /= 2;
        }
    }

}

