using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;

    [SerializeField]
    float speedRotationVertical = 30f;

    void Update()
    {
        float rotationZ = Input.GetAxis("Vertical") * speedRotationVertical * Time.deltaTime;
        float rotationY = Input.GetAxis("Horizontal") * speedRotationVertical * Time.deltaTime;

        transform.Rotate(0f, rotationY, rotationZ, Space.Self);

        transform.position += (transform.right * Time.deltaTime * speed);
        
    }
}
