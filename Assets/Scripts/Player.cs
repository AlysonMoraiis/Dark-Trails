using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    [SerializeField] Rigidbody2D body;

    private int kills;
    [SerializeField] private int vitimas;

    public float speed;

    [HideInInspector]
    public float podeMover = 0.0f;
    public Animator anim;
    public bool direita = false;
    public bool esquerda = false;
    public bool cima = false;
    public bool baixo = false;

    [SerializeField] private SceneTransitions _sceneTransitions;

    [SerializeField] private KillText _killText;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > podeMover)
        {
            body.velocity = new Vector2(speed, 0);
             anim.Play("RunRight");
            DireçãoPersonagem();
            //anim.SetTrigger("AndandoDireita");
            direita = true;
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && Time.time >= podeMover)
        {

            body.velocity = new Vector2(-speed, 0);
             anim.Play("RunLeft");
            DireçãoPersonagem();
            //anim.SetTrigger("AndandoEsquerda");
            esquerda = true;
        }

        else if (Input.GetKey(KeyCode.UpArrow) && Time.time >= podeMover)
        {

            body.velocity = new Vector2(0, speed);
             anim.Play("RunUp");
            //anim.SetTrigger("AndandoCima");
            DireçãoPersonagem();
            cima = true;
        }

        else if (Input.GetKey(KeyCode.DownArrow) && Time.time >= podeMover)
        {

            body.velocity = new Vector2(0, -speed);
             anim.Play("RunDown");
            //anim.SetTrigger("AndandoBaixo");
            DireçãoPersonagem();
            baixo = true;
        }


    }

    private void DireçãoPersonagem()
    {
         baixo = false;
         cima = false;
         direita = false;
         esquerda = false;

        podeMover = Time.time + 1.0f;
    }

    void OnCollisionEnter2D(Collision2D collison)
    {

        if (collison.gameObject.CompareTag("vitima"))
        {
            kills++;
            _killText.KillCount();

            if (kills >= vitimas)

            {
                _killText.SaveKills();
                StartCoroutine(_sceneTransitions.LoadScene());
            }
        }


        if (collison.gameObject.CompareTag("parede"))
        {
            if (direita) // Se direita, ativada antes, for verdadeira
            {
                anim.Play("KillerDireita"); // Rodar animação parada para a direita
                //anim.SetTrigger("Direita");
                PararDireções();
            }
            else if (esquerda) // Se esquerda, ativada antes, for verdadeira
            {
                anim.Play("KillerEsquerda"); // Rodar animação parada para a esquerda
                //anim.SetTrigger("Esquerda");
                PararDireções();
            }
            else if (cima) // Se cima, ativada antes, for verdadeira
            {
                anim.Play("KillerCima"); // Rodar animação parada para cima
                //anim.SetTrigger("Cima");
                PararDireções();
            }
            else if (baixo) // Se baixo, ativada antes, for verdadeira
            {
                //anim.SetTrigger("Baixo");
                anim.Play("KillerBaixo"); // Rodar animação parada para baixo
                PararDireções();
            }


        }
        if (collison.gameObject.CompareTag("vitima"))
        {
            if (direita) // Se direita, ativada antes, for verdadeira
            {
                anim.Play("AttackRight"); // Rodar animação parada para a direita
                //anim.SetTrigger("Direita");
                PararDireções();
            }
            else if (esquerda) // Se esquerda, ativada antes, for verdadeira
            {
                anim.Play("AttackLeft"); // Rodar animação parada para a esquerda
                //anim.SetTrigger("Esquerda");
                PararDireções();
            }
            else if (cima) // Se cima, ativada antes, for verdadeira
            {
                anim.Play("AttackUp"); // Rodar animação parada para cima
                //anim.SetTrigger("Cima");
                PararDireções();
            }
            else if (baixo) // Se baixo, ativada antes, for verdadeira
            {
                anim.Play("AttackDown"); // Rodar animação parada para baixo
                //anim.SetTrigger("Baixo");
                PararDireções();
            }


        }
    }

    private void PararDireções()
    {
        anim.SetBool("RunDown", false);
        anim.SetBool("RunUp", false);
        anim.SetBool("RunLeft", false);
        anim.SetBool("RunRight", false);
        direita = false;
        esquerda = false;
        cima = false;
        baixo = false;
    }



}
