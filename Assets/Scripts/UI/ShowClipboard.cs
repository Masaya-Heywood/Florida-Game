using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClipboard : MonoBehaviour
{
    //Simple on/off toggle for the player's clipboard.
    private GameObject clipboard;

    void Start()
    {
        clipboard = this.gameObject;
    }

    public void ToggleClipboard()
    {
        clipboard.SetActive(!clipboard.activeInHierarchy);
    }
}
