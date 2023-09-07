using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int CurrentPlayer { get; private set; }

    public static ScoreManager Instance;

    public int Round { get; private set; }
    public List<int> PictoPerBatch;
    public List<Queue<string>> PlayersPictoQueue;
    public Queue<string> CurrentPlayerQueue => PlayersPictoQueue[CurrentPlayer];
    

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
    }
}
