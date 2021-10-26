using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vitima : MonoBehaviour
{
    public GameObject bloodExplosion;
    public Animator morteCubo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collison)
    {

        if (collison.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Renderer>().enabled = false;
            Instantiate(bloodExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject, 2);
        }
        
    }
}
