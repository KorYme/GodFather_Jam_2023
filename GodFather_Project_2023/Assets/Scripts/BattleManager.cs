using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public float timeBetweenPunchline;
    public float durationOfThePunchline;

    private ReactionScript reactionScript;
    [SerializeField] MappingDictionnarySO _mapping;
    [SerializeField] List<Image> _allImages;
    [SerializeField] List<Sprite> _bubbleSprites;
    [SerializeField] Image bubble;
    public int Winner { get; private set; }

    private void Awake()
    {
        reactionScript = gameObject.GetComponent<ReactionScript>();
    }

    void Start()
    {
        Winner = -1;
        bubble.gameObject.SetActive(false);
        StartCoroutine(PunchlineCoroutine());
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
        Winner = ScoreManager.Instance.CurrentPlayer;
        yield return null;
    }
}
