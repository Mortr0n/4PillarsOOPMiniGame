using System;
using System.IO;
using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }
    private string savePath => Application.persistentDataPath + "/savefile.json";
    [SerializeField] private SaveData saveData;
    public TextMeshProUGUI highScoreList;
    public TextMeshProUGUI nameText;
    public string inputName;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        saveData = LoadGame();
    }

    public SaveData LoadGame()
    {
        if (File.Exists(savePath))
        {
            try
            {
                string json = File.ReadAllText(savePath);
                SaveData data = JsonUtility.FromJson<SaveData>(json);
                Debug.Log($"Game loaded Successfully {saveData}");
                return data;
            }
            catch
            {
                Debug.LogError("Failed to load game. Returning default data.");
                saveData = new SaveData();
            }
        }
        else
        {
            Debug.LogWarning("Save file not found.  Returning default data.");
            saveData = new SaveData();
        }
        return saveData;
    }

    public void SaveGame(SaveData data)
    {
        try
        {
            saveData = data;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(savePath, json);
            Debug.Log($"Game saved successfully {saveData}");
        }
        catch (IOException e)
        {
            Debug.LogError($"Failed to save game {e.Message}");
        }
    }
    public void UpdateName()
    {
        TextMeshProUGUI nameUGUI = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
        inputName = nameUGUI.text;
    }

    public void SaveHighScore(HighScoreData data)
    {
        saveData = LoadGame();
        bool insertedAlready = false;

        saveData.highScores.SortHighScores();

        for (int i = 0; i < (saveData.highScores).Length; i++)
        {
            if (saveData.highScores[i] == null && !insertedAlready)
            {
                saveData.highScores[i] = new HighScoreData();
                saveData.highScores[i].Name = data.Name;
                saveData.highScores[i].Score = data.Score;
                insertedAlready = true;
                break;
            }
            else if (saveData.highScores[i].Score < data.Score && !insertedAlready)
            {

                for (int j = saveData.highScores.Length - 1; j > i; j--)
                {
                    if (saveData.highScores[j - 1] != null)
                    {
                        saveData.highScores[j] = new HighScoreData
                        {
                            Name = saveData.highScores[j - 1].Name,
                            Score = saveData.highScores[j - 1].Score
                        };
                    }
                    else
                    {
                        saveData.highScores[j] = null;
                    }
                }
                Debug.Log($"new High score adding {data.Name} and {data.Score}");
                saveData.highScores[i].Name = data.Name;
                saveData.highScores[i].Score = data.Score;
                insertedAlready = true;
                break;
            }
        }
        Debug.Log($"SaveData HighScores {saveData.highScores}");
        SaveGame(saveData);
    }


    public SaveData GetCurrentSaveData()
    {
        return saveData;
    }


    public void DisplayHighScores()
    {
        SaveData sData = SaveManager.Instance.GetCurrentSaveData();

        string highScoreString = "";
        foreach (HighScoreData hScores in sData.highScores)
        {
            if (hScores.Score != 0)
            {
                highScoreString += $"{hScores.Name}: {hScores.Score} \n";
            }
        }
        GameObject highScoreObject = GameObject.Find("HighScoreList");
        highScoreList = highScoreObject.GetComponent<TextMeshProUGUI>();
        Debug.Log($"High {highScoreList} and obj {highScoreObject} and {highScoreString}");
        highScoreList.text = highScoreString;
    }
}