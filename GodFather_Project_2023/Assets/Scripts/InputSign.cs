using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputSign : MonoBehaviour
{
    [SerializeField] RectTransform _rTransform;
    [SerializeField] TMP_Text _text;
    [SerializeField] SignMovement _signMovement;

    Coroutine _movementCoroutine;
    Coroutine _directionCoroutine;

    RectTransform _rectTransformBubble;
    Vector2 _direction;
    AnimationCurve _currentCurve;
    float _deltaTime;

    public void Initialize(RectTransform rectBubble, string text)
    {
        gameObject.SetActive(true);
        Rect boxToStayInside = new Rect(rectBubble.rect.min + new Vector2(_rTransform.rect.size.x/2f, _rTransform.rect.size.y/-2f), 
            rectBubble.rect.size - _rTransform.rect.size);
        _text.text = text;
        _rectTransformBubble = rectBubble;
        transform.position = rectBubble.transform.position + new Vector3(
                    Mathf.Clamp(rectBubble.rect.width * Random.Range(-.5f, .5f), boxToStayInside.min.x, boxToStayInside.max.x),
                    Mathf.Clamp(rectBubble.rect.height * Random.Range(-.5f, .5f), boxToStayInside.min.y, boxToStayInside.max.y));
        _directionCoroutine = StartCoroutine(ChangeDirectionCoroutine());
        _movementCoroutine = StartCoroutine(MovementCoroutine());
    }

    public void CheckText(string text)
    {
        if (!gameObject.activeSelf) return;
        if (text == _text.text)
        {
            StopCoroutine(_directionCoroutine);
            StopCoroutine(_movementCoroutine);
            _text.text = "";
            gameObject.SetActive(false);
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
        while (true)
        {
            Vector3 newPosition = transform.position + (Vector3)_direction 
                * _signMovement.MaxSpeed * _currentCurve.Evaluate(_deltaTime) * Time.deltaTime;
            transform.position = new Vector3(
                Mathf.Clamp(newPosition.x,
                _rectTransformBubble.transform.position.x - (_rectTransformBubble.rect.width / 2f) + (_rTransform.rect.width / 2f),
                _rectTransformBubble.transform.position.x + (_rectTransformBubble.rect.width / 2f) - (_rTransform.rect.width / 2f)),
                Mathf.Clamp(newPosition.y,
                _rectTransformBubble.transform.position.y - (_rectTransformBubble.rect.height / 2f) + (_rTransform.rect.height / 2f),
                _rectTransformBubble.transform.position.y + (_rectTransformBubble.rect.height / 2f) - (_rTransform.rect.height / 2f)));
            _deltaTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator ChangeDirectionCoroutine()
    {
        while (true)
        {
            _deltaTime = 0;
            _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f,1f)).normalized;
            _currentCurve = _signMovement.AllMovementCurves[Random.Range(0, _signMovement.AllMovementCurves.Count)];
            yield return new WaitForSeconds(Random.Range(_signMovement.ChangeDirectiontimer.x, _signMovement.ChangeDirectiontimer.y));
        }
    }
}
