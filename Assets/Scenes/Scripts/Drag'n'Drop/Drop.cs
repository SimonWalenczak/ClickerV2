using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public GameManager gameManager;
    public static bool PointerIsOnSlot = false;

    Vector2 PlacePos;

    void Awake()
    {
        PlacePos = new Vector2(2330, 580);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = PlacePos;//GetComponent<RectTransform>().anchoredPosition;
            if (gameManager.ContentMine.anchoredPosition.y < -1400)
            {
                gameManager.nb_mineur_fer += 1;
                gameManager.nbMineurDispo -= 1;
            }
            if (gameManager.ContentMine.anchoredPosition.y > -1400 && gameManager.ContentMine.anchoredPosition.y < 500)
            {
                gameManager.nb_mineur_cuivre += 1;
                gameManager.nbMineurDispo -= 1;
            }
            if (gameManager.ContentMine.anchoredPosition.y > 500)
            {
                gameManager.nb_mineur_or += 1;
                gameManager.nbMineurDispo -= 1;
            }
        }
    }

    public void PointerOnSlot()
    {
        PointerIsOnSlot = true;
    }

    public void PointerOutSlot()
    {
        PointerIsOnSlot = false;
    }
}
