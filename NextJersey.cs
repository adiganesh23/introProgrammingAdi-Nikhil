using UnityEngine;
using UnityEngine.UI;

public class NextJersey : MonoBehaviour
{
    public Button rightButton;
    public Button leftButton;
    public Image displayImage; // UI Image where the jersey will be displayed
    public Sprite[] jerseyImages; // Array of Sprites for the different jerseys
    private int currentIndex = 0; // Index to track the current jersey

    void Start()
    {
        // Set up the button click listeners
        rightButton.onClick.AddListener(UpdateJerseyForward);
        leftButton.onClick.AddListener(UpdateJerseyBackward);

        // Display the first jersey by default
        if (jerseyImages.Length > 0)
        {
            displayImage.sprite = jerseyImages[currentIndex];
        }
    }

    // Update jersey to the next image in the array
    public void UpdateJerseyForward()
    {
        if (jerseyImages.Length == 0) return;

        currentIndex = (currentIndex + 1) % jerseyImages.Length; // Wrap around when reaching the end
        displayImage.sprite = jerseyImages[currentIndex];
    }

    // Update jersey to the previous image in the array
    public void UpdateJerseyBackward()
    {
        if (jerseyImages.Length == 0) return;

        currentIndex = (currentIndex - 1 + jerseyImages.Length) % jerseyImages.Length; // Wrap around when going backward
        displayImage.sprite = jerseyImages[currentIndex];
    }
}
