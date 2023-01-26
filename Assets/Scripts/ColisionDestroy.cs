using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDestroy : MonoBehaviour
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
    void OnCollisionEnter(Collision collision)
   {
      Destroy(gameObject);
   }
}
