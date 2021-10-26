using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    Rigidbody2D body;

    public float speed;
    public float podeMover = 0.0f;
    public int kills;
    public Animator anim;







    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {



        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow) && Time.time > podeMover))
        {
            
            
            body.velocity = new Vector2(speed, 0);
            anim.Play("KillerDireita");
            podeMover = Time.time + 0.5f;
       
        }

        else if (Input.GetKeyDown(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow) && Time.time >= podeMover))
        {
            

            body.velocity = new Vector2(-speed, 0);
            anim.Play("KillerEsquerda");
            podeMover = Time.time + 0.5f;
        }

        else if (Input.GetKeyDown(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow) && Time.time >= podeMover))
        {

            body.velocity = new Vector2(0, speed);
            anim.Play("KillerCima");
            podeMover = Time.time + 0.5f;
        }

        else if (Input.GetKeyDown(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow) && Time.time >= podeMover))
        {

            body.velocity = new Vector2(0, -speed);
            anim.Play("KillerBaixo");
            podeMover = Time.time + 0.5f;
        }


    }
    void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.CompareTag("vitima"))
        {
            kills++;
            if (kills >= 4)

            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }


    }
}
