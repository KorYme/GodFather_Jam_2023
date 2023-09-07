using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BubbleManager : MonoBehaviour
{
    [SerializeField] RectTransform _rTransform;
    [SerializeField] GameObject _inputSignPrefab;
    [SerializeField] List<InputSign> _signs = new List<InputSign>();
    [SerializeField, Range(0f,5f)] float _stunTime;

    [SerializeField] UnityEvent _onStun; 

    Coroutine _stunCoroutine;

    private void Start()
    {
        ScoreManager.Instance.PlayNewRound();
        InitializeSigns();
        _onStun.AddListener(() => Debug.Log("Stun"));
    }

    public void ChangePlayer()
    {
        ScoreManager.Instance.ChangePlayer();
        InitializeSigns();
    }

    public void CheckAllSigns(string str)
    {
        if (_stunCoroutine != null) return;
        int originalChecked = _signs.Where(x => x.gameObject.activeSelf).Count();
        _signs.ForEach(x => x.CheckText(str));
        if (originalChecked == _signs.Where(x => x.gameObject.activeSelf).Count())
        {
            _stunCoroutine = StartCoroutine(StunCoroutine());
            _onStun?.Invoke();
            return;
        }
        if (_signs.TrueForAll(x => !x.gameObject.activeSelf))
        {
            InitializeSigns();
        }
    }

    public void InitializeSigns()
    {
        List<string> fullList = new List<string>(InputManager.CHARACTERS);
        for (int i = 0; i < ScoreManager.Instance.PictoPerBatch[ScoreManager.Instance.Round]; i++)
        {
            string text = fullList[Random.Range(0, fullList.Count)];
            _signs[i].Initialize(_rTransform, text);
            fullList.Remove(text);
        }
        for (int i = ScoreManager.Instance.PictoPerBatch[ScoreManager.Instance.Round]; i < _signs.Count; i++)
        {
            _signs[i].HideSign();
        }
    }

    IEnumerator StunCoroutine()
    {
        yield return new WaitForSeconds(_stunTime);
        _stunCoroutine = null;
    }

    public void HideAllSigns() => _signs.ForEach(x => x.HideSign());
}