using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardBehavior : MonoBehaviour
{
    public GameObject[] clipboardPages;
    public GameObject persistentElements;

    private int activePageOrder;
    private int currentPage;

    void Start()
    {
        // set each page's order in UI to its number in the list
        int orderInList = 0;
        foreach(GameObject page in clipboardPages)
        {
            page.GetComponent<Canvas>().sortingOrder = orderInList;
            orderInList++;
        }

        activePageOrder = orderInList;
        currentPage = clipboardPages.Length - 1;
        persistentElements.GetComponent<Canvas>().sortingOrder = orderInList + 2;
    }

    //continously flip through the list towards 0
    public void NextPage()
    {

        clipboardPages[currentPage].GetComponent<Canvas>().sortingOrder = 0;
        if (currentPage != 0)
        {
            currentPage = currentPage - 1;
        } else
        {
            currentPage = clipboardPages.Length - 1;
        }

        clipboardPages[currentPage].GetComponent<Canvas>().sortingOrder = activePageOrder;

    }

    //continously flip through the list away from 0
    public void PreviousPage()
    {
        clipboardPages[currentPage].GetComponent<Canvas>().sortingOrder = 0;

        if (currentPage != clipboardPages.Length - 1)
        {
            currentPage = currentPage + 1;
        } else
        {
            currentPage = 0;
        }

        clipboardPages[currentPage].GetComponent<Canvas>().sortingOrder = activePageOrder;
    }

    void FixedUpdate()
    {

    }
}
