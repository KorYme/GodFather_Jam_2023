using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputSign : MonoBehaviour
{
    [SerializeField] RectTransform _rTransform;
    [SerializeField] TMP_Text _text;
    [SerializeField] SignMovement _signMovement;

    Rect _boxToStayInside;
    Vector2 _direction;

    public void Initialize(Rect rectBubble, string text)
    {
        _boxToStayInside = rectBubble;
        _text.text = text;
        StartCoroutine(ChangeDirectionCoroutine());
        StartCoroutine(MovementCoroutine());
    }

    public void CheckText(string text)
    {
        if (!gameObject.activeSelf) return;
        if (text == _text.text)
        {
            gameObject.SetActive(false);
            _text.text = "";
        }
    }

    public void HideSign()
    {
        if (!gameObject.activeSelf) return;
        gameObject.SetActive(false);
        _text.text = "";
    }

    IEnumerator MovementCoroutine()
    {
        //Debug.Log(_rTransform.transform.position);
        while (true)
        {
            yield return null;
        }
    }

    IEnumerator ChangeDirectionCoroutine()
    {
        while (true)
        {
            _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f,1f)).normalized;
            yield return new WaitForSeconds(Random.Range(0f, _signMovement.ChangeDirectiontimer));
        }
    }
}
