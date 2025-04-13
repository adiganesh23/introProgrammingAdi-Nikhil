using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DecisionManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button decision1Button;
    public Button decision2Button;

    [Header("Text")]
    public TMP_Text nameText;         // To display player's name
    public TMP_Text playerNumberText; // To display player's number
    public TMP_Text titleText;        // To display the decision title
    public TMP_Text promptText;       // To display the current decision prompt
    public Text opt1text;             // Option 1 text
    public Text opt2text;             // Option 2 text

    // College decision arrays
    string[] COLprompt;
    string[] COLdecision1;
    string[] COLdecision2;
    string[] COLtitle;
    int[,] COLoption1Consequences;
    int[,] COLoption2Consequences;

    // NBA decision arrays
    string[] PROprompt;
    string[] PROdecision1;
    string[] PROdecision2;
    string[] PROtitle;
    int[,] PROoption1Consequences;
    int[,] PROoption2Consequences;

    string[] currentPrompt;
    string[] currentDecision1;
    string[] currentDecision2;
    string[] currentTitle;
    int[,] currentOption1Consequences;
    int[,] currentOption2Consequences;

    int currentIndex; // Index of current decision prompt
    int decisionChoice;

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

    int year;
    

    void Start()
    {
        // Load saved data from PlayerPrefs
        year = PlayerPrefs.GetInt(YEAR_KEY, 1); // Default to 1 if not set
        currentIndex = PlayerPrefs.GetInt("CurrentIndex", 0); 
        decisionChoice = PlayerPrefs.GetInt("PlayerChoice", 0); 
        
        nameText.text = PlayerPrefs.GetString("PlayerLastName");
        playerNumberText.text = PlayerPrefs.GetInt("PlayerNumber").ToString(); // Display the player number

        // Pro Prompt and Decision Arrays
        PROtitle = new string[] {
            "Rest Day", "Postgame Diet", "Media Response", "Team Meeting", "Charity Event",
            "Endorsement Deal", "Extra Training", "Social Media", "Family Time", "Celebration",
            "Team Dynamics", "Community Engagement", "Contract Negotiation", "Game Strategy", 
            "Sponsorship", "Workout", "Press Conference", "Travel Plans", "Coach Criticism", 
            "Teammate Bonding", "Lifestyle", "Injury", "Back-to-Backs", "Film Study", "Gambling",
            "Fan Interaction", "Criticism", "Reality TV", "Postgame Routine", "New Look",
            "Tech Investment", "Charity Donation", "Mentorship", "All-Star Break", "Dance Challenge", 
            "Role Discussion", "Superstition", "Fan Event", "Charity Auction", "Fitness Challenge", 
            "Trade Request", "Cheat Meal", "Locker Room", "Media Day", "Campaigning", 
            "Preseason Game"

        };
        PROprompt = new string[] {
            "Take a day off to recover?", "Indulge in fast food after a game?", "Respond to a journalist's critique?", 
            "Skip the team's strategy meeting?", "Attend a local charity event?", "Sign a deal with a controversial brand?", 
            "Spend extra hours in the gym?", "Post about a controversial topic?", "Visit family during the season?", 
            "Party late after a big win?", "Confront a teammate about effort?", "Host a basketball clinic for kids?", 
            "Hold out for a better contract?", "Suggest a new play to the coach?", "Promote a luxury product?", 
            "Skip a scheduled workout?", "Answer controversial questions honestly?", 
            "Request extra days off after a road trip?", "Confront the coach about your role?", 
            "Plan a team outing?", "Buy a luxury car?", "Play through a minor injury?", "Reduce practice intensity?", 
            "Spend extra hours analyzing footage?", "Join teammates at a casino?", "Allow a fan to shadow you for a day?", 
            "Respond to a fan's negative comment?", "Sign a reality TV deal?", "Spend time signing autographs?", 
            "Change your appearance drastically?", "Invest in a startup?", "Donate a game check to charity?", 
            "Mentor a struggling rookie?", "Skip All-Star Weekend?", "Join a social media trend?", 
            "Request more playing time?", "Change your pregame routine?", "Host an unscheduled fan meet?", 
            "Donate a jersey?", "Compete in a fitness challenge?", "Request a trade?", 
            "Skip postgame nutrition?", "Use your playlist for warm-ups?", "Skip media obligations?", 
            "Start an All-NBA campaign?", "Skip a preseason game?"
        };
        PROdecision1 = new string[] {
            "Yes, take the day off.", "Yes, enjoy fast food.", "Yes, respond aggressively.", 
            "Yes, skip the meeting.", "Yes, attend the event.", "Yes, sign the deal.", 
            "Yes, train harder.", "Yes, share your opinion.", "Yes, prioritize family.", 
            "Yes, celebrate late.", "Yes, address it directly.", "Yes, host the clinic.", 
            "Yes, push for more.", "Yes, offer ideas.", "Yes, promote it.", 
            "Yes, skip it.", "Yes, be direct.", "Yes, take extra time.", 
            "Yes, discuss with the coach.", "Yes, organize it.", "Yes, splurge.", 
            "Yes, play through it.", "Yes, lighten practice.", "Yes, study more.", 
            "Yes, gamble with them.", "Yes, accept the request.", "Yes, reply directly.", 
            "Yes, sign it.", "Yes, engage with fans.", "Yes, change it.", 
            "Yes, take a chance.", "Yes, donate it.", "Yes, help them.", 
            "Yes, take a break.", "Yes, participate.", "Yes, discuss with the coach.", 
            "Yes, try something new.", "Yes, host it.", "Yes, donate it.", 
            "Yes, take it on.", "Yes, push for it.", "Yes, skip it.", 
            "Yes, play it.", "Yes, skip them.", "Yes, promote yourself.", 
            "Yes, skip it."
        };
        PROdecision2 = new string[] {
                "No, keep practicing.", "No, stick to the meal plan.", "No, stay professional.", 
                "No, attend and contribute.", "No, focus on training.", "No, decline the offer.", 
                "No, stick to the schedule.", "No, avoid drama.", "No, focus on basketball.", 
                "No, rest for the next game.", "No, let it slide.", "No, focus on recovery.", 
                "No, accept the offer.", "No, trust the coach.", "No, pass on it.", 
                "No, attend as planned.", "No, remain diplomatic.", "No, return immediately.", 
                "No, stay silent.", "No, focus on the season.", "No, save money.", 
                "No, sit out and recover.", "No, push through.", "No, stick to routine.", 
                "No, stay focused.", "No, maintain privacy.", "No, ignore it.", 
                "No, focus on basketball.", "No, prioritize recovery.", "No, maintain your style.", 
                "No, pass on it.", "No, keep earnings.", "No, focus on yourself.", 
                "No, attend as planned.", "No, avoid it.", "No, prove yourself.", 
                "No, stick to it.", "No, focus on recovery.", "No, keep it.", 
                "No, focus on training.", "No, stay loyal.", "No, follow the plan.", 
                "No, share the aux.", "No, attend as required.", "No, let your game speak.", 
                "No, play as planned."
        };
        PROoption1Consequences = new int[,] {
            { 5, 0, 0, 10, 0 },   // Rest Day
            { -5, 0, 0, -5, 0 },  // Postgame Diet
            { -10, 0, -5, -5, 0 },// Media Response
            { -5, 5, 0, 0, 0 },   // Team Meeting
            { 10, 0, 0, 5, -50 }, // Charity Event
            { 5, -5, 0, 0, 50 },  // Endorsement Deal
            { 5, 5, 10, -5, 0 },  // Extra Training
            { -10, 0, 0, 0, 0 },  // Social Media
            { 10, 0, 0, 0, -10 }, // Family Time
            { 10, -5, 5, -10, 0 },// Celebration
            { -5, 5, 0, 0, 0 },   // Team Dynamics
            { 10, 0, 0, 5, -20 }, // Community Engagement
            { -10, 0, 5, 0, 0 },  // Contract Negotiation
            { 5, 5, 10, 0, 0 },   // Game Strategy
            { 10, 0, 5, 0, 50 },  // Sponsorship
            { -10, 0, 0, -5, 0 }, // Workout
            { -5, 0, 0, 0, 0 },   // Press Conference
            { 5, 0, 0, 10, 0 },   // Travel Plans
            { -5, 0, -5, 0, 0 },  // Coach Criticism
            { 10, 5, 0, 5, 0 },   // Teammate Bonding
            { -5, -5, 0, 0, -50 },// Lifestyle
            { 5, 0, 0, -5, 0 },   // Injury
            { 5, 0, 5, 5, 0 },    // Back-to-Backs
            { 10, 5, 5, 0, 0 },   // Film Study
            { -10, -5, 0, -5, -50 }, // Gambling
            { 10, 0, 0, 5, -10 }, // Fan Interaction
            { -10, 0, 0, 0, 0 },  // Criticism
            { 10, 0, 0, 0, 50 },  // Reality TV
            { 5, 0, 5, 0, 0 },    // Postgame Routine
            { 5, 0, 0, 0, -20 },  // New Look
            { 10, 0, 5, 0, 50 },  // Tech Investment
            { 10, 0, 0, 5, -50 }, // Charity Donation
            { 5, 5, 0, 5, 0 },    // Mentorship
            { 10, 0, 0, 5, 0 },   // All-Star Break
            { 0, 0, 0, 0, 0 },    // Dance Challenge
            { 5, 0, 5, 0, 0 },    // Role Discussion
            { 5, 0, 0, 0, 0 },    // Superstition
            { 10, 0, 0, 0, -50 }, // Fan Event
            { 10, 0, 0, 5, -50 }, // Charity Auction
            { 5, 5, 0, 5, 0 },    // Fitness Challenge
            { -10, -5, 0, -5, 0 },// Trade Request
            { -5, 0, 0, -5, 0 },  // Cheat Meal
            { -10, 5, 5, 0, 0 },  // Locker Room
            { 5, 0, 5, 0, 0 },    // Media Day
            { 5, 0, 5, 0, 0 },    // Campaigning
            { -5, 0, 0, 0, 0 }    // Preseason Game
        };
        PROoption2Consequences = new int[,] {
            // Morale, Defense, Offense, Condition, Money
            { -5, 0, 0, -5, 0 },  // Rest Day
            { 5, 0, 0, 5, 0 },    // Postgame Diet
            { 10, 0, 0, 5, 0 },   // Media Response
            { 5, 0, 0, 0, 0 },    // Team Meeting
            { -10, 0, 0, 0, 50 }, // Charity Event
            { -5, 0, 0, 0, 0 },   // Endorsement Deal
            { -5, -5, -10, 0, 0 },// Extra Training
            { 10, 0, 0, 5, 0 },   // Social Media
            { -10, 0, 0, -5, 10 },// Family Time
            { -10, 0, -5, 10, 0 },// Celebration
            { 10, 0, 0, 0, 0 },   // Team Dynamics
            { -10, 0, 0, -5, 20 },// Community Engagement
            { 10, 0, 0, 0, 0 },   // Contract Negotiation
            { -5, 0, -5, 0, 0 },  // Game Strategy
            { -10, 0, -5, 0, 0 }, // Sponsorship
            { 10, 0, 0, 0, 0 },   // Workout
            { 5, 0, 0, 0, 0 },    // Press Conference
            { -5, 0, 0, -5, 0 },  // Travel Plans
            { 10, 0, 0, 0, 0 },   // Coach Criticism
            { -10, -5, 0, -5, 0 },// Teammate Bonding
            { 5, 5, 0, 0, 50 },   // Lifestyle
            { -5, 0, 0, 5, 0 },   // Injury
            { -5, 0, -5, -5, 0 }, // Back-to-Backs
            { -10, -5, -5, 0, 0 },// Film Study
            { 10, 5, 0, 5, 50 },  // Gambling
            { -10, 0, 0, -5, 10 },// Fan Interaction
            { 10, 0, 0, 0, 0 },   // Criticism
            { -10, 0, 0, 0, -50 },// Reality TV
            { -5, 0, -5, 0, 0 },  // Postgame Routine
            { -5, 0, 0, 0, 20 },  // New Look
            { -10, 0, -5, 0, -50 },// Tech Investment
            { -10, 0, 0, -5, 50 },// Charity Donation
            { -5, -5, 0, -5, 0 }, // Mentorship
            { -10, 0, 0, -5, 0 }, // All-Star Break
            { 0, 0, 0, 0, 0 },    // Dance Challenge
            { -5, 0, -5, 0, 0 },  // Role Discussion
            { -5, 0, 0, 0, 0 },   // Superstition
            { -10, 0, 0, 0, 50 }, // Fan Event
            { -10, 0, 0, -5, 50 },// Charity Auction
            { -5, -5, 0, -5, 0 }, // Fitness Challenge
            { 10, 5, 0, 5, 0 },   // Trade Request
            { 5, 0, 0, 5, 0 },    // Cheat Meal
            { 10, -5, -5, 0, 0 }, // Locker Room
            { -5, 0, -5, 0, 0 },  // Media Day
            { -5, 0, -5, 0, 0 },  // Campaigning
            { 5, 0, 0, 0, 0 }     // Preseason Game
        };

        // College Prompt and Decision Arrays
        COLprompt = new string[] {
            "Do you want to spend extra hours in the gym this week?",
            "Would you like to skip practice and rest instead?",
            "Will you hire a personal trainer to help improve your fitness?",
            "Join team conditioning drills to boost performance?",
            "Focus on recovery after the latest game?",
            "Try a yoga session to improve flexibility?",
            "Play through a minor injury or take it easy?",
            "Commit to an intense workout this week?",
            "Follow a new diet plan for better performance?",
            "Train with teammates during off-days?",
            "Skip a class to focus on basketball practice?",
            "Stay up late studying for exams?",
            "Request tutoring to help with academics?",
            "Miss a team meeting to finish assignments?",
            "Try to balance academics and practice this week?",
            "Work on improving your three-point shot?",
            "Focus on defensive drills during practice?",
            "Improve free throw accuracy this week?",
            "Watch game tape to analyze opponents?",
            "Spend time learning better court positioning?",
            "Go to a party to relax and socialize?",
            "Spend time bonding with teammates?",
            "Organize a team dinner to improve chemistry?",
            "Skip social events to train harder?",
            "Resolve a conflict with a teammate?",
            "Meditate to improve focus and morale?",
            "Practice public speaking for upcoming interviews?",
            "Take a mental health day for self-care?",
            "Volunteer in the community this week?",
            "Ignore harsh criticism from fans or media?",
            "Take a leadership role during games?",
            "Request more playtime from the coach?",
            "Follow the coach’s new defensive strategy?",
            "Question the coach's tactics after the last game?",
            "Accept reduced playtime for the team’s benefit?",
            "Play through minor injuries to stay on the court?",
            "Take a week off to heal your body?",
            "Consult a sports doctor about injuries?",
            "Push through pain for the sake of performance?",
            "Switch to light training for recovery?",
            "Spend a weekend with your family?",
            "Go out for fast food after a game?",
            "Buy new basketball gear this week?",
            "Sleep in and skip morning practice?",
            "Attend a motivational seminar?",
            "Mentor a younger teammate?",
            "Address a teammate's misbehavior?",
            "Join team-building activities?",
            "Challenge a teammate to a friendly competition?",
            "Apologize to your team for mistakes?"
        };

        COLdecision1 = new string[] {
            "Yes, spend the extra hours.", "Yes, skip practice.", "Yes, hire a trainer.", "Yes, join the drills.", "Yes, focus on recovery.",
            "Yes, try yoga.", "Yes, play through injury.", "Yes, commit to the workout.", "Yes, follow the diet.", "Yes, train with teammates.",
            "Yes, skip class.", "Yes, study late.", "Yes, request tutoring.", "Yes, miss the meeting.", "Yes, try balancing both.",
            "Yes, work on three-point shots.", "Yes, focus on defensive drills.", "Yes, improve free throws.", "Yes, watch game tape.", "Yes, learn court positioning.",
            "Yes, attend the party.", "Yes, bond with teammates.", "Yes, organize dinner.", "Yes, skip social events.", "Yes, resolve the conflict.",
            "Yes, meditate.", "Yes, practice speaking.", "Yes, take the day off.", "Yes, volunteer.", "Yes, ignore criticism.",
            "Yes, take leadership.", "Yes, request more time.", "Yes, follow the strategy.", "Yes, question tactics.", "Yes, accept reduced time.",
            "Yes, play through injury.", "Yes, take the week off.", "Yes, consult a doctor.", "Yes, push through pain.", "Yes, switch to light training.",
            "Yes, spend the weekend.", "Yes, get fast food.", "Yes, buy new gear.", "Yes, sleep in.", "Yes, attend the seminar.",
            "Yes, mentor them.", "Yes, address the issue.", "Yes, join the activity.", "Yes, challenge them.", "Yes, apologize."
        };

        COLdecision2 = new string[] {
            "No, stick to the usual routine.", "No, attend practice.", "No, save money and train alone.", "No, skip the drills.", "No, keep pushing forward.",
            "No, skip yoga.", "No, rest instead.", "No, stick to lighter workouts.", "No, keep your current diet.", "No, take the day off.",
            "No, attend class.", "No, focus on rest.", "No, manage academics alone.", "No, prioritize the meeting.", "No, choose one focus.",
            "No, stick to other skills.", "No, focus on offense instead.", "No, work on something else.", "No, rely on instinct.", "No, skip positioning drills.",
            "No, stay in.", "No, skip bonding time.", "No, let someone else organize.", "No, go to social events.", "No, leave it unresolved.",
            "No, skip meditation.", "No, focus on basketball.", "No, keep working.", "No, skip volunteering.", "No, respond to critics.",
            "No, stay in the background.", "No, wait for more opportunities.", "No, suggest alternatives.", "No, trust the coach.", "No, fight for more time.",
            "No, take a break.", "No, keep playing.", "No, self-manage injuries.", "No, focus on rest.", "No, continue full training.",
            "No, focus on basketball.", "No, skip the outing.", "No, save the money.", "No, attend practice.", "No, skip the seminar.",
            "No, let them learn alone.", "No, let it go.", "No, skip the activity.", "No, focus on yourself.", "No, move on."
        };

        COLtitle = new string[] {
                "Extra Gym Time", "Skip Practice", "Hire Personal Trainer", "Team Conditioning", "Focus on Recovery",
                "Yoga Session", "Play Through Injury", "Intense Workout", "New Diet Plan", "Team Off-Day Training",
                "Skip Class for Practice", "Study for Exams", "Ask for Tutoring", "Miss Team Meeting", "Balance Both",
                "Three-Point Shooting", "Defensive Drills", "Free Throw Accuracy", "Watch Game Tape", "Court Positioning",
                "Attend Party", "Bond with Teammates", "Organize Team Dinner", "Skip Social Events", "Resolve Conflict",
                "Meditation Practice", "Public Speaking", "Mental Health Day", "Volunteer Work", "Ignore Criticism",
                "Take Leadership Role", "Request More Playtime", "Follow Defensive Strategy", "Question Tactics",
                "Accept Reduced Playtime", "Play Through Injury", "Take a Week Off", "Consult Sports Doctor",
                "Push Through Pain", "Light Recovery Training", "Weekend with Family", "Fast Food Outing", "Buy New Gear",
                "Sleep In", "Motivational Seminar", "Mentor Teammate", "Address Misbehavior", "Team-Building Activities",
                "Friendly Competition", "Apologize to Team"
        };

        COLoption1Consequences = new int[,] {
            // Morale, Defense, Offense, Condition, Money
            { 5, 10, 10, -5, -200 },       // Extra Gym Time
            { 10, -5, -5, 10, 0 },          // Skip Practice
            { 5, 10, 10, 5, -500 },         // Hire Personal Trainer
            { 5, 15, 10, -5, 0 },           // Team Conditioning
            { 5, 0, 0, 15, 0 },             // Focus on Recovery
            { 10, 0, 0, 10, -100 },         // Yoga Session
            { -10, 0, 5, -15, 0 },          // Play Through Injury
            { -5, 10, 10, -10, 0 },         // Intense Workout
            { 0, 5, 5, 5, -300 },           // New Diet Plan
            { 10, 5, 5, -5, 0 },            // Team Off-Day Training
            { -5, 5, 5, 0, 0 },             // Skip Class for Practice
            { -10, 0, 0, -5, 0 },           // Study for Exams
            { 0, 0, 0, 0, -200 },           // Ask for Tutoring
            { -5, -5, -5, 0, 0 },           // Miss Team Meeting
            { 5, 5, 5, 5, 0 },              // Balance Both
            { 0, 0, 15, 0, 0 },             // Three-Point Shooting
            { 0, 15, 0, 0, 0 },              // Defensive Drills
            { 0, 0, 10, 0, 0 },              // Free Throw Accuracy
            { 0, 10, 10, 0, 0 },            // Watch Game Tape
            { 0, 10, 5, 0, 0 },             // Court Positioning
            { 15, 0, 0, -5, -100 },          // Attend Party
            { 15, 5, 5, 0, -200 },           // Bond with Teammates
            { 20, 5, 5, 0, -300 },           // Organize Team Dinner
            { -5, 5, 5, 5, 0 },              // Skip Social Events
            { 10, 0, 0, 0, 0 },              // Resolve Conflict
            { 15, 0, 0, 5, 0 },              // Meditation Practice
            { 10, 0, 0, 0, 0 },              // Public Speaking
            { 10, 0, 0, 10, 0 },             // Mental Health Day
            { 20, 0, 0, 0, -200 },           // Volunteer Work
            { -5, 0, 0, 0, 0 },              // Ignore Criticism
            { 10, 5, 5, 0, 0 },              // Take Leadership Role
            { -5, 0, 0, 0, 0 },              // Request More Playtime
            { 0, 15, 0, 0, 0 },              // Follow Defensive Strategy
            { -10, 0, 0, 0, 0 },             // Question Tactics
            { 5, 0, 0, 0, 0 },               // Accept Reduced Playtime
            { -10, 0, 5, -15, 0 },           // Play Through Injury (Duplicate?)
            { 5, 0, 0, 20, 0 },              // Take a Week Off
            { 0, 0, 0, 10, -500 },           // Consult Sports Doctor
            { -10, 0, 5, -10, 0 },           // Push Through Pain
            { 5, 0, 0, 15, 0 },              // Light Recovery Training
            { 15, 0, 0, 5, -200 },            // Weekend with Family
            { 10, 0, 0, -5, -50 },            // Fast Food Outing
            { 5, 0, 0, 0, -500 },             // Buy New Gear
            { 10, -5, -5, 5, 0 },             // Sleep In
            { 15, 0, 0, 0, -300 },            // Motivational Seminar
            { 10, 0, 0, 0, 0 },               // Mentor Teammate
            { 5, 0, 0, 0, 0 },                // Address Misbehavior
            { 10, 5, 5, 0, -100 },            // Team-Building Activities
            { 5, 5, 5, 0, 0 },                // Friendly Competition
            { 10, 0, 0, 0, 0 }                // Apologize to Team
        };

        COLoption2Consequences = new int[,] {
            // Morale, Defense, Offense, Condition, Money
            { 0, 0, 0, 5, 0 },                // Stick to Routine
            { -5, 5, 5, -5, 0 },              // Attend Practice
            { 0, 0, 0, 0, 0 },                // Train Alone
            { 0, 0, 0, 5, 0 },                // Skip Drills
            { -5, 5, 5, -5, 0 },              // Keep Pushing Forward
            { 0, 0, 0, 0, 0 },                // Skip Yoga
            { 5, 0, -5, 10, 0 },              // Rest Instead
            { 5, 0, 0, 5, 0 },                // Lighter Workouts
            { 0, 0, 0, 0, 0 },                // Keep Current Diet
            { 5, 0, 0, 5, 0 },                // Take the Day Off
            { 5, 0, 0, 0, 0 },                // Attend Class
            { 10, 0, 0, 5, 0 },               // Focus on Rest
            { 0, 0, 0, 0, 0 },                // Manage Alone
            { 5, 5, 5, 0, 0 },                // Prioritize Meeting
            { -5, 0, 0, 0, 0 },               // Choose One Focus
            { 0, 0, 0, 0, 0 },                // Stick to Other Skills
            { 0, 0, 10, 0, 0 },               // Focus on Offense
            { 0, 0, 0, 0, 0 },                // Work on Something Else
            { 0, 0, 0, 0, 0 },                // Rely on Instinct
            { 0, 0, 0, 0, 0 },                // Skip Positioning Drills
            { -5, 0, 0, 5, 0 },               // Stay In
            { -5, 0, 0, 0, 0 },               // Skip Bonding Time
            { 0, 0, 0, 0, 0 },                // Let Someone Else Organize
            { 10, 0, 0, -5, -100 },           // Go to Social Events
            { -10, 0, 0, 0, 0 },              // Leave Conflict Unresolved
            { 0, 0, 0, 0, 0 },                // Skip Meditation
            { 0, 0, 0, 0, 0 },                // Focus on Basketball
            { -5, 0, 0, -5, 0 },              // Keep Working
            { 0, 0, 0, 0, 0 },                // Skip Volunteering
            { 5, 0, 0, -5, 0 },               // Respond to Critics
            { 0, 0, 0, 0, 0 },                // Stay in Background
            { 5, 0, 0, 0, 0 },                // Wait for Opportunities
            { -5, 0, 0, 0, 0 },               // Suggest Alternatives
            { 5, 0, 0, 0, 0 },                // Trust the Coach
            { -5, 0, 0, 0, 0 },               // Fight for More Time
            { 5, 0, -5, 10, 0 },              // Take a Break
            { -5, 5, 5, -5, 0 },              // Keep Playing
            { 0, 0, 0, 0, 0 },                // Self-Manage Injuries
            { 5, 0, -5, 10, 0 },              // Focus on Rest
            { -5, 5, 5, -5, 0 },              // Continue Full Training
            { -5, 5, 5, 0, 0 },               // Focus on Basketball
            { -5, 0, 0, 5, 0 },               // Skip Outing
            { 0, 0, 0, 0, 0 },                // Save Money
            { -5, 5, 5, -5, 0 },              // Attend Practice
            { 0, 0, 0, 0, 0 },                // Skip Seminar
            { -5, 0, 0, 0, 0 },               // Let Them Learn Alone
            { -5, 0, 0, 0, 0 },               // Let It Go
            { -5, 0, 0, 0, 0 },               // Skip Activity
            { 0, 0, 0, 0, 0 },                // Focus on Yourself
            { -5, 0, 0, 0, 0 }                // Move On
        };

        // Load the correct decision set based on the player's year
        LoadDecisionSet();
        
        // Load the current prompt based on the stored index
        LoadPrompt(currentIndex);

        if (IsGameOver()) {
            // Handle game over logic her
            Debug.Log("Game Over! You have lost.");
            // Optionally, you can load a game over scene or reset the game
            SceneManager.LoadScene("Game Over");
        }
    

        // Add listeners to buttons
        decision1Button.onClick.AddListener(() => MakeDecision(1));
        decision2Button.onClick.AddListener(() => MakeDecision(2));
    }

    // Loads the correct decision set based on the player's year
    void LoadDecisionSet()
    {
        if (year > 4)
        {
            // Use NBA decision arrays
            promptText.text = "NBA Decision Set Loaded";
            // Assign NBA decision arrays
            currentPrompt = PROprompt;
            currentDecision1 = PROdecision1;
            currentDecision2 = PROdecision2;
            currentTitle = PROtitle;
            currentOption1Consequences = PROoption1Consequences;
            currentOption2Consequences = PROoption2Consequences;
        }
        else
        {
            // Use College decision arrays
            promptText.text = "College Decision Set Loaded";
            // Assign College decision arrays
            currentPrompt = COLprompt;
            currentDecision1 = COLdecision1;
            currentDecision2 = COLdecision2;
            currentTitle = COLtitle;
            currentOption1Consequences = COLoption1Consequences;
            currentOption2Consequences = COLoption2Consequences;
        }
    }

    // Loads the current prompt, title, and decisions
    void LoadPrompt(int index)
    {
        if (index < currentPrompt.Length)
        {
            titleText.text = currentTitle[index];         // Display the title
            promptText.text = currentPrompt[index];       // Display the prompt
            opt1text.text = currentDecision1[index];      // Update Decision 1 text
            opt2text.text = currentDecision2[index];      // Update Decision 2 text
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
            Debug.Log("Player chose: " + currentDecision1[currentIndex]);
            ApplyConsequences(currentOption1Consequences, currentIndex);
            decisionChoice = 1;
            PlayerPrefs.SetInt("PlayerChoice", decisionChoice); // Store the choice for further logic if needed
        }
        else
        {
            Debug.Log("Player chose: " + currentDecision2[currentIndex]);
            ApplyConsequences(currentOption2Consequences, currentIndex);
            decisionChoice = 2;
            PlayerPrefs.SetInt("PlayerChoice", decisionChoice); // Store the choice for further logic if needed
        }

        


        // Move to the next prompt
        currentIndex++;

        // Save the current index to PlayerPrefs to persist the player's progress
        PlayerPrefs.SetInt("CurrentIndex", currentIndex);

        // Reload the scene or transition to the next screen
        SceneManager.LoadScene("Game Screen");
    }

    // Applies the consequences of the chosen decision
    void ApplyConsequences(int[,] consequencesArray, int decisionIndex)
    {
        // Extract the stat changes from the array
        int moraleChange = consequencesArray[decisionIndex, 0];
        int defenseChange = consequencesArray[decisionIndex, 1];
        int offenseChange = consequencesArray[decisionIndex, 2];
        int conditionChange = consequencesArray[decisionIndex, 3];
        int moneyChange = consequencesArray[decisionIndex, 4];

        // Update PlayerPrefs for each stat
        PlayerPrefs.SetInt(MORALE_KEY, Mathf.Clamp(PlayerPrefs.GetInt(MORALE_KEY, 100) + moraleChange, 1, 100));
        PlayerPrefs.SetInt(DEF_RATING_KEY, Mathf.Clamp(PlayerPrefs.GetInt(DEF_RATING_KEY, 70) + defenseChange, 1, 100));
        PlayerPrefs.SetInt(OFF_RATING_KEY, Mathf.Clamp(PlayerPrefs.GetInt(OFF_RATING_KEY, 70) + offenseChange, 1, 100));
        PlayerPrefs.SetInt(CONDITION_KEY, Mathf.Clamp(PlayerPrefs.GetInt(CONDITION_KEY, 100) + conditionChange, 1, 100));
        PlayerPrefs.SetInt(MONEY_KEY, PlayerPrefs.GetInt(MONEY_KEY, 1000) + moneyChange);

        // Optionally log the changes for debugging
        Debug.Log($"Morale: {PlayerPrefs.GetInt(MORALE_KEY)}, Defense: {PlayerPrefs.GetInt(DEF_RATING_KEY)}, Offense: {PlayerPrefs.GetInt(OFF_RATING_KEY)}, Condition: {PlayerPrefs.GetInt(CONDITION_KEY)}, Money: {PlayerPrefs.GetInt(MONEY_KEY)}");
    }
    bool IsGameOver()
    {
        // Check if any of the stats are below 1
        return PlayerPrefs.GetInt(MORALE_KEY) <= 0 || PlayerPrefs.GetInt(DEF_RATING_KEY) <= 0 || PlayerPrefs.GetInt(OFF_RATING_KEY) <= 0 || PlayerPrefs.GetInt(CONDITION_KEY) <= 0;
    }
}
