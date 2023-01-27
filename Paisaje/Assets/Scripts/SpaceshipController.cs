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

    void Update()
    {
        float rotationX = Input.GetAxis("Vertical") * speedRotationVertical * Time.deltaTime;
        float rotationY = Input.GetAxis("Horizontal") * speedRotationHorizontal * Time.deltaTime;
        float rotationZ = -Input.GetAxis("Horizontal") * speedRotationHorizontal * Time.deltaTime;

        transform.Rotate(rotationX, rotationY, rotationZ, Space.Self);

        transform.position += (transform.forward * Time.deltaTime * speed);
        
    }
}
