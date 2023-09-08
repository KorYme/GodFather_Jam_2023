using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance.OnAnyCharacter += LoadSplash;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnAnyCharacter -= LoadSplash;
    }

    public void LoadSplash(string s)
    {
        SceneManager.LoadScene(0);
    }
}
