using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroEnemy : MonoBehaviour
{
    public bool der;

    public float speed;
    public float tiempoReversa;

    private float tiempoReversaAux;
    private Rigidbody rb;
    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        if(der)
        {
            speed *= -1;
        }
        trans = GetComponent<Transform>();
        tiempoReversaAux = tiempoReversa;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoReversa -= Time.deltaTime;
        if(tiempoReversa<=0)
        {
            speed *= -1;
            tiempoReversa = tiempoReversaAux;
        }
        comprobarRotacion();
    }

    private void FixedUpdate()
    {
        trans.position += new Vector3(speed, 0, 0);
    }

    private void comprobarRotacion()
    {
        if(speed>0)
        {
            //trans.transform.Rotate(0, 90, 0);
            trans.rotation = Quaternion.Euler(0, 90, 0);
            //trans.rotation = new Vector3(0, 90, 0);
        }
        else
        {
            trans.rotation = Quaternion.Euler(0, -90, 0);
            //trans.transform.Rotate(0, -90, 0);
        }
    }
}
