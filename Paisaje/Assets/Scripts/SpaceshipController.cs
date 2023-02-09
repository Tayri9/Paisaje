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

    void Update()
    {
        float rotationX = Input.GetAxis("Vertical") * speedRotationVertical * Time.deltaTime;
        float rotationY = Input.GetAxis("Horizontal") * speedRotationHorizontal * Time.deltaTime;
        float rotationZ = -Input.GetAxis("Horizontal") * speedRotationHorizontal2 * Time.deltaTime;

        transform.Rotate(rotationX, rotationY, rotationZ, Space.Self);

        transform.position += (transform.forward * Time.deltaTime * speed);

        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {

            Instantiate(bala, gameObject.transform.position, gameObject.transform.rotation);

            //Instantiate(bala, gameObject.transform.position, Quaternion.identity);
            //Instantiate(bala, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3, gameObject.transform.position.z), gameObject.transform.rotation);
        }
    }
}

//3