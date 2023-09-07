using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionScript : MonoBehaviour
{
    private GameObject reactionObj;
    private Image reactionImg;

    void Start()
    {
        reactionObj = GameObject.Find("/Canvas/WTF");
        reactionImg = reactionObj.GetComponent<Image>();
        reactionObj.transform.localScale = new Vector2(0, 0);
    }

    public IEnumerator DisplayReaction()
    {
        reactionObj.transform.localScale = new Vector2(0, 0);
        reactionImg.color = new Color(1f, 1f, 1f, 1f);
        float lerp = 0;

        while (lerp < 1)
        {
            lerp += Time.deltaTime / .2f;
            reactionObj.transform.localScale = Vector2.Lerp(new Vector2(0f, 0f), new Vector2(1.5f, 1.5f), lerp);
            yield return null;
        }

        lerp = 0;

        while (lerp < 1)
        {
            lerp += Time.deltaTime / .05f;
            reactionObj.transform.localScale = Vector2.Lerp(new Vector2(1.5f, 1.5f), new Vector2(1f, 1f), lerp);
            yield return null;
        }

        lerp = 0;

        while (lerp < 1)
        {
            lerp += Time.deltaTime / .05f;
            reactionObj.transform.localScale = Vector2.Lerp(new Vector2(1f, 1f), new Vector2(1.5f, 1.5f), lerp);
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
}
