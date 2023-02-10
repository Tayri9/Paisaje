using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUp : MonoBehaviour
{
    public static DestroyPowerUp instance;
    private void Awake()
    {
        if (DestroyPowerUp.instance == null)
        {
            DestroyPowerUp.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Destruir()
    {
        PowerUp.instance.Cogido();
        Destroy(gameObject);
    }
}
