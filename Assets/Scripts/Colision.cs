using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // onCollisionEnter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        //GetComponent<Renderer>().material.color=Color.green;
        Debug.Log(collision.gameObject.name);
        }
}