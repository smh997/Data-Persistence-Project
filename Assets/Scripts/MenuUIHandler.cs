using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField nameInputField;
    public TextMeshProUGUI bestScore;

    private void Start()
    {
        if (DataManager.Instance.bestScoresData.playerScore > 0)
        {
            nameInputField.text = DataManager.Instance.currentPlayer;
            bestScore.text = "Best Score: " + DataManager.Instance.bestScoresData.playerName + ": " + DataManager.Instance.bestScoresData.playerScore.ToString();
        }
        else
        {
            bestScore.text = "Best Score: Not Available!";
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetPlayerName()
    {
        DataManager.Instance.currentPlayer = nameInputField.text.Trim();
    }

}
