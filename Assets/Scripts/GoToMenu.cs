﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToMenuu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
