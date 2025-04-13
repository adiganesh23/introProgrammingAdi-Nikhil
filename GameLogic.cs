using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainGameManager : MonoBehaviour
{
    [Header("Stat Display Texts")]
    public TMP_Text nameText;
    public TMP_Text ageText;
    public TMP_Text moraleText;
    public TMP_Text moneyText;
    public TMP_Text weekText;
    public TMP_Text conditionText;
    public TMP_Text offensiveRatingText;
    public TMP_Text defensiveRatingText;
    public TMP_Text playerNumberText;
    public TMP_Text yearText; // TextMeshPro for Year
    public TMP_Text teamRecordText; // TextMeshPro for Team Record

    [Header("Buttons")]
    public Button homeButton;
    public Button continueButton;
    public Button nextYearButton; // New Button for Next Year
    public Button endOfFourthYearButton; // New Button for End of Fourth Year

    // Player stat keys
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
    private const string WINS_KEY = "TeamWins";
    private const string LOSSES_KEY = "TeamLosses";

    [Header("Static Variables (for testing purposes)")]
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
    public int teamWins;
    public int teamLosses;

    void Start()
    {
        LoadStatsFromPrefs();
        UpdateStatTexts();

        homeButton.onClick.AddListener(ReturnToHome);
        continueButton.onClick.AddListener(ContinueToNextScene);
        nextYearButton.onClick.AddListener(SimulateNextYear); // Add Listener for Next Year Button
        endOfFourthYearButton.onClick.AddListener(SkipToFourthYear); // Add Listener for End of Fourth Year Button
    }

    public void LoadStatsFromPrefs()
    {
        if (!PlayerPrefs.HasKey(WEEK_KEY)) InitializeDefaults();

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
        teamWins = PlayerPrefs.GetInt(WINS_KEY, 0);
        teamLosses = PlayerPrefs.GetInt(LOSSES_KEY, 0);
    }

    public void SaveStatsToPrefs()
    {
        PlayerPrefs.SetString(NAME_KEY, playerName);
        PlayerPrefs.SetInt(AGE_KEY, age);
        PlayerPrefs.SetInt(MORALE_KEY, morale);
        PlayerPrefs.SetInt(MONEY_KEY, money);
        PlayerPrefs.SetInt(WEEK_KEY, week);
        PlayerPrefs.SetInt(CONDITION_KEY, condition);
        PlayerPrefs.SetInt(OFF_RATING_KEY, offensiveRating);
        PlayerPrefs.SetInt(DEF_RATING_KEY, defensiveRating);
        PlayerPrefs.SetInt(PLAYER_NUMBER_KEY, playerNumber);
        PlayerPrefs.SetInt(YEAR_KEY, year);
        PlayerPrefs.SetInt(WINS_KEY, teamWins);
        PlayerPrefs.SetInt(LOSSES_KEY, teamLosses);
        PlayerPrefs.Save();
    }

    public void UpdateStatTexts()
    {
        nameText.text = playerName;
        ageText.text = "Age: " + age;
        moraleText.text = morale + "%";
        moneyText.text = "$" + money;
        weekText.text = week.ToString();
        conditionText.text = condition + "%";
        offensiveRatingText.text = offensiveRating.ToString();
        defensiveRatingText.text = defensiveRating.ToString();
        playerNumberText.text = playerNumber.ToString();
        yearText.text = year.ToString();
        teamRecordText.text = teamWins.ToString() + "-" + teamLosses.ToString();
    }

    public void ReturnToHome()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ContinueToNextScene()
    {
        int randomEventTrigger = Random.Range(0, 10);
        if (randomEventTrigger < 5)
        {
            SceneManager.LoadScene("Decision2");
            teamWins++;
        }
        else
        {
            SceneManager.LoadScene("Decision1");
            teamLosses++;
        }

        week++;
        if (week > 15)
        {
            SceneManager.LoadScene("End Of The Year");
        }

        SaveStatsToPrefs();
        UpdateStatTexts();
    }

    public void SimulateNextYear()
    {
        // Disable the button to prevent multiple clicks
        nextYearButton.interactable = false;

        week = 1;
        year++;
        Debug.Log("Year: " + year);
        age++;
        morale = Mathf.Max(50, morale - 10);

        // Set teamWins and teamLosses to random values that add up to 15
        teamWins = Random.Range(0, 16); // Random wins between 0 and 15
        teamLosses = 15 - teamWins;     // Losses are the remainder

        SaveStatsToPrefs();
        SceneManager.LoadScene("End Of The Year");
    }

    public void SkipToFourthYear()
    {
        week = 1;
        year = 4;
        age += (4 - (PlayerPrefs.GetInt(YEAR_KEY, 1)));
        morale = Mathf.Max(30, morale - 30);

        // Set teamWins and teamLosses to random values that add up to 15
        teamWins = Random.Range(0, 16); // Random wins between 0 and 15
        teamLosses = 15 - teamWins;     // Losses are the remainder

        SaveStatsToPrefs();
        SceneManager.LoadScene("End Of The Year");
    }

    public void InitializeDefaults()
    {
        PlayerPrefs.SetInt(MORALE_KEY, 100);
        PlayerPrefs.SetInt(MONEY_KEY, 1000);
        PlayerPrefs.SetInt(WEEK_KEY, 1);
        PlayerPrefs.SetInt(CONDITION_KEY, 100);
        PlayerPrefs.SetInt(OFF_RATING_KEY, 70);
        PlayerPrefs.SetInt(DEF_RATING_KEY, 70);
        PlayerPrefs.SetInt(PLAYER_NUMBER_KEY, 23);
        PlayerPrefs.SetInt(YEAR_KEY, 1);
        PlayerPrefs.SetInt(WINS_KEY, 0);
        PlayerPrefs.SetInt(LOSSES_KEY, 0);
        PlayerPrefs.Save();
    }
}
