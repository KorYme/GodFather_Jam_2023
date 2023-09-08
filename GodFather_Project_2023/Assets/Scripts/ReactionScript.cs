using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionScript : MonoBehaviour
{
    private GameObject reactionObj;
    private GameObject frontCrowd;
    private GameObject backCrowd;
    private Image reactionImg;

    public Sprite[] reactionList;

    void Start()
    {
        backCrowd = GameObject.Find("/Canvas/BackCrowd");
        frontCrowd = GameObject.Find("/Canvas/FrontCrowd");
        reactionObj = GameObject.Find("/Canvas/CrowdReaction");
        reactionImg = reactionObj.GetComponent<Image>();
        reactionObj.transform.localScale = new Vector2(0, 0);
        AllCrowdEffects();
    }

    public IEnumerator DisplayReaction()
    {
        reactionImg.sprite = reactionList[Random.Range(0,3)];
        reactionImg.SetNativeSize();
        reactionObj.transform.position = new Vector2(Random.Range(-6.8f, 6.8f), Random.Range(-3.6f, -2f));
        reactionObj.transform.localScale = new Vector2(0, 0);
        reactionImg.color = new Color(1f, 1f, 1f, 1f);
        float lerp = 0;

        while (lerp < 1)
        {
            lerp += Time.deltaTime / .2f;
            reactionObj.transform.localScale = Vector2.Lerp(new Vector2(0f, 0f), new Vector2(0.75f, 0.75f), lerp);
            yield return null;
        }

        lerp = 0;

        while (lerp < 1)
        {
            lerp += Time.deltaTime / .05f;
            reactionObj.transform.localScale = Vector2.Lerp(new Vector2(0.75f, 0.75f), new Vector2(0.5f, 0.5f), lerp);
            yield return null;
        }

        lerp = 0;

        while (lerp < 1)
        {
            lerp += Time.deltaTime / .05f;
            reactionObj.transform.localScale = Vector2.Lerp(new Vector2(0.5f, 0.5f), new Vector2(0.75f, 0.75f), lerp);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        lerp = 0;

        while (lerp < 1)
        {
            lerp += Time.deltaTime / .2f;
            reactionImg.color = Color.Lerp(reactionImg.color, new Color(0f, 0f, 0f, 0f), lerp);
            reactionObj.transform.localScale = Vector2.Lerp(new Vector2(1f, 1f), new Vector2(0f, 0f), lerp);
            yield return null;
        }
    }

    public IEnumerator CrowdJump(GameObject crowd)
    {
        if (crowd.name == "BackCrowd")
        {
            yield return new WaitForSeconds(0.2f);
        }

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

    public void AllCrowdEffects()
    {
        StartCoroutine(DisplayReaction());
        StartCoroutine(CrowdJump(frontCrowd));
        StartCoroutine(CrowdJump(backCrowd));
    }
}
