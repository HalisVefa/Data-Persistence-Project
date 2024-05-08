using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField enterName;
    public Text BestScore;
    private string nameInput;

    void Start(){
        enterName.text = DataManager.Instance.PlayerName;
        BestScore.text = "Best Score : " + DataManager.Instance.BestPlayerName + " : " + DataManager.Instance.BestScore;
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        DataManager.Instance.SavePlayerName(); 

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); 
        #endif
    }
    
    public void assignName() {
        nameInput = enterName.text;
        DataManager.Instance.PlayerName = nameInput;
    }
}
