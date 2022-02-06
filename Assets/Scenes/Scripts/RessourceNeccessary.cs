using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RessourceNeccessary : MonoBehaviour
{
    public GameManager gameManager;

    public TextMeshProUGUI RessourceNeccesary;

    public int ferNeccessary;
    public int cuivreNeccessary;
    public int orNeccessary;
    void Update()
    {
        RessourceNeccesary.SetText("Fer : " + gameManager.ferRessource + " / " + ferNeccessary + "\n" + "Cuivre : " + gameManager.cuivreRessource + " / " + cuivreNeccessary + "\n" + "Or : " + gameManager.orRessource + " / " + orNeccessary);
    }
}
