using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_InputField nameInput;
    public string namePlayer;
    public Button startBtn;
    public TMP_Text bestScoreText;
    public int highScore;
    public string highScoreName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance =  this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        LoadHighScore();
        bestScoreText.text = "Best Score : " + $"{highScoreName} : {highScore}";
    }
    public void SetName()
    {
        namePlayer = nameInput.text;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }

}

[System.Serializable]
public class SaveData
{
    public int highScore;
    public string highScoreName;
}
