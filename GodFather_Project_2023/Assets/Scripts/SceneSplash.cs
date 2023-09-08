using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSplash : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance.OnAnyCharacter += LoadProto1;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnAnyCharacter -= LoadProto1;
    }

    public void LoadProto1(string s)
    {
        ScoreManager.Instance.ResetGame();
        SceneManager.LoadScene("Proto1");
    }
}
