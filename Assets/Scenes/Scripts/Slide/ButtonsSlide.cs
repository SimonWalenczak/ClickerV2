using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonsSlide : MonoBehaviour
{
    [SerializeField] GameObject tab1;
    [SerializeField] GameObject tab2;

    [SerializeField] RectTransform _tab1;
    [SerializeField] RectTransform _tab2;

    int actualselect = 1;

    public void Click1()
    {
        if (actualselect != 1)
        {
            MoveTabButton(_tab1);
            CheckRetract();
            actualselect = 1;
        }
    }
    public void Click2()
    {
        if (actualselect != 2)
        {
            MoveTabButton(_tab2);
            CheckRetract();
            actualselect = 2;
        }
    }

    public void MoveTabButton(RectTransform tab)
    {
        tab.transform.DOComplete();
        tab.transform.DOMove(new Vector3(tab.transform.position.x, tab.transform.position.y + 0.5f, tab.transform.position.z), 0.5f, false);
    }
    public void RetractTabButton(RectTransform tab)
    {
        tab.transform.DOComplete();
        tab.transform.DOMove(new Vector3(tab.transform.position.x, tab.transform.position.y - 0.5f, tab.transform.position.z), 0.5f, false);
    }
    public void CheckRetract()
    {
        if (actualselect == 1)
        {
            RetractTabButton(_tab1);
        }
        if (actualselect == 2)
        {
            RetractTabButton(_tab2);
        }
    }

    public GameObject Background;
    public GameObject ItemGroup;
    public GameObject SpriteForgeron;
    public GameObject MineGroup;
    public GameObject ProgressBarGroup;
    public GameObject CanvasItems;
    public GameObject CanvasSlot;

    bool slide = false;

    public void OnClick()
    {
        if (actualselect == 2 && slide == false)
        {
            Background.transform.DOComplete();
            Background.transform.DOMove(new Vector3(Background.transform.position.x - 10, Background.transform.position.y, Background.transform.position.z), 0.5f, false);

            ItemGroup.transform.DOComplete();
            ItemGroup.transform.DOMove(new Vector3(ItemGroup.transform.position.x - 10, ItemGroup.transform.position.y, ItemGroup.transform.position.z), 0.5f, false);

            SpriteForgeron.transform.DOComplete();
            SpriteForgeron.transform.DOMove(new Vector3(SpriteForgeron.transform.position.x - 10, SpriteForgeron.transform.position.y, SpriteForgeron.transform.position.z), 0.5f, false);

            MineGroup.transform.DOComplete();
            MineGroup.transform.DOMove(new Vector3(MineGroup.transform.position.x - 10, MineGroup.transform.position.y, MineGroup.transform.position.z), 0.5f, false);

            ProgressBarGroup.transform.DOComplete();
            ProgressBarGroup.transform.DOMove(new Vector3(ProgressBarGroup.transform.position.x - 10, ProgressBarGroup.transform.position.y, ProgressBarGroup.transform.position.z), 0.5f, false);

            CanvasItems.transform.DOComplete();
            CanvasItems.transform.DOMove(new Vector3(CanvasItems.transform.position.x - 10, CanvasItems.transform.position.y, CanvasItems.transform.position.z), 0.5f, false);

            CanvasSlot.transform.DOComplete();
            CanvasSlot.transform.DOMove(new Vector3(CanvasSlot.transform.position.x - 10, CanvasSlot.transform.position.y, CanvasSlot.transform.position.z), 0.5f, false);

            slide = true;
        }

        if (actualselect == 1 && slide == true)
        {                
            Background.transform.DOComplete();
            Background.transform.DOMove(new Vector3(Background.transform.position.x + 10, Background.transform.position.y, Background.transform.position.z), 0.5f, false);

            ItemGroup.transform.DOComplete();
            ItemGroup.transform.DOMove(new Vector3(ItemGroup.transform.position.x + 10, ItemGroup.transform.position.y, ItemGroup.transform.position.z), 0.5f, false);

            SpriteForgeron.transform.DOComplete();
            SpriteForgeron.transform.DOMove(new Vector3(SpriteForgeron.transform.position.x + 10, SpriteForgeron.transform.position.y, SpriteForgeron.transform.position.z), 0.5f, false);

            MineGroup.transform.DOComplete();
            MineGroup.transform.DOMove(new Vector3(MineGroup.transform.position.x + 10, MineGroup.transform.position.y, MineGroup.transform.position.z), 0.5f, false);

            ProgressBarGroup.transform.DOComplete();
            ProgressBarGroup.transform.DOMove(new Vector3(ProgressBarGroup.transform.position.x + 10, ProgressBarGroup.transform.position.y, ProgressBarGroup.transform.position.z), 0.5f, false);

            CanvasItems.transform.DOComplete();
            CanvasItems.transform.DOMove(new Vector3(CanvasItems.transform.position.x + 10, CanvasItems.transform.position.y, CanvasItems.transform.position.z), 0.5f, false);

            CanvasSlot.transform.DOComplete();
            CanvasSlot.transform.DOMove(new Vector3(CanvasSlot.transform.position.x + 10, CanvasSlot.transform.position.y, CanvasSlot.transform.position.z), 0.5f, false);

            slide = false;
        }
    }
}