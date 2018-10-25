using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    turnEnd
}

public class Board : MonoBehaviour {
    static public Board S;  // A private Singleton

    public GameObject haloGO;
    public GameObject xPieceGO;
    public GameObject oPieceGO;

    [Header("Set in Inspector")]
    public Text countXText;
    public Text countOText;
    public Text turnText;
    public Text playerXWinText;
    public Text playerOWinText;
    public Vector3 letterPos; // The place to put the letters
    public GameObject[] lettersList; // An array of the letters

    [Header("Set Dynamically")]
    public int turnMax; // The number of turns 
    public int countX; // The number of X letters in play
    public int countO; // The number of O letters in play
    public GameObject Letter; // The current letter
    public GameMode mode = GameMode.idle;
    public bool isPlayerXTurn;
    private string playerSide;

    void Awake()
    {
        Board.S = this;
        playerSide = "X";
    }

    public string GetPlayerSide()
    {
        return playerSide;
    } 

    void Start()
    {
        //Define the Singleton
        S = this;

        turnMax = lettersList.Length;
        StartPlayerXTurn();
    }

    void StartPlayerXTurn()
    {
        // Instantiate X and disable square
        if (isPlayerXTurn == true)
        {
            GameObject tempGO = Instantiate(xPieceGO);
            tempGO.transform.position = this.gameObject.transform.position;
            Destroy(haloGO);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        if (isPlayerXTurn == false)
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
        turnText.text = "Turn: " + isPlayerXTurn.ToString();
    }

    //void GameOver()
    //{
    //for (int i = 0; i < lettersList.Length; i++)
    //{
    //lettersList[i].GetComponentInParent<Letter>().interactable = false;
    //}
    //}
}
