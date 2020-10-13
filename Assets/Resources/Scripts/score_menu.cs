using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_menu : MonoBehaviour
{

    public GameObject scoreMenu;
    public CanvasGroup menu;

    // Use this for initialization
    void Start()
    {
        menu = scoreMenu.GetComponent<CanvasGroup>();
        Hide();
    }

    public void Hide()
    {
        menu.alpha = 0f;
        menu.blocksRaycasts = false;
    }

    public void Show()
    {
        menu.alpha = 1f;
        menu.blocksRaycasts = true;
    }
}