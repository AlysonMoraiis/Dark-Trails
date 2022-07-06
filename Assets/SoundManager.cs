using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    void Awake()
    {
        for(int i =0; i < Object.FindObjectsOfType<SoundManager>().Length; i++)
        {
            if(Object.FindObjectsOfType<SoundManager>()[i] != this)
            {
                Destroy(gameObject);
                Debug.Log("Destrou Sound Clone");
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
