using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class BattleManager : MonoBehaviour
{
    public int scoreP1;
    public int scoreP2;
    public int punchlineScoreNeeded;
    public float timeBetweenPunchline;
    public float durationOfThePunchline;

    private ReactionScript reactionScript;
    [SerializeField] MappingDictionnarySO _mapping;
    [SerializeField] List<UnityEngine.UI.Image> _allImages;
    [SerializeField] List<Sprite> _bubbleSprites;
    [SerializeField] UnityEngine.UI.Image bubble;

    private bool P1NoMorePunchline;
    private bool P2NoMorePunchline;

    private void Awake()
    {
        reactionScript = gameObject.GetComponent<ReactionScript>();
    }

    void Start()
    {
        bubble.gameObject.SetActive(false);
        StartCoroutine(PunchlineCoroutine());
    }

    void Update()
    {
        if(P1NoMorePunchline && P2NoMorePunchline == true)
        {
            StopAllCoroutines();
            Debug.Log("Finished!");
        }
    }

    public IEnumerator P1Punchline()
    {
        int pictoBatch = ScoreManager.Instance.PictoPerBatch[ScoreManager.Instance.Round];
        if (ScoreManager.Instance.CurrentPlayerQueue.Count >= pictoBatch)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < pictoBatch; i++)
            {
                list.Add(ScoreManager.Instance.CurrentPlayerQueue.Dequeue());
            }
            for (int i = 0; i < list.Count; i++)
            {
                _allImages[i].enabled = true;
                _allImages[i].sprite = _mapping.Values[_mapping.Keys.FindIndex(x => x.ToLower() == list[i].ToLower())];
            }
            for (int i = list.Count; i < 12; i++)
            {
                _allImages[i].enabled = false;
            }
            //bubble.SetActive(true);
            yield return new WaitForSeconds(durationOfThePunchline);
            //bubble.SetActive(false);
            reactionScript.AllCrowdEffects();
            yield return new WaitForSeconds(timeBetweenPunchline);
        }
        else
        {
            //Jouer une animation d'hésitation / déçu
            P1NoMorePunchline = true;
            yield return null;
        }
        StartCoroutine(P2Punchline());
    }

    public IEnumerator PunchlineCoroutine()
    {
        int pictoBatch = ScoreManager.Instance.PictoPerBatch[ScoreManager.Instance.Round];
        while (ScoreManager.Instance.CurrentPlayerQueue.Count >= pictoBatch)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < pictoBatch; i++)
            {
                list.Add(ScoreManager.Instance.CurrentPlayerQueue.Dequeue());
            }
            for (int i = 0; i < list.Count; i++)
            {
                _allImages[i].enabled = true;
                _allImages[i].sprite = _mapping.Values[_mapping.Keys.FindIndex(x => x.ToLower() == list[i].ToLower())];
            }
            for (int i = list.Count; i < 12; i++)
            {
                _allImages[i].enabled = false;
            }
            bubble.gameObject.SetActive(true);
            bubble.sprite = _bubbleSprites[ScoreManager.Instance.CurrentPlayer];
            yield return new WaitForSeconds(durationOfThePunchline);
            bubble.gameObject.SetActive(false);
            reactionScript.AllCrowdEffects();
            yield return new WaitForSeconds(timeBetweenPunchline);
            ScoreManager.Instance.ChangePlayer();
        }
        ScoreManager.Instance.ChangePlayer();
        if (ScoreManager.Instance.CurrentPlayerQueue.Count < pictoBatch)
        {
            Debug.Log("DRAW");
        }
        while (ScoreManager.Instance.CurrentPlayerQueue.Count >= pictoBatch)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < pictoBatch; i++)
            {
                list.Add(ScoreManager.Instance.CurrentPlayerQueue.Dequeue());
            }
            for (int i = 0; i < list.Count; i++)
            {
                _allImages[i].enabled = true;
                _allImages[i].sprite = _mapping.Values[_mapping.Keys.FindIndex(x => x.ToLower() == list[i].ToLower())];
            }
            for (int i = list.Count; i < 12; i++)
            {
                _allImages[i].enabled = false;
            }
            bubble.gameObject.SetActive(true);
            bubble.sprite = _bubbleSprites[ScoreManager.Instance.CurrentPlayer];
            yield return new WaitForSeconds(durationOfThePunchline);
            bubble.gameObject.SetActive(false);
            reactionScript.AllCrowdEffects();
            yield return new WaitForSeconds(timeBetweenPunchline);
        }
        //Jouer une animation d'hésitation / déçu
        if (ScoreManager.Instance.CurrentPlayer == 0)
        {
            //Victoir joueur 1
        }
        else
        {
            //Victoir joueur 2
        }
        P1NoMorePunchline = true;
        yield return null;
    }

    public IEnumerator P2Punchline()
    {
        if (scoreP2 >= punchlineScoreNeeded)
        {
            scoreP2 -= punchlineScoreNeeded;
            //bubble.SetActive(true);
            yield return new WaitForSeconds(durationOfThePunchline);
            //bubble.SetActive(false);
            reactionScript.AllCrowdEffects();
            yield return new WaitForSeconds(timeBetweenPunchline);
        }
        else
        {
            //Jouer une animation d'hésitation / déçu
            P2NoMorePunchline = true;
            yield return null;
        }
        StartCoroutine(P1Punchline());
    }
}
