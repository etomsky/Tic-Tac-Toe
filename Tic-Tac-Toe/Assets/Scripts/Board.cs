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

    void Awake()
    {
        Board.S = this;
    }

    void Start()
    {
        //Define the Singleton
        S = this;

        turnMax = lettersList.Length;
        //StartPlayerXTurn();
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
