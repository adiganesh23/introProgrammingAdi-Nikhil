using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Button startButton;
    public Button settingsButton;
    public Button instructionsButton;
    public Button exitButton;

    public AudioSource buttonClickAudio; // AudioSource for button click sound

    public void startButtonClicked()
    {
        PlayButtonClickSound(); // Play sound
        if (!PlayerPrefs.HasKey("PlayerLastName"))
        {
            // Redirect to player creation if no player data exists
            SceneManager.LoadScene("Player Selection Page");
            Debug.Log("Redirecting to CreatePlayer scene");
        }
        else
        {
            Debug.Log("Player data found, proceeding to Game Screen");
            SceneManager.LoadScene("Game Screen"); // Proceed to the main game screen if player data exists
        }
    }

    public void settingsButtonClicked()
    {
        PlayButtonClickSound(); // Play sound
        SceneManager.LoadScene("SettingsA");
        Debug.Log("Settings button clicked");
    }

    public void instructionsButtonClicked()
    {
        PlayButtonClickSound(); // Play sound
        SceneManager.LoadScene("Instructions");
        Debug.Log("Instructions button clicked");
    }

    public void exitButtonClicked()
    {
        PlayButtonClickSound(); // Play sound
        SceneManager.LoadScene("StopScreen");
        Debug.Log("Exit button clicked");
    }

    private void PlayButtonClickSound()
    {
        if (buttonClickAudio != null)
        {
            buttonClickAudio.Play(); // Play the audio clip
        }
        Debug.Log("Button click sound played");
    }
}
