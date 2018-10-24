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
    static private Board S;  // A private Singleton

    GameObject haloGO;
    public GameObject xPieceGO;
    public GameObject oPieceGO;

    private PlayerController playerController;

    public void SetPlayerControllerReference(PlayerController controller)
    {
        playerController = controller;
    }

    [Header("Set in Inspector")]
    public Text countXText;
    public Text countOText;
    public Text winText;
    public Vector3 letterPos; // The place to put the letters
    public GameObject[] lettersList; // An array of the letters

    [Header("Set Dynamically")]
    public int turn; // The current turn
    public int turnMax; // The number of turns 
    public int countX; // The number of X letters in play
    public int countO; // The number of O letters in play
    public GameObject letter; // The current letter
    public GameMode mode = GameMode.idle;
    private object playerXTurn;
    private object playerOTurn;
    private string playerSide;

    void Awake()
    {
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

        turn = 0;
        turnMax = lettersList.Length;
        StartPlayerXTurn();
    }

    void StartPlayerXTurn()
    {
        // Instantiate X and disable square
        if (turn = playerXTurn)
        {
            GameObject tempGO = Instantiate(xPieceGO);
            tempGO.transform.position = this.gameObject.transform.position;
            Destroy(haloGO);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }

    void StartPlayerOTurn()
    {
        // Instantiate O and disable square
        if (turn = playerOTurn)
        {
            GameObject tempGO = Instantiate(oPieceGO);
            tempGO.transform.position = this.gameObject.transform.position;
            Destroy(haloGO);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void EndTurn()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        if (lettersList [0].GetComponent<GUIText>() == playerSide && lettersList [1].GetComponent<GUIText>() == playerSide && lettersList [2].GetComponent<GUIText>() == playerSide)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            GameOver();
        }
#pragma warning disable CS0618 // Type or member is obsolete
        if (lettersList [3].GetComponent<GUIText>() == playerSide && lettersList [4].GetComponent<GUIText>() == playerSide && lettersList [5].GetComponent<GUIText>() == playerSide)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            GameOver();
        }
#pragma warning disable CS0618 // Type or member is obsolete
        if (lettersList [6].GetComponent<GUIText>() == playerSide && lettersList [7].GetComponent<GUIText>() == playerSide && lettersList [8].GetComponent<GUIText>() == playerSide)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            GameOver();
        }
#pragma warning disable CS0618 // Type or member is obsolete
        if (lettersList [0].GetComponent<GUIText>() == playerSide && lettersList [3].GetComponent<GUIText>() == playerSide && lettersList [6].GetComponent<GUIText>() == playerSide)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            GameOver();
        }
#pragma warning disable CS0618 // Type or member is obsolete
        if (lettersList [1].GetComponent<GUIText>() == playerSide && lettersList [4].GetComponent<GUIText>() == playerSide && lettersList [7].GetComponent<GUIText>() == playerSide)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            GameOver();
        }
#pragma warning disable CS0618 // Type or member is obsolete
        if (lettersList [2].GetComponent<GUIText>() == playerSide && lettersList [5].GetComponent<GUIText>() == playerSide && lettersList [8].GetComponent<GUIText>() == playerSide)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            GameOver();
        }
#pragma warning disable CS0618 // Type or member is obsolete
        if (lettersList [0].GetComponent<GUIText>() == playerSide && lettersList [4].GetComponent<GUIText>() == playerSide && lettersList [8].GetComponent<GUIText>() == playerSide)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            GameOver();
        }
#pragma warning disable CS0618 // Type or member is obsolete
        if (lettersList [2].GetComponent<GUIText>() == playerSide && lettersList [4].GetComponent<GUIText>() == playerSide && lettersList [6].GetComponent<GUIText>() == playerSide)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            GameOver();
        }

        ChangeSides();
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void GameOver()
    {
        for (int i = 0; i < lettersList.Length; i++)
        {
            lettersList[i].GetComponentInParent<Letter>().interactable = false;
        }
    }
}
