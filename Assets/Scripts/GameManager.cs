using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    private SaveData saveData;
    private TextMeshProUGUI scoreText;
    [SerializeField] private string hScoreName;

    private int _score;
    public int Score
    { 
        get { return _score; }
        set { _score = value; }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //TEMPORARY!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    void Start()
    {
        StartGame();
        hScoreName = SaveManager.Instance.inputName;
    }

    public void StartGame()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        ResetScore();
        UpdateScoreText(Score);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void UpdateScoreText(int score)
    {
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        //Debug.Log($"Updating Score text with {Score} and scoretext is {scoreText}");
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }

    //public void UpdateName()
    //{
    //    hScoreName = GameObject.Find("NameInput").GetComponent<TextMeshProUGUI>().text;
    //}

    public void LoseGame()
    {
        SaveHighScore();
        GoToMenu();
    }

    public void SaveHighScore()
    {
        HighScoreData highScoreData = new HighScoreData();
        highScoreData.Name = hScoreName;  //TODO: what have I done??? lols
        highScoreData.Score = Score;
        SaveManager.Instance.SaveHighScore(highScoreData);
    }
}
