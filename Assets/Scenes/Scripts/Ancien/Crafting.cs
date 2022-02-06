using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    #region Initialisation des variables
    public GameObject barre_bg;
    public GameObject barre_verte1;
    public GameObject barre_verte2;
    public GameObject barre_verte3;
    public GameObject barre_verte4;
    public GameObject barre_verte5;
    public GameObject barre_verte6;
    public GameObject barre_verte7;
    public GameObject barre_verte8;

    public GameObject bouton1;
    public GameObject bouton2;
    public GameObject bouton3;
    public GameObject bouton4;
    public GameObject bouton5;
    public GameObject bouton6;
    public GameObject bouton7;
    public GameObject bouton8;

    public GameManager gameManager;
    public RessourceNeccessary ressourceNeccessary1;
    public RessourceNeccessary ressourceNeccessary2;
    public RessourceNeccessary ressourceNeccessary3;
    public RessourceNeccessary ressourceNeccessary4;
    public RessourceNeccessary ressourceNeccessary5;
    public RessourceNeccessary ressourceNeccessary6;
    public RessourceNeccessary ressourceNeccessary7;
    public RessourceNeccessary ressourceNeccessary8;
    #endregion

    public void ClickToCraft1()
    {
        if (GameObject.Find("Barre_craft_1") == false && gameManager.ferRessource >= ressourceNeccessary1.ferNeccessary && gameManager.cuivreRessource >= ressourceNeccessary1.cuivreNeccessary && gameManager.orRessource >= ressourceNeccessary1.orNeccessary)
        {
            gameManager.ferRessource -= ressourceNeccessary1.ferNeccessary;
            gameManager.cuivreRessource -= ressourceNeccessary1.cuivreNeccessary;
            gameManager.orRessource -= ressourceNeccessary1.orNeccessary;

            barre_verte1.SetActive(true);
            barre_bg.SetActive(true);

            bouton2.SetActive(false);
            bouton3.SetActive(false);
            bouton4.SetActive(false);
            bouton5.SetActive(false);
            bouton6.SetActive(false);
            bouton7.SetActive(false);
            bouton8.SetActive(false);
        }
        else
        {
            barre_verte1.SetActive(false);
            barre_bg.SetActive(false);

            bouton2.SetActive(true);
            bouton3.SetActive(true);
            bouton4.SetActive(true);
            bouton5.SetActive(true);
            bouton6.SetActive(true);
            bouton7.SetActive(true);
            bouton8.SetActive(true);
        }
    }


    public void ClickToCraft2()
    {
        if (GameObject.Find("Barre_craft_2") == false && gameManager.ferRessource >= ressourceNeccessary2.ferNeccessary && gameManager.cuivreRessource >= ressourceNeccessary2.cuivreNeccessary && gameManager.orRessource >= ressourceNeccessary2.orNeccessary)
        {
            gameManager.ferRessource -= ressourceNeccessary2.ferNeccessary;
            gameManager.cuivreRessource -= ressourceNeccessary2.cuivreNeccessary;
            gameManager.orRessource -= ressourceNeccessary2.orNeccessary;

            barre_verte2.SetActive(true);
            barre_bg.SetActive(true);

            bouton1.SetActive(false);
            bouton3.SetActive(false);
            bouton4.SetActive(false);
            bouton5.SetActive(false);
            bouton6.SetActive(false);
            bouton7.SetActive(false);
            bouton8.SetActive(false);
        }
        else
        {
            barre_verte2.SetActive(false);
            barre_bg.SetActive(false);

            bouton1.SetActive(true);
            bouton3.SetActive(true);
            bouton4.SetActive(true);
            bouton5.SetActive(true);
            bouton6.SetActive(true);
            bouton7.SetActive(true);
            bouton8.SetActive(true);
        }
    }

    public void ClickToCraft3()
    {
        if (GameObject.Find("Barre_craft_3") == false && gameManager.ferRessource >= ressourceNeccessary3.ferNeccessary && gameManager.cuivreRessource >= ressourceNeccessary3.cuivreNeccessary && gameManager.orRessource >= ressourceNeccessary3.orNeccessary)
        {
            gameManager.ferRessource -= ressourceNeccessary3.ferNeccessary;
            gameManager.cuivreRessource -= ressourceNeccessary3.cuivreNeccessary;
            gameManager.orRessource -= ressourceNeccessary3.orNeccessary;

            barre_verte3.SetActive(true);
            barre_bg.SetActive(true);

            bouton1.SetActive(false);
            bouton2.SetActive(false);
            bouton4.SetActive(false);
            bouton5.SetActive(false);
            bouton6.SetActive(false);
            bouton7.SetActive(false);
            bouton8.SetActive(false);
        }
        else
        {
            barre_verte3.SetActive(false);
            barre_bg.SetActive(false);

            bouton1.SetActive(true);
            bouton2.SetActive(true);
            bouton4.SetActive(true);
            bouton5.SetActive(true);
            bouton6.SetActive(true);
            bouton7.SetActive(true);
            bouton8.SetActive(true);
        }
    }
    public void ClickToCraft4()
    {
        if (GameObject.Find("Barre_craft_4") == false && gameManager.ferRessource >= ressourceNeccessary4.ferNeccessary && gameManager.cuivreRessource >= ressourceNeccessary4.cuivreNeccessary && gameManager.orRessource >= ressourceNeccessary4.orNeccessary)
        {
            gameManager.ferRessource -= ressourceNeccessary4.ferNeccessary;
            gameManager.cuivreRessource -= ressourceNeccessary4.cuivreNeccessary;
            gameManager.orRessource -= ressourceNeccessary4.orNeccessary;

            barre_verte4.SetActive(true);
            barre_bg.SetActive(true);

            bouton1.SetActive(false);
            bouton2.SetActive(false);
            bouton3.SetActive(false);
            bouton5.SetActive(false);
            bouton6.SetActive(false);
            bouton7.SetActive(false);
            bouton8.SetActive(false);
        }
        else
        {
            barre_verte4.SetActive(false);
            barre_bg.SetActive(false);

            bouton1.SetActive(true);
            bouton2.SetActive(true);
            bouton3.SetActive(true);
            bouton5.SetActive(true);
            bouton6.SetActive(true);
            bouton7.SetActive(true);
            bouton8.SetActive(true);

        }
    }
    public void ClickToCraft5()
    {
        if (GameObject.Find("Barre_craft_5") == false && gameManager.ferRessource >= ressourceNeccessary5.ferNeccessary && gameManager.cuivreRessource >= ressourceNeccessary5.cuivreNeccessary && gameManager.orRessource >= ressourceNeccessary5.orNeccessary)
        {
            gameManager.ferRessource -= ressourceNeccessary5.ferNeccessary;
            gameManager.cuivreRessource -= ressourceNeccessary5.cuivreNeccessary;
            gameManager.orRessource -= ressourceNeccessary5.orNeccessary;

            barre_verte5.SetActive(true);
            barre_bg.SetActive(true);

            bouton1.SetActive(false);
            bouton2.SetActive(false);
            bouton3.SetActive(false);
            bouton4.SetActive(false);
            bouton6.SetActive(false);
            bouton7.SetActive(false);
            bouton8.SetActive(false);
        }
        else
        {
            barre_verte5.SetActive(false);
            barre_bg.SetActive(false);

            bouton1.SetActive(true);
            bouton2.SetActive(true);
            bouton3.SetActive(true);
            bouton4.SetActive(true);
            bouton6.SetActive(true);
            bouton7.SetActive(true);
            bouton8.SetActive(true);
        }
    }
    public void ClickToCraft6()
    {
        if (GameObject.Find("Barre_craft_6") == false && gameManager.ferRessource >= ressourceNeccessary6.ferNeccessary && gameManager.cuivreRessource >= ressourceNeccessary6.cuivreNeccessary && gameManager.orRessource >= ressourceNeccessary6.orNeccessary)
        {
            gameManager.ferRessource -= ressourceNeccessary6.ferNeccessary;
            gameManager.cuivreRessource -= ressourceNeccessary6.cuivreNeccessary;
            gameManager.orRessource -= ressourceNeccessary6.orNeccessary;

            barre_verte6.SetActive(true);
            barre_bg.SetActive(true);

            bouton1.SetActive(false);
            bouton2.SetActive(false);
            bouton3.SetActive(false);
            bouton4.SetActive(false);
            bouton5.SetActive(false);
            bouton7.SetActive(false);
            bouton8.SetActive(false);
        }
        else
        {
            barre_verte6.SetActive(false);
            barre_bg.SetActive(false);

            bouton1.SetActive(true);
            bouton2.SetActive(true);
            bouton3.SetActive(true);
            bouton4.SetActive(true);
            bouton5.SetActive(true);
            bouton7.SetActive(true);
            bouton8.SetActive(true);
        }
    }
    public void ClickToCraft7()
    {
        if (GameObject.Find("Barre_craft_7") == false && gameManager.ferRessource >= ressourceNeccessary7.ferNeccessary && gameManager.cuivreRessource >= ressourceNeccessary7.cuivreNeccessary && gameManager.orRessource >= ressourceNeccessary7.orNeccessary)
        {
            gameManager.ferRessource -= ressourceNeccessary7.ferNeccessary;
            gameManager.cuivreRessource -= ressourceNeccessary7.cuivreNeccessary;
            gameManager.orRessource -= ressourceNeccessary7.orNeccessary;

            barre_verte7.SetActive(true);
            barre_bg.SetActive(true);

            bouton1.SetActive(false);
            bouton2.SetActive(false);
            bouton3.SetActive(false);
            bouton4.SetActive(false);
            bouton5.SetActive(false);
            bouton6.SetActive(false);
            bouton8.SetActive(false);
        }
        else
        {
            barre_verte7.SetActive(false);
            barre_bg.SetActive(false);

            bouton1.SetActive(true);
            bouton2.SetActive(true);
            bouton3.SetActive(true);
            bouton4.SetActive(true);
            bouton5.SetActive(true);
            bouton6.SetActive(true);
            bouton8.SetActive(true);
        }
    }
    public void ClickToCraft8()
    {
        if (GameObject.Find("Barre_craft_8") == false && gameManager.ferRessource >= ressourceNeccessary8.ferNeccessary && gameManager.cuivreRessource >= ressourceNeccessary8.cuivreNeccessary && gameManager.orRessource >= ressourceNeccessary8.orNeccessary)
        {
            gameManager.ferRessource -= ressourceNeccessary8.ferNeccessary;
            gameManager.cuivreRessource -= ressourceNeccessary8.cuivreNeccessary;
            gameManager.orRessource -= ressourceNeccessary8.orNeccessary;

            barre_verte8.SetActive(true);
            barre_bg.SetActive(true);

            bouton1.SetActive(false);
            bouton2.SetActive(false);
            bouton3.SetActive(false);
            bouton4.SetActive(false);
            bouton5.SetActive(false);
            bouton6.SetActive(false);
            bouton7.SetActive(false);
        }
        else
        {
            barre_verte8.SetActive(false);
            barre_bg.SetActive(false);

            bouton1.SetActive(true);
            bouton2.SetActive(true);
            bouton3.SetActive(true);
            bouton4.SetActive(true);
            bouton5.SetActive(true);
            bouton6.SetActive(true);
            bouton7.SetActive(true);
        }
    }
}