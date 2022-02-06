using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Initialisation des varialbles
    //Ressources Actuelles
    public int coin = 0;

    public int ferRessource = 0;
    public int cuivreRessource = 0;
    public int orRessource = 0;

    //Niveau d'amélioration des mines
    public int ferLevel = 1;
    public int cuivreLevel = 0;
    public int orLevel = 0;

    //Attribution de mineur par mine
    public int nb_mineur_fer = 0;
    public int nb_mineur_cuivre = 0;
    public int nb_mineur_or = 0;

    //Couches opaques lorsque les mines ne sont pas débloqués
    public GameObject CacheCuivre;
    public GameObject CacheOr;

    //Sprite Upgrade Fer
    public GameObject MineFer1;
    public GameObject MineFer2;
    public GameObject MineFer3;
    public GameObject BoutonFerUp;

    //Sprite Upgrade Cuivre
    public GameObject MineCuivre1;
    public GameObject MineCuivre2;
    public GameObject MineCuivre3;
    public GameObject BoutonCuivreUp;

    //Sprite Upgrade Or
    public GameObject MineOr1;
    public GameObject MineOr2;
    public GameObject MineOr3;
    public GameObject BoutonOrUp;

    //Textes d'affichage
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI ferText;
    public TextMeshProUGUI cuivreText;
    public TextMeshProUGUI orText;

    //Prix des améliorations
    public TextMeshProUGUI prixUpFer;
    public TextMeshProUGUI prixUpCuivre;
    public TextMeshProUGUI prixUpOr;

    //Anim Forgeron
    public int progressCraft;
    public GameObject Sprite1;
    public GameObject Sprite2;
    float timer = 0.1f;

    //Initialisation du Drag'n'Drop des mineurs
    public Image barreNombreMineurFer;
    public Image barreNombreMineurCuivre;
    public Image barreNombreMineurOr;
    public RectTransform slotFer;
    public RectTransform slotCuivre;
    public RectTransform slotOr;
    public GameObject slotFerObj;
    public GameObject slotCuivreObj;
    public GameObject slotOrObj;
    public RectTransform maxFer;
    public RectTransform maxCuivre;
    public RectTransform maxOr;
    public TextMeshProUGUI nbDispoText;
    public int nbMineurBuy;
    public int nbMineurDispo;

    public RectTransform mineur;
    public RectTransform ContentMine;

    public TextMeshProUGUI prixMineurText;
    public int prixMineur = 50;

    //Son
    AudioSource audioData;
    #endregion

    private void Start()
    {
        StartCoroutine(ProductionFer()); //Initalisation des revenus passifs

        audioData = GetComponent<AudioSource>(); //Jouer le son d'ambiance au lancement du la scène

        prixMineurText.SetText(prixMineur.ToString() + " $ ");
    }

    private void Update()
    {
        #region Actualiser les ressources disponibles

        coinText.SetText(coin.ToString() + " $ "); //Coin
        ferText.SetText(ferRessource.ToString()); //Fer
        cuivreText.SetText(cuivreRessource.ToString()); //Cuivre
        orText.SetText(orRessource.ToString()); //Or

        #endregion

        #region Affiche Prix Upgrade Mine
        
        //Mine Fer
        if (ferLevel == 1)
            prixUpFer.SetText("150 $");
        else if (ferLevel == 2)
            prixUpFer.SetText("500 $");
        else if (ferLevel == 3)
            prixUpFer.SetText("");

        //Mine Cuivre
        if (cuivreLevel == 0)
            prixUpCuivre.SetText("200 $");
        else if (cuivreLevel == 1)
            prixUpCuivre.SetText("550 $");
        else if (cuivreLevel == 2)
            prixUpCuivre.SetText("700 $");

        //Mine Or
        if (orLevel == 0)
            prixUpOr.SetText("400 $");
        else if (orLevel == 1)
            prixUpOr.SetText("800 $");
        else if (orLevel == 2)
            prixUpOr.SetText("1000 $");

        #endregion

        #region Affichage nombre de mineurs disponibles et présents dans la mine

        //Bulle text
        nbDispoText.SetText(nbMineurDispo.ToString());

        //Vérification du nombre de mineurs dans la mine de fer
        if (nb_mineur_fer < 0)
            nb_mineur_fer = 0;

        if (nb_mineur_fer < 8)
            barreNombreMineurFer.fillAmount = (float) nb_mineur_fer / 8f;
        else
            barreNombreMineurFer.fillAmount = 1;

        //Vérification du nombre de mineurs dans la mine de cuivre
        if (nb_mineur_cuivre < 0)
            nb_mineur_cuivre = 0;

        if (nb_mineur_cuivre < 8)
            barreNombreMineurCuivre.fillAmount = (float)nb_mineur_cuivre / 8f;
        else
            barreNombreMineurCuivre.fillAmount = 1;

        //Vérification du nombre de mineurs dans la mine de or
        if (nb_mineur_or < 0)
            nb_mineur_or = 0;

        if (nb_mineur_or < 8)
            barreNombreMineurOr.fillAmount = (float)nb_mineur_or / 8f;
        else
            barreNombreMineurOr.fillAmount = 1;

        #endregion

        #region Position de l'objet mineur (que l'on drag)

        if (nbMineurDispo >= 1 && nbMineurDispo <= 12)
        {
            mineur.anchoredPosition = new Vector2(1956, -574);
        }

        #endregion

        #region Vérification mine active pour le positionnement des slots

        if (ContentMine.anchoredPosition.y < -1400)
        {
            slotFerObj.SetActive(true);
            slotCuivreObj.SetActive(false);
            slotOrObj.SetActive(false);
        }

        if (ContentMine.anchoredPosition.y > -1400 && ContentMine.anchoredPosition.y < 500)
        {
            slotFerObj.SetActive(false);
            slotCuivreObj.SetActive(true);
            slotOrObj.SetActive(false);
        }

        if (ContentMine.anchoredPosition.y > 500)
        {
            slotFerObj.SetActive(false);
            slotCuivreObj.SetActive(false);
            slotOrObj.SetActive(true);
        }

        #endregion
    }

    #region Production Mine Passif
    public void CreateMinner()
    {
        if (nbMineurBuy == 0 && coin >= prixMineur)
        {
            coin -= 50;
            prixMineur = 100;
            prixMineurText.SetText(prixMineur.ToString() + " $ ");
            nbMineurBuy += 1;
            nbMineurDispo += 1;
        }
        else if (nbMineurBuy == 1 && coin >= prixMineur)
        {
            coin -= 100;
            prixMineur = 150;
            prixMineurText.SetText(prixMineur.ToString() + " $ ");
            nbMineurBuy += 1;
            nbMineurDispo += 1;
        }
        else if(nbMineurBuy == 2 && coin >= prixMineur)
        {
            coin -= 150;
            prixMineur = 200;
            prixMineurText.SetText(prixMineur.ToString() + " $ ");
            nbMineurBuy += 1;
            nbMineurDispo += 1;
        }
        else if(nbMineurBuy == 3 && coin >= prixMineur)
        {
            coin -= 200;
            prixMineur = 250;
            prixMineurText.SetText(prixMineur.ToString() + " $ ");
            nbMineurBuy += 1;
            nbMineurDispo += 1;
        }
        else if(nbMineurBuy == 4 && coin >= prixMineur)
        {
            coin -= 250;
            prixMineur = 300;
            prixMineurText.SetText(prixMineur.ToString() + " $ ");
            nbMineurBuy += 1;
            nbMineurDispo += 1;
        }
        else if(nbMineurBuy == 5 && coin >= prixMineur)
        {
            coin -= 300;
            prixMineur = 350;
            prixMineurText.SetText(prixMineur.ToString() + " $ ");
            nbMineurBuy += 1;
            nbMineurDispo += 1;
        }
        else if(nbMineurBuy == 6 && coin >= prixMineur)
        {
            coin -= 350;
            prixMineur = 400;
            prixMineurText.SetText(prixMineur.ToString() + " $ ");
            nbMineurBuy += 1;
            nbMineurDispo += 1;
        }
        else if(nbMineurBuy == 7 && coin >= prixMineur)
        {
            coin -= 400;
            prixMineur = 450;
            prixMineurText.SetText(prixMineur.ToString() + " $ ");
            nbMineurBuy += 1;
            nbMineurDispo += 1;
        }
        else if(nbMineurBuy == 8 && coin >= prixMineur)
        {
            coin -= 450;
            prixMineur = 500;
            prixMineurText.SetText(prixMineur.ToString() + " $ ");
            nbMineurBuy += 1;
            nbMineurDispo += 1;
        }
        else if(nbMineurBuy == 9 && coin >= prixMineur)
        {
            coin -= 500;
            prixMineur = 550;
            prixMineurText.SetText(prixMineur.ToString() + " $ ");
            nbMineurBuy += 1;
            nbMineurDispo += 1;
        }
        else if(nbMineurBuy == 10 && coin >= prixMineur)
        {
            coin -= 550;
            prixMineur = 600;
            prixMineurText.SetText(prixMineur.ToString() + " $ ");
            nbMineurBuy += 1;
            nbMineurDispo += 1;
        }
        else if(nbMineurBuy == 11 && coin >= prixMineur)
        {
            coin -= 600;
            prixMineur = 650;
            prixMineurText.SetText("");
            nbMineurBuy += 1;
            nbMineurDispo += 1;
        }

    }
    IEnumerator ProductionFer()
    {
        if (nb_mineur_fer == 0)
        {
             ferRessource += 0;
             slotFer.anchoredPosition = new Vector2(1456, 600);
             maxFer.anchoredPosition = new Vector2(2400, 600);
         }
         if (nb_mineur_fer == 1)
         {
             ferRessource += 2;
             slotFer.anchoredPosition = new Vector2(1456, 600);
             maxFer.anchoredPosition = new Vector2(2400, 0);
         }
         if (nb_mineur_fer == 2)
         {
             ferRessource += 4;
             slotFer.anchoredPosition = new Vector2(1456, 600);
             maxFer.anchoredPosition = new Vector2(2400, 0);
         }
         if (nb_mineur_fer == 3)
         {
             ferRessource += 6;
             slotFer.anchoredPosition = new Vector2(1456, 600);
             maxFer.anchoredPosition = new Vector2(2400, 0);
         }
         if (nb_mineur_fer == 4)
         {
             ferRessource += 8;
             slotFer.anchoredPosition = new Vector2(1456, 600);
             maxFer.anchoredPosition = new Vector2(2400, 0);
         }
         if (nb_mineur_fer == 5)
         {
             ferRessource += 10;
             slotFer.anchoredPosition = new Vector2(1456, 600);
             maxFer.anchoredPosition = new Vector2(2400, 0);
         }
         if (nb_mineur_fer == 6)
         {
             ferRessource += 12;
             slotFer.anchoredPosition = new Vector2(1456, 600);
             maxFer.anchoredPosition = new Vector2(2400, 0);
         }
         if (nb_mineur_fer == 7)
         {
             ferRessource += 14;
             slotFer.anchoredPosition = new Vector2(1456, 600);
             maxFer.anchoredPosition = new Vector2(2400, 0);
         }
         if (nb_mineur_fer == 8)
         {
             ferRessource += 16;
             slotFer.anchoredPosition = new Vector2(2400, 0);
             maxFer.anchoredPosition = new Vector2(-350, 600);
         }
         if (nb_mineur_fer > 8)
         {
             ferRessource += 16;
         }
         yield return new WaitForSeconds(1);
         StartCoroutine(ProductionFer());
         StartCoroutine(ProductionCuivre());
         StartCoroutine(ProductionOr());
    }
    IEnumerator ProductionCuivre()
    {
        if (!GameObject.Find("CacheCuivre"))
        {
            if (nb_mineur_cuivre == 0)
            {
                cuivreRessource += 0;
                slotCuivre.anchoredPosition = new Vector2(1456, 600);
                maxCuivre.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_cuivre == 1)
            {
                cuivreRessource += 2;
                slotCuivre.anchoredPosition = new Vector2(1456, 600);
                maxCuivre.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_cuivre == 2)
            {
                cuivreRessource += 4;
                slotCuivre.anchoredPosition = new Vector2(1456, 600);
                maxCuivre.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_cuivre == 3)
            {
                cuivreRessource += 6;
                slotCuivre.anchoredPosition = new Vector2(1456, 600);
                maxCuivre.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_cuivre == 4)
            {
                cuivreRessource += 8;
                slotCuivre.anchoredPosition = new Vector2(1456, 600);
                maxCuivre.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_cuivre == 5)
            {
                cuivreRessource += 10;
                slotCuivre.anchoredPosition = new Vector2(1456, 600);
                maxCuivre.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_cuivre == 6)
            {
                cuivreRessource += 12;
                slotCuivre.anchoredPosition = new Vector2(1456, 600);
                maxCuivre.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_cuivre == 7)
            {
                cuivreRessource += 14;
                slotCuivre.anchoredPosition = new Vector2(1456, 600);
                maxCuivre.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_cuivre == 8)
            {
                cuivreRessource += 16;
                slotCuivre.anchoredPosition = new Vector2(2400, 600);
                maxCuivre.anchoredPosition = new Vector2(79, -293.6f);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_cuivre > 8)
            {
                cuivreRessource += 16;
            }
        }
    }
    IEnumerator ProductionOr()
    {
        if (!GameObject.Find("CacheOr"))
        {
            if (nb_mineur_or == 0)
            {
                orRessource += 0;
                slotOr.anchoredPosition = new Vector2(1456, 600);
                maxOr.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_or == 1)
            {
                orRessource += 2;
                slotOr.anchoredPosition = new Vector2(1456, 600);
                maxOr.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_or == 2)
            {
                orRessource += 4;
                slotOr.anchoredPosition = new Vector2(1456, 600);
                maxOr.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_or == 3)
            {
                orRessource += 6;
                slotOr.anchoredPosition = new Vector2(1456, 600);
                maxOr.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_or == 4)
            {
                orRessource += 8;
                slotOr.anchoredPosition = new Vector2(1456, 600);
                maxOr.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_or == 5)
            {
                orRessource += 10;
                slotOr.anchoredPosition = new Vector2(1456, 600);
                maxOr.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_or == 6)
            {
                orRessource += 12;
                slotOr.anchoredPosition = new Vector2(1456, 600);
                maxOr.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_or == 7)
            {
                orRessource += 14;
                slotOr.anchoredPosition = new Vector2(1456, 600);
                maxOr.anchoredPosition = new Vector2(2400, 600);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_or == 8)
            {
                orRessource += 16;
                slotOr.anchoredPosition = new Vector2(2400, 600);
                maxOr.anchoredPosition = new Vector2(79, -293.6f);
                yield return new WaitForSeconds(1);
            }
            if (nb_mineur_or > 8)
            {
                orRessource += 16;
            }
        }
    }

    public void RemoveFer()
    {
        if (nb_mineur_fer > 0)
        {
            nb_mineur_fer -= 1;
            nbMineurDispo += 1;
        }
    }
    public void RemoveCuivre()
    {
        if (nb_mineur_cuivre > 0)
        {
            nb_mineur_cuivre -= 1;
            nbMineurDispo += 1;
        }
    }
    public void RemoveOr()
    {
        if (nb_mineur_or > 0)
        {
            nb_mineur_or -= 1;
            nbMineurDispo += 1;
        }
    }
    #endregion

    #region Click de production des ressources
    public void ProductFer()
    {
        if (ferLevel == 1)
        {
            ferRessource += 1;
        }
        if (ferLevel == 2)
        {
            ferRessource += 2;
        }
        if (ferLevel == 3)
        {
            ferRessource += 4;
        }
    }
    public void ProductCuivre()
    {
        if (!GameObject.Find("CacheCuivre"))
        {
            if (cuivreLevel == 1)
            {
                cuivreRessource += 1;
            }
            if (cuivreLevel == 2)
            {
                cuivreRessource += 2;
            }
            if (cuivreLevel == 3)
            {
                cuivreRessource += 4;
            }
        }
    }
    public void ProductOr()
    {
        if (!GameObject.Find("CacheOr"))
        {
            if (orLevel == 1)
            {
                orRessource += 1;
            }
            if (orLevel == 2)
            {
                orRessource += 2;
            }
            if (orLevel == 3)
            {
                orRessource += 4;
            }
        }
    }
    #endregion

    #region Upgrade Mine
    public void UpgradeFer()
    {
        if (ferLevel == 1 && coin >= 150)
        {
            coin -= 150;
            ferLevel += 1;
            MineFer1.SetActive(false);
            MineFer2.SetActive(true);
        }
        else if (ferLevel == 2 && coin >= 500)
        {
            coin -= 500;
            ferLevel += 1;
            MineFer2.SetActive(false);
            MineFer3.SetActive(true);
            BoutonFerUp.SetActive(false);
        }
    }
    public void UpgradeCuivre()
    {
        if (cuivreLevel == 0 && coin >= 200)
        {
            coin -= 200;
            CacheCuivre.SetActive(false);
            cuivreLevel += 1;
        }
        else if (cuivreLevel == 1 && coin >= 550)
        {
            coin -= 550;
            cuivreLevel += 1;
            MineCuivre1.SetActive(false);
            MineCuivre2.SetActive(true);
        }
        else if (cuivreLevel == 2 && coin >= 700)
        {
            coin -= 700;
            cuivreLevel += 1;
            MineCuivre2.SetActive(false);
            MineCuivre3.SetActive(true);
            BoutonCuivreUp.SetActive(false);
        }
    }
    public void UpgradeOr()
    {
        if (orLevel == 0 && coin >= 400)
        {
            coin -= 400;
            CacheOr.SetActive(false);
            orLevel += 1;
        }
        else if (orLevel == 1 && coin >= 800)
        {
            coin -= 800;
            orLevel += 1;
            MineOr1.SetActive(false);
            MineOr2.SetActive(true);
        }
        else if (orLevel == 2 && coin >= 1000)
        {
            coin -= 1000;
            orLevel += 1;
            MineOr2.SetActive(false);
            MineOr3.SetActive(true);
            BoutonOrUp.SetActive(false);
        }
    }
    #endregion

    #region AnimForgeron et progression de craft par click

    //Crafting
    public void OnClick()
    {
        progressCraft += 1;
        audioData.Play(0); //son d'enclume

        StartCoroutine(MyCoroutine());
    }

    //Active et désactive les sprites du forgeron
    IEnumerator MyCoroutine() 
    {
        Sprite2.SetActive(true);
        Sprite1.SetActive(false);
        yield return new WaitForSeconds(timer);
        Sprite2.SetActive(false);
        Sprite1.SetActive(true);
    }
    #endregion
}