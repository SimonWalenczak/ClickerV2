using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Progression : MonoBehaviour
{
    public TextMeshProUGUI Etat;
    public GameManager gameManager;

    public Crafting _crafting;
    public Image barre_verte1;
    public Image barre_verte2;
    public Image barre_verte3;
    public Image barre_verte4;
    public Image barre_verte5;
    public Image barre_verte6;
    public Image barre_verte7;
    public Image barre_verte8;

    float timer = 0.5f;
    void Update()
    {
        if (GameObject.Find("Barre_craft_1"))
        {
            if (gameManager.progressCraft < 25)
            {
                Etat.SetText("Epée en cours...");
                barre_verte1.fillAmount = (float)gameManager.progressCraft / 25f;
            }
            else
            {
                Etat.SetText("Terminé !");
                barre_verte1.fillAmount = 1;
                StartCoroutine(Valide());
            }
        }
        else if (GameObject.Find("Barre_craft_2"))
        {
            if (gameManager.progressCraft < 35)
            {
                Etat.SetText("Arbalète en cours...");
                barre_verte2.fillAmount = (float)gameManager.progressCraft / 35f;
            }
            else
            {
                Etat.SetText("Terminé !");
                barre_verte2.fillAmount = 1;
                StartCoroutine(Valide());
            }
        }
        else if (GameObject.Find("Barre_craft_3"))
        {
            if (gameManager.progressCraft < 50)
            {
                Etat.SetText("Baton de feu en cours...");
                barre_verte3.fillAmount = (float)gameManager.progressCraft / 50f;
            }
            else
            {
                Etat.SetText("Terminé !");
                barre_verte3.fillAmount = 1;
                StartCoroutine(Valide());
            }
        }
        else if (GameObject.Find("Barre_craft_4"))
        {
            if (gameManager.progressCraft < 75)
            {
                Etat.SetText("Faux de guerre en cours...");
                barre_verte4.fillAmount = (float)gameManager.progressCraft / 75f;
            }
            else
            {
                Etat.SetText("Terminé !");
                barre_verte4.fillAmount = 1;
                StartCoroutine(Valide());
            }
        }
        else if (GameObject.Find("Barre_craft_5"))
        {
            if (gameManager.progressCraft < 100)
            {
                Etat.SetText("Morgenstern en cours...");
                barre_verte5.fillAmount = (float)gameManager.progressCraft / 100f;
            }
            else
            {
                Etat.SetText("Terminé !");
                barre_verte5.fillAmount = 1;
                StartCoroutine(Valide());
            }
        }
        else if (GameObject.Find("Barre_craft_6"))
        {
            if (gameManager.progressCraft < 125)
            {
                Etat.SetText("Hache d'arme en cours...");
                barre_verte6.fillAmount = (float)gameManager.progressCraft / 125f;
            }
            else
            {
                Etat.SetText("Terminé !");
                barre_verte6.fillAmount = 1;
                StartCoroutine(Valide());
            }
        }
        else if (GameObject.Find("Barre_craft_7"))
        {
            if (gameManager.progressCraft < 150)
            {
                Etat.SetText("Bouclier en cours...");
                barre_verte7.fillAmount = (float)gameManager.progressCraft / 150f;
            }
            else
            {
                Etat.SetText("Terminé !");
                barre_verte7.fillAmount = 1;
                StartCoroutine(Valide());
            }
        }
        else if (GameObject.Find("Barre_craft_8"))
        {
            if (gameManager.progressCraft < 200)
            {
                Etat.SetText("Cotte de maille en cours...");
                barre_verte8.fillAmount = (float)gameManager.progressCraft / 200f;
            }
            else
            {
                Etat.SetText("Terminé !");
                barre_verte8.fillAmount = 1;
                StartCoroutine(Valide());
            }
        }
        else
        {
            Etat.SetText("");
            gameManager.progressCraft = 0;
        }
    }

    IEnumerator Valide()
    {
        yield return new WaitForSeconds(timer);
        if (GameObject.Find("Barre_craft_1"))
        {
            gameManager.coin += 15;
            _crafting.barre_bg.SetActive(false);
            _crafting.barre_verte1.SetActive(false);
            _crafting.bouton2.SetActive(true);
            _crafting.bouton3.SetActive(true);
            _crafting.bouton4.SetActive(true);
            _crafting.bouton5.SetActive(true);
            _crafting.bouton6.SetActive(true);
            _crafting.bouton8.SetActive(true);
            _crafting.bouton7.SetActive(true);
        }
        if (GameObject.Find("Barre_craft_2"))
        {
            gameManager.coin += 24;
            _crafting.barre_bg.SetActive(false);
            _crafting.barre_verte2.SetActive(false);
            _crafting.bouton1.SetActive(true);
            _crafting.bouton3.SetActive(true);
            _crafting.bouton4.SetActive(true);
            _crafting.bouton5.SetActive(true);
            _crafting.bouton6.SetActive(true);
            _crafting.bouton8.SetActive(true);
            _crafting.bouton7.SetActive(true);
        }
        if (GameObject.Find("Barre_craft_3"))
        {
            gameManager.coin += 36;
            _crafting.barre_bg.SetActive(false);
            _crafting.barre_verte3.SetActive(false);
            _crafting.bouton2.SetActive(true);
            _crafting.bouton1.SetActive(true);
            _crafting.bouton4.SetActive(true);
            _crafting.bouton5.SetActive(true);
            _crafting.bouton6.SetActive(true);
            _crafting.bouton8.SetActive(true);
            _crafting.bouton7.SetActive(true);
        }
        if (GameObject.Find("Barre_craft_4"))
        {
            gameManager.coin += 66;
            _crafting.barre_bg.SetActive(false);
            _crafting.barre_verte4.SetActive(false);
            _crafting.bouton2.SetActive(true);
            _crafting.bouton3.SetActive(true);
            _crafting.bouton1.SetActive(true);
            _crafting.bouton5.SetActive(true);
            _crafting.bouton6.SetActive(true);
            _crafting.bouton8.SetActive(true);
            _crafting.bouton7.SetActive(true);
        }
        if (GameObject.Find("Barre_craft_5"))
        {
            gameManager.coin += 99;
            _crafting.barre_bg.SetActive(false);
            _crafting.barre_verte5.SetActive(false);
            _crafting.bouton2.SetActive(true);
            _crafting.bouton3.SetActive(true);
            _crafting.bouton4.SetActive(true);
            _crafting.bouton1.SetActive(true);
            _crafting.bouton6.SetActive(true);
            _crafting.bouton8.SetActive(true);
            _crafting.bouton7.SetActive(true);
        }
        if (GameObject.Find("Barre_craft_6"))
        {
            gameManager.coin += 135;
            _crafting.barre_bg.SetActive(false);
            _crafting.barre_verte6.SetActive(false);
            _crafting.bouton2.SetActive(true);
            _crafting.bouton3.SetActive(true);
            _crafting.bouton4.SetActive(true);
            _crafting.bouton5.SetActive(true);
            _crafting.bouton1.SetActive(true);
            _crafting.bouton8.SetActive(true);
            _crafting.bouton7.SetActive(true);
        }
        if (GameObject.Find("Barre_craft_7"))
        {
            gameManager.coin += 180;
            _crafting.barre_bg.SetActive(false);
            _crafting.barre_verte7.SetActive(false);
            _crafting.bouton2.SetActive(true);
            _crafting.bouton3.SetActive(true);
            _crafting.bouton4.SetActive(true);
            _crafting.bouton5.SetActive(true);
            _crafting.bouton1.SetActive(true);
            _crafting.bouton6.SetActive(true);
            _crafting.bouton7.SetActive(true);
        }
        if (GameObject.Find("Barre_craft_8"))
        {
            gameManager.coin += 270;
            _crafting.barre_bg.SetActive(false);
            _crafting.barre_verte8.SetActive(false);
            _crafting.bouton2.SetActive(true);
            _crafting.bouton3.SetActive(true);
            _crafting.bouton4.SetActive(true);
            _crafting.bouton5.SetActive(true);
            _crafting.bouton1.SetActive(true);
            _crafting.bouton6.SetActive(true);
            _crafting.bouton7.SetActive(true);
        }
    }
}