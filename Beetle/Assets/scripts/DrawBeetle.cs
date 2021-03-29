using System;
using UnityEngine;
using UnityEngine.UI;

public class DrawBeetle : MonoBehaviour
{
    public Text diceNumber, bodyLabel;
    public Button diceButton;
    public GameObject head, body;
    public GameObject a1, a2;
    public GameObject eye1, eye2;
    public GameObject w1, w2;
    public GameObject[] legs;

    private int luckyNumber = 0;
   
    // make an array of tags with beetle body parts: "antenna", "eye", etc
    // and later an array of callback functions (actions)
    
    void Start ()
    {
        head.active = false;   // all are hidden at start
        body.active = false;
        eye1.active = false;
        // TODO: hide other body parts, including legs
    }

    public void OnClick() {
        diceButton.interactable = false;
     
        // later, use Invoke() to show labels, body parts and button in a nice sequence, slightly delayed
        RollDice();
        diceNumber.text = "Number: ?";
        ShowBodyPartLabel();
        Reveal();
        diceButton.interactable = true;
	}

    public void RollDice() {
        luckyNumber = 1;
    }

    public void ShowBodyPartLabel()
    {
        if (luckyNumber == 1)
            bodyLabel.text = "antenna";
    }

    public void Reveal() {
        // call the appropriate function, based on luckyNumber
        DrawAntenna();
        // or Draw other part..
    }

    private void DrawAntenna() {

        // TODO: check if head exists first
        // and then reveal a1 and a2, as applicable
        // ..
    }
    
    // Add other functions as needed
    // ...
}
