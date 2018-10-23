using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}

public class Board : MonoBehaviour {
    static private Board S;  // A private Singleton

    [Header("Set in Inspector")]
    public Text countXText;
    public Text countOText;
    public Text winText;
    public GameObject[] letters; // An array of the letters

    private void OnMouseEnter()
    {
        print("Board:OnMouseEnter()");
    }

    private void OnMouseExit()
    {
        print("Board:OnMouseExit()");
    }

    private void OnMouseDown()
    {
        
    }
}
