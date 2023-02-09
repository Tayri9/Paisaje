using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigo : MonoBehaviour
{
    public static SpawnEnemigo instance;

    [SerializeField]
    GameObject enemigo;

    [SerializeField]
    public GameObject[] ruta;

    public bool spawn = false;

    private void Awake()
    {
        if (SpawnEnemigo.instance == null)
        {
            SpawnEnemigo.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            Instantiate(enemigo, gameObject.transform.position, Quaternion.identity);
            spawn = false;
        }
    }
}
