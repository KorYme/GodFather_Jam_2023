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

    public List<int> PlayerScores;

    public int Winner 
    { 
        get
        {
            if (PlayerScores[0] == PlayerScores[1])
            {
                return -1;
            }
            else if (PlayerScores[0] > PlayerScores[1])
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
        ResetGame();
    }

    public void ResetGame()
    {
        Round = 0;
        CurrentPlayer = 0;
        PlayersPictoQueue = new();
        PlayersPictoQueue.Add(new());
        PlayersPictoQueue.Add(new());
        PlayerScores = new List<int>() {0, 0};
    }

    public void PlayNewRound()
    {
        Round = Mathf.Clamp(Round + 1, 0, 3);
        Debug.Log(Round + " " +  Mathf.Clamp(Round + 1, 0, 3));
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

    public void ChooseWinner()
    {
        if (PlayersPictoQueue[0].Count > PlayersPictoQueue[1].Count)
        {
            PlayerScores[0]++;

        }
        else if (PlayersPictoQueue[0].Count < PlayersPictoQueue[1].Count)
        {
            PlayerScores[1]++;
        }
    }
}
