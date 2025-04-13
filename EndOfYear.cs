using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndOfYear : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI numberText;
    public TMP_Text ageText;
    public TMP_Text record;
    public TMP_Text award;
    public TMP_Text stats;
    public TMP_Text finish;

    private const string NAME_KEY = "PlayerLastName";
    private const string AGE_KEY = "PlayerAge";
    private const string MORALE_KEY = "PlayerMorale";
    private const string MONEY_KEY = "PlayerMoney";
    private const string WEEK_KEY = "PlayerWeek";
    private const string CONDITION_KEY = "PlayerCondition";
    private const string OFF_RATING_KEY = "PlayerOffensiveRating";
    private const string DEF_RATING_KEY = "PlayerDefensiveRating";
    private const string PLAYER_NUMBER_KEY = "PlayerNumber";
    private const string YEAR_KEY = "PlayerYear";
    private const string WINS_KEY = "TeamWins"; // New key for Wins
    private const string LOSSES_KEY = "TeamLosses"; // New key for Losses

    public string playerName;
    public int age;
    public int morale;
    public int money;
    public int week;
    public int condition;
    public int offensiveRating;
    public int defensiveRating;
    public int playerNumber;
    public int year;
    public int teamWins; // New variable for Wins
    public int teamLosses; // New variable for Losses

    void Start()
    {
        playerName = PlayerPrefs.GetString(NAME_KEY);
        age = PlayerPrefs.GetInt(AGE_KEY, 18);
        morale = PlayerPrefs.GetInt(MORALE_KEY, 100);
        money = PlayerPrefs.GetInt(MONEY_KEY, 1000);
        week = PlayerPrefs.GetInt(WEEK_KEY, 1);
        condition = PlayerPrefs.GetInt(CONDITION_KEY, 100);
        offensiveRating = PlayerPrefs.GetInt(OFF_RATING_KEY, 70);
        defensiveRating = PlayerPrefs.GetInt(DEF_RATING_KEY, 70);
        playerNumber = PlayerPrefs.GetInt(PLAYER_NUMBER_KEY, 23);
        year = PlayerPrefs.GetInt(YEAR_KEY, 1);
        teamWins = PlayerPrefs.GetInt(WINS_KEY, 0); // Load Wins
        teamLosses = PlayerPrefs.GetInt(LOSSES_KEY, 0); // Load Losses

        nameText.text = playerName;
        ageText.text = age.ToString();
        record.text = teamWins.ToString() + "-" + teamLosses.ToString();
        numberText.text = playerNumber.ToString();

        // Determine award and season finish based on stats
        if (offensiveRating > 85 && teamWins > 10)
        {
            award.text = "MVP";
            finish.text = "Championship Winner";
        }
        else if (offensiveRating > 70 && defensiveRating > 70 && teamWins > 8)
        {
            award.text = "All Star";
            finish.text = "Playoff Contender";
        }
        else if (teamWins > 5)
        {
            award.text = "Team Player";
            finish.text = "Playoff Knockout";
        }
        else
        {
            award.text = "Rising Star";
            finish.text = "Missed Playoffs";
        }

        stats.text = "Points: " + (offensiveRating * 10).ToString(); // Placeholder for stats

        // Reset stats for the new year
        week = 1;
        teamLosses = 0; // Reset losses at the end of the year
        teamWins = 0; // Reset wins at the end of the year
        PlayerPrefs.SetInt(WEEK_KEY, week);
        PlayerPrefs.SetInt(YEAR_KEY, year);
        PlayerPrefs.SetInt(AGE_KEY, age);
        PlayerPrefs.SetInt(WINS_KEY, teamWins); // Save Wins
        PlayerPrefs.SetInt(LOSSES_KEY, teamLosses); // Save Losses
        PlayerPrefs.Save();
    }

    public void continueButton()
    {
        SceneManager.LoadScene("Game Screen");
        Debug.Log("Continue button clicked");
    }

    public void homeButton()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Home button clicked");
    }
}
