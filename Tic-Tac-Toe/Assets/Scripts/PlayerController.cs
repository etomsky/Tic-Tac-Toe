using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Text countXText;
    public Text countOText;
    public Text winText;

    private Rigidbody rb;
    private int countX;
    private int countO;

	// Use this for initialization
	void Start()
    {
        rb = GetComponent<Rigidbody>();
        countX = 0;
        countO = 0;
        SetCountXText();
        SetCountOText();
        countXText.text = "";
        countOText.text = "";
        winText.text = "";
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
            winText.text = "You win!";
        }
    }

    private void SetCountOText()
    {
        countOText.text = "O Count: " + countO.ToString();
        if (countO == 3)
        {
            winText.text = "You win!";
        }
    }
}
