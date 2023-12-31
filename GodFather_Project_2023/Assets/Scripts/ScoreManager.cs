using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int CurrentPlayer { get; private set; }

    public static ScoreManager Instance;
    public UnityEvent<int> PlayerChange;

    public int Round { get; private set; }
    public List<int> PictoPerBatch;
    public List<Queue<string>> PlayersPictoQueue;
    public Queue<string> CurrentPlayerQueue
    {
        get => PlayersPictoQueue[CurrentPlayer];
    }
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
        Round = 0;
        CurrentPlayer = 0;
        PlayersPictoQueue = new();
        PlayersPictoQueue.Add(new());
        PlayersPictoQueue.Add(new());
    }

    public void PlayNewRound()
    {
        Round = Mathf.Clamp(Round + 1, 0, PictoPerBatch.Count);
        PlayersPictoQueue[0].Clear();
        PlayersPictoQueue[1].Clear();
    }

    public void ChangePlayer()
    {
        CurrentPlayer = (CurrentPlayer + 1)%2;
        PlayerChange?.Invoke(CurrentPlayer);
    }

    public void CheckEndRound()
    {
        if (CurrentPlayer == 0 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
}
