using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator transitionAnim;
    public Player _player;

    private void Start()
    {
        _player.podeMover = Time.time + 2.5f;
        StartCoroutine(StartScene());
    }

    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.8f);
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator StartScene()
    {
        transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(0.8f);
    }
}
