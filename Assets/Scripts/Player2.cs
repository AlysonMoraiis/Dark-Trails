using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    
    
    Rigidbody2D body;
    public int kills;
    public float speed;
    public float podeMover = 0.0f;
    public Animator anim;
    public bool direita = false;
    public bool esquerda = false;
    public bool cima = false;
    public bool baixo = false;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }
    void Start()
    {
       
    }
    void FixedUpdate()
    {




        if (Input.GetKey(KeyCode.RightArrow) && Time.time > podeMover)
        {


            body.velocity = new Vector2(speed, 0);
            anim.Play("RunRight");
            direita = true; // Boolean para ativar a animação parada para a direita depois
            baixo = false;
            cima = false;
            esquerda = false;

            podeMover = Time.time + 1.0f;
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && Time.time >= podeMover)
        {

            body.velocity = new Vector2(-speed, 0);
            anim.Play("RunLeft");
            esquerda = true; // Boolean para ativar a animação parada para a esquerda depois
            baixo = false;
            direita = false;
            cima = false;

            podeMover = Time.time + 1.0f;
        }

        else if (Input.GetKey(KeyCode.UpArrow) && Time.time >= podeMover)
        {

            body.velocity = new Vector2(0, speed);
            anim.Play("RunUp");
            cima = true;// Boolean para ativar a animação parada para cima depois
            baixo = false;
            direita = false;
            esquerda = false;

            podeMover = Time.time + 1.0f;
        }

        else if (Input.GetKey(KeyCode.DownArrow) && Time.time >= podeMover)
        {

            body.velocity = new Vector2(0, -speed);
            anim.Play("RunDown");
            baixo = true; // Boolean para ativar a animação parada para baixo depois
            cima = false;
            direita = false;
            esquerda = false;

            podeMover = Time.time + 1.0f;
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


        if (collison.gameObject.CompareTag("parede"))
        {
            if (direita) // Se direita, ativada antes, for verdadeira
            {
                anim.SetBool("RunRight", false);
                anim.Play("KillerDireita"); // Rodar animação parada para a direita
                direita = false; // Desativar todas as váriaveis.
                esquerda = false;
                cima = false;
                baixo = false;
            }
            else if (esquerda) // Se esquerda, ativada antes, for verdadeira
            {
                anim.SetBool("RunLeft", false);
                anim.Play("KillerEsquerda"); // Rodar animação parada para a esquerda
                direita = false;
                esquerda = false;
                cima = false;
                baixo = false;
            }
            else if (cima) // Se cima, ativada antes, for verdadeira
            {
                anim.SetBool("RunUp", false);
                anim.Play("KillerCima"); // Rodar animação parada para cima
                direita = false;
                esquerda = false;
                cima = false;
                baixo = false;
            }
            else if (baixo) // Se baixo, ativada antes, for verdadeira
            {
                anim.SetBool("RunDown", false);
                anim.Play("KillerBaixo"); // Rodar animação parada para baixo
                direita = false;
                esquerda = false;
                cima = false;
                baixo = false;
            }


        }
        if (collison.gameObject.CompareTag("vitima"))
        {
            if (direita) // Se direita, ativada antes, for verdadeira
            {
                anim.SetBool("RunRight", false);
                anim.Play("AttackRight"); // Rodar animação parada para a direita
                direita = false; // Desativar todas as váriaveis.
                esquerda = false;
                cima = false;
                baixo = false;
            }
            else if (esquerda) // Se esquerda, ativada antes, for verdadeira
            {
                anim.SetBool("RunLeft", false);
                anim.Play("AttackLeft"); // Rodar animação parada para a esquerda
                direita = false;
                esquerda = false;
                cima = false;
                baixo = false;
            }
            else if (cima) // Se cima, ativada antes, for verdadeira
            {
                anim.SetBool("RunUp", false);
                anim.Play("AttackUp"); // Rodar animação parada para cima
                direita = false;
                esquerda = false;
                cima = false;
                baixo = false;
            }
            else if (baixo) // Se baixo, ativada antes, for verdadeira
            {
                anim.SetBool("RunDown", false);
                anim.Play("AttackDown"); // Rodar animação parada para baixo
                direita = false;
                esquerda = false;
                cima = false;
                baixo = false;
            }


        }
    }


}
