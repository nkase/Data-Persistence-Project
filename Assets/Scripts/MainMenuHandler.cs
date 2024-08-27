using System.Collections;
using System.Collections.Generic;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject inputField;

    public void StartGame()
    {
        // get player name, save to save data handler
        SaveDataHandler.Instance.playerName = inputField.GetComponent<TMP_InputField>().text;

        // pass to main game scene
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        // quit to desktop/exit play mode
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void ClearSaveDataButton()
    {
        SaveDataHandler.Instance.ClearSaveData();
    }
}
