using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public int scoreP1;
    public int scoreP2;
    public int punchlineScoreNeeded;
    public float timeBetweenPunchline;
    public float durationOfThePunchline;

    private GameObject bubbleRight;
    private GameObject bubbleLeft;
    private GameObject crowd;
    private ReactionScript reactionScript;

    private bool P1NoMorePunchline;
    private bool P2NoMorePunchline;

    private void Awake()
    {
        bubbleRight = GameObject.Find("/Canvas/BubbleRight");
        bubbleLeft = GameObject.Find("/Canvas/BubbleLeft");
        crowd = GameObject.Find("/Crowd");
        reactionScript = gameObject.GetComponent<ReactionScript>();
    }

    void Start()
    {
        bubbleRight.SetActive(false);
        bubbleLeft.SetActive(false);
        StartCoroutine(P1Punchline());
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
        if(scoreP1 >= punchlineScoreNeeded)
        {
            scoreP1 -= punchlineScoreNeeded;
            bubbleLeft.SetActive(true);
            yield return new WaitForSeconds(durationOfThePunchline);
            bubbleLeft.SetActive(false);
            StartCoroutine(CrowdJump());
            StartCoroutine(reactionScript.DisplayReaction());
            yield return new WaitForSeconds(timeBetweenPunchline);
        }
        else
        {
            //Jouer une animation d'h�sitation / d��u
            P1NoMorePunchline = true;
            yield return null;
        }
        StartCoroutine(P2Punchline());
    }

    public IEnumerator P2Punchline()
    {
        if (scoreP2 >= punchlineScoreNeeded)
        {
            scoreP2 -= punchlineScoreNeeded;
            bubbleRight.SetActive(true);
            yield return new WaitForSeconds(durationOfThePunchline);
            bubbleRight.SetActive(false);
            StartCoroutine(CrowdJump());
            StartCoroutine(reactionScript.DisplayReaction());
            yield return new WaitForSeconds(timeBetweenPunchline);
        }
        else
        {
            //Jouer une animation d'h�sitation / d��u
            P2NoMorePunchline = true;
            yield return null;
        }
        StartCoroutine(P1Punchline());
    }

    private IEnumerator CrowdJump()
    {
        Vector2 originalPos = new Vector2(crowd.transform.position.x, crowd.transform.position.y);
        Vector2 targetedPos = new Vector2(crowd.transform.position.x, crowd.transform.position.y + 1);

        float lerp = 0;

        while (lerp < 1)
        {
            lerp += Time.deltaTime / .2f;
            crowd.transform.position = Vector2.Lerp(originalPos, targetedPos, lerp);

            yield return null;
        }

        lerp = 0;

        while (lerp < 1)
        {
            lerp += Time.deltaTime / .2f;
            crowd.transform.position = Vector2.Lerp(targetedPos, originalPos, lerp);

            yield return null;
        }
    }
}
