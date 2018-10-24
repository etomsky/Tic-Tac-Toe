using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    GameObject haloGO;
    public GameObject xPieceGO;
    public GameObject oPieceGo;
    public Button letter;
    public string playerSide; 
    public Text countXText;
    public Text countOText;
    public Text turnText;
    public Text playerXWinText;
    public Text playerOWinText;

    private int countX;
    private int countO;
    private object playerXTurn;
    private object playerOTurn;

    public void SetSpace()
    {
        letter.interactable = false;
    }

    // Use this for initialization
    void Start()
    {
        haloGO = GameObject.Find("HaloObject");
        haloGO.SetActive(false);
        countX = 0;
        countO = 0;
        SetCountXText();
        SetCountOText();
        countXText.text = "";
        countOText.text = "";
        turnText.text = "";
        playerXWinText.text = "";
        playerOWinText.text = "";
        oPieceGo = GameObject.Find("O");
        xPieceGO = GameObject.Find("X");
    }

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
        if(turn = playerXTurn)
        {
            GameObject tempGO = Instantiate(xPieceGO);
            tempGO.transform.position = this.gameObject.transform.position;
            Destroy(haloGO);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        if(turn = playerOTurn)
        {
            GameObject tempGO = Instantiate(oPieceGO);
            tempGO.transform.position = this.gameObject.transform.position;
            Destroy(haloGO);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("X"))
        {
            other.gameObject.SetActive(false);
            countX = countX + 1;
            SetCountXText();
        }
        if (other.gameObject.CompareTag("O"))
        {
            other.gameObject.SetActive(false);
            countO = countO + 1;
            SetCountOText();
        }
    }

    private void SetCountXText()
    {
        countXText.text = "X Count: " + countX.ToString();
        if (countX == 3)
        {
            playerXWinText.text = "Player X Wins!";
        }
    }

    private void SetCountOText()
    {
        countOText.text = "O Count: " + countO.ToString();
        if (countO == 3)
        {
            playerOWinText.text = "Player O wins!";
        }
    }

    private void SetTurnText()
    {
        turnText.text = "Turn: " + turn.ToString();
    }
}
