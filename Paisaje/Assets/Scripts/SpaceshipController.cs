using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;

    [SerializeField]
    float speedRotationVertical = 30f;

    [SerializeField]
    float speedRotationHorizontal = 20f;

    void Update()
    {
        float rotationZ = Input.GetAxis("Vertical") * speedRotationVertical * Time.deltaTime;
        float rotationY = Input.GetAxis("Horizontal") * speedRotationHorizontal * Time.deltaTime;
        float rotationX = -Input.GetAxis("Horizontal") * speedRotationHorizontal * Time.deltaTime;

        transform.Rotate(rotationX, rotationY, rotationZ, Space.Self);

        transform.position += (transform.right * Time.deltaTime * speed);
        
    }
}
