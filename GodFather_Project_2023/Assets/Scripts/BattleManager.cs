using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void Awake()
    {
        reactionScript = gameObject.GetComponent<ReactionScript>();
    }

    void Start()
    {
        bubble.gameObject.SetActive(false);
        ScoreManager.Instance.ChooseWinner();
        StartCoroutine(PunchlineCoroutine());
    }

    public IEnumerator PunchlineCoroutine()
    {
        int pictoBatch = ScoreManager.Instance.PictoPerBatch[ScoreManager.Instance.Round];
        if (ScoreManager.Instance.CurrentPlayerQueue.Count == 0)
        {
            ScoreManager.Instance.ChangePlayer();
        }
        while (ScoreManager.Instance.CurrentPlayerQueue.Count > 0)
        {
            List<string> list = new List<string>();
            int maxValue = ScoreManager.Instance.CurrentPlayerQueue.Count;
            for (int i = 0; i < Mathf.Clamp(pictoBatch, 1, maxValue); i++)
            {
                list.Add(ScoreManager.Instance.CurrentPlayerQueue.Dequeue());
            }
            for (int i = 0; i < 12; i++)
            {
                _allImages[i].enabled = false;
            }
            bubble.sprite = _bubbleSprites[ScoreManager.Instance.CurrentPlayer];
            bubble.gameObject.SetActive(true);
            for (int i = 0; i < list.Count; i++)
            {
                _allImages[i].enabled = true;
                _allImages[i].sprite = _mapping.Values[_mapping.Keys.FindIndex(x => x.ToLower() == list[i].ToLower())];
                //Lancement son
                yield return new WaitForSeconds(.5f);
            }
            yield return new WaitForSeconds(durationOfThePunchline);
            bubble.gameObject.SetActive(false);
            reactionScript.AllCrowdEffects();
            if (ScoreManager.Instance.PlayersPictoQueue[(ScoreManager.Instance.CurrentPlayer + 1) % 2].Count > 0)
            {
                ScoreManager.Instance.ChangePlayer();
            }
        }
        yield return new WaitForSeconds(1f);
        if (ScoreManager.Instance.Round == 3 && ScoreManager.Instance.Winner != 1)
        {
            //AFFICHAGE VICTOIRE
            Debug.Log("Le gagnant est le joueur " +  (ScoreManager.Instance.Winner+1));
        }
        else
        {
            SceneManager.LoadScene("Proto1");
        }
    }
}
