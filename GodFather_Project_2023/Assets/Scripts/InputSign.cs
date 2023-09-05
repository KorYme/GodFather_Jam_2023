using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputSign : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    public void SetText(string text)
    {
        _text.text = text;
        gameObject.SetActive(true);
    }

    public void CheckText(string text)
    {
        if (!gameObject.activeSelf) return;
        if (text == _text.text)
        {
            gameObject.SetActive(false);
        }
    }
}
