using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationClickHandler : MonoBehaviour {

    public GameObject haloGO;
    public bool isPlayerXTurn;
    public GameObject xPieceGO;
    public GameObject oPieceGO;
    public GameObject tempGO;

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

    private void OnMouseDown()
    {
        if (Board.S.isPlayerXTurn == true)
        {
            GameObject tempGO = Instantiate(xPieceGO);
            tempGO.transform.position = this.gameObject.transform.position;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Board.S.isPlayerXTurn = !Board.S.isPlayerXTurn;
        }
        else
        {
            GameObject tempGO = Instantiate(oPieceGO);
            tempGO.transform.position = this.gameObject.transform.position;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Board.S.isPlayerXTurn = !Board.S.isPlayerXTurn;
        }
    }

    public void Turn()
    {
        if (Board.S.isPlayerXTurn == true)
        {
            GameObject tempGO = Instantiate(xPieceGO);
            tempGO.transform.position = this.gameObject.transform.position;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Board.S.isPlayerXTurn = !Board.S.isPlayerXTurn;
        }
        else
        {
            GameObject tempGO = Instantiate(oPieceGO);
            tempGO.transform.position = this.gameObject.transform.position;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Board.S.isPlayerXTurn = !Board.S.isPlayerXTurn;
        }
    }
}
