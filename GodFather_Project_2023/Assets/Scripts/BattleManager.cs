using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public int scoreP1;
    public int scoreP2;
    public int punchlineScoreNeeded;
    public int timeBetweenPunchline;
    public int durationOfThePunchline;

    private GameObject bubbleRight;
    private GameObject bubbleLeft;
    private GameObject crowd;

    private bool P1NoMorePunchline;
    private bool P2NoMorePunchline;

    private void Awake()
    {
        bubbleRight = GameObject.Find("/Canvas/BubbleRight");
        bubbleLeft = GameObject.Find("/Canvas/BubbleLeft");
        crowd = GameObject.Find("/Canvas/Crowd");
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

    public IEnumerator P2Punchline()
    {
        if (scoreP2 >= punchlineScoreNeeded)
        {
            scoreP2 -= punchlineScoreNeeded;
            bubbleRight.SetActive(true);
            yield return new WaitForSeconds(durationOfThePunchline);
            bubbleRight.SetActive(false);
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
