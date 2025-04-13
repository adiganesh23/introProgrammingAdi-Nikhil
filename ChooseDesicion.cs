using UnityEngine;
using UnityEngine.UI;  // For UI components like Text and Buttons
using TMPro;

public class ChooseDesicion : MonoBehaviour
{
    [Header("Text")]
    public TMP_Text titleText;         // UI Text to display the title
    public TMP_Text promptText;        // UI Text to display the prompt
    public Text opt1text;
    public Text opt2text;
    
    [Header("Button")]
    public Button decision1Button; // UI Button for Decision 1
    public Button decision2Button; // UI Button for Decision 2
    

    string[] prompt;
    string[] decision1;
    string[] decision2;
    int currentIndex; // This will no longer reset to 0 when you leave the screen
    string[] title;
    int decisionChoice;

    void Start()
    {
        // Load the saved index and choice from PlayerPrefs if they exist, otherwise default to 0
        currentIndex = PlayerPrefs.GetInt("CurrentIndex", 0); 
        decisionChoice = PlayerPrefs.GetInt("PlayerChoice", 0); // Load previous decision if any
        
        // Example prompts and decisions
        prompt = new string[] {
            "Go out with friends on a school night?",
            "Declare early for the draft.",
            "Skip optional recovery sessions."
        };

        decision1 = new string[] {
            "Yes, go out and have fun!", // For the first prompt
            "Yes, declare for the draft!",  // For the second prompt
            "Yes, skip the session"
        };

        decision2 = new string[] {
            "No, stay home and study.", 
            "No, stay in school and finish your degree.", // For the second prompt
            "No, attend the recovery session" // For the third prompt
        };

        title = new string[] {
            "Social Life Decision", // Title for the first prompt
            "Career Decision", // Title for the second prompt
            "Training Decision" // Title for the third prompt
        };

        // Load the current prompt based on the stored index
        LoadPrompt(currentIndex);

        // Add listeners to buttons
        decision1Button.onClick.AddListener(() => MakeDecision(1));
        decision2Button.onClick.AddListener(() => MakeDecision(2));
    }

    // Loads the current prompt, title, and decisions
    void LoadPrompt(int index)
    {
        if (index < prompt.Length)
        {
            titleText.text = title[index];         // Display the title
            promptText.text = prompt[index];       // Display the prompt
            opt1text.text = decision1[index];  // Update Decision 1 text
            opt2text.text = decision2[index];  // Update Decision 2 text
        }
        else
        {
            // If we've run out of prompts, reset to the first prompt
            currentIndex = 0;  // Reset to the first prompt
            LoadPrompt(currentIndex);  // Load the first prompt again
        }
    }

    // Handles the decision-making logic
    void MakeDecision(int decisionNumber)
    {
        if (decisionNumber == 1)
        {
            Debug.Log("Player chose: " + decision1[currentIndex]);
            decisionChoice = 1;
            PlayerPrefs.SetInt("PlayerChoice", decisionChoice); // Store the choice for further logic if needed
        }
        else
        {
            Debug.Log("Player chose: " + decision2[currentIndex]);
            decisionChoice = 2; 
            PlayerPrefs.SetInt("PlayerChoice", decisionChoice); // Store the choice for further logic if needed
        }

        // Move to the next prompt
        currentIndex++;

        // Save the current index to PlayerPrefs to persist the player's progress
        PlayerPrefs.SetInt("CurrentIndex", currentIndex);

        // Load the next prompt or reset if we reach the end
        LoadPrompt(currentIndex);
    }
}
