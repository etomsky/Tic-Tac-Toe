using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationClickHandler : MonoBehaviour {

    GameObject haloGO;
    public bool isPlayerXTurn;
    public GameObject xPieceGO;
    public GameObject oPieceGO;
    public GameObject tGO;

    // Use this for initialization
    private void Awake() {}

    private void OnMouseEnter()
    {
        if (haloGO != null)
        {
            haloGO.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (haloGO != null)
        {
            haloGO.SetActive(false);
        }
    }

    public void Turn()
    {
        if (Board.S.isPlayerXTurn == true)
        {
            tGO = Instantiate(xPieceGO);
        }
        else
        {
            tGO = Instantiate(oPieceGO);
        }
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Board.S.isPlayerXTurn = !Board.S.isPlayerXTurn;
    }
}
