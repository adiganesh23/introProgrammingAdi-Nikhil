using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using System;

public class CreatePlayerHandler : MonoBehaviour
{
    public Button NextButton;
    public Button testNameButton;
    public Button homeButton;
    [SerializeField] public InputField PlayerFNameInputField;
    [SerializeField] public InputField PlayerLNameInputField;
    [SerializeField] public InputField PlayerNumberInputField; 
    public TMP_Text name1;
    public TMP_Text number;

    
    public void updateShirt() {
        if(PlayerLNameInputField.text.Length > 0 && PlayerLNameInputField.text.Length < 7) {
            name1.text = PlayerLNameInputField.text;
        } else {
            Debug.Log("Player last name is invalid, it must be less than 7 characters");
            
        }
        int num;
        if (int.TryParse(PlayerNumberInputField.text, out num)) // Safely try to parse the input
        {
            if (num > 0 && num < 100) // Ensure the number is between 1 and 99
            {
                number.text = num.ToString();
            }
            else
            {
                Debug.Log("Player number is invalid, it must be between 1 and 99");
            }
        }
        else
        {
            Debug.Log("Player number is invalid, it must be a valid integer.");
        }
    }
    public void NextButtonClicked() {
        string fName = PlayerFNameInputField.text;
        string lName = PlayerLNameInputField.text;
        int playerNumber;

        if (!int.TryParse(PlayerNumberInputField.text, out playerNumber))
        {
            Debug.Log("Invalid Player Number");
            return;
        }

        if (fName.Length < 7 && lName.Length < 7)
        {
            // Save the values
            PlayerPrefs.SetString("PlayerFirstName", fName);
            PlayerPrefs.SetString("PlayerLastName", lName);
            PlayerPrefs.SetInt("PlayerNumber", playerNumber);
            PlayerPrefs.Save(); // Ensure values are saved immediately

            // Debugging logs to check values
            Debug.Log("Saving: First Name = " + fName + ", Last Name = " + lName + ", Number = " + playerNumber);

            SceneManager.LoadScene("Game Screen");
        }
        else
        {
            Debug.Log("Invalid Text: Player name must be less than 7 characters");
        }
    }
    public void homeButtonClicked()
    {
        // Load the home scene
        SceneManager.LoadScene("Main Menu");
    }
    public void exitButtonClicked()
    {
        SceneManager.LoadScene("StopScreen");
        Debug.Log("Exit button clicked");
    }
}
