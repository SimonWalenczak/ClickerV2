using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimForgeron : MonoBehaviour
{

    public int _score;
    public GameObject objet;
    public GameObject objet2;
    float timer = 0.1f;


    public void OnClick()
    {
        _score += 1;

        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        objet.SetActive(true);
        objet2.SetActive(false);
        yield return new WaitForSeconds(timer);
        objet.SetActive(false);
        objet2.SetActive(true);
    }
}