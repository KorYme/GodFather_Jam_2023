using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BubbleManager : MonoBehaviour
{
    [SerializeField] RectTransform _rTransform;
    [SerializeField] GameObject _inputSignPrefab;
    [SerializeField] List<InputSign> _signs = new List<InputSign>();
    [SerializeField, Range(0f,5f)] float _stunTime;

    [SerializeField] UnityEvent _onStun; 
    [SerializeField] List<Sprite> _numbersSprite; 
    [SerializeField] Image _numberImage; 
    [SerializeField] float _timeRoundApperance; 

    Coroutine _stunCoroutine;

    private void OnEnable()
    {
        InputManager.Instance.OnAnyCharacter += CheckAllSigns;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnAnyCharacter -= CheckAllSigns;
    }

    private void Start()
    {
        _onStun.AddListener(() => AudioManager.Instance?.PlaySingleSound("Wronginput"));
        ScoreManager.Instance.PlayNewRound();
        StartCoroutine(WaitForNextPlayer());
    }

    public void ChangePlayer()
    {
        ScoreManager.Instance.ChangePlayer();
        StartCoroutine(WaitForNextPlayer());
    }

    IEnumerator WaitForNextPlayer()
    {
        TimerManager.Instance.PlayTimer(false);
        HideAllSigns();
        _numberImage.enabled = true;
        for (int i = 5; i > -1; i--)
        {
            _numberImage.sprite = _numbersSprite[i];
            yield return new WaitForSeconds(1f);
        }
        _numberImage.enabled = false;
        TimerManager.Instance.PlayTimer(true);
        InitializeSigns();
    }

    public void CheckAllSigns(string str)
    {
        if (_stunCoroutine != null) return;
        _signs.ForEach(x => { if (x == null) { _signs.Remove(x); } });
        int originalChecked = _signs.Where(x =>x.gameObject.activeSelf).Count();
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
        for (int i = 0; i < ScoreManager.Instance.PictoPerBatch[ScoreManager.Instance.Round-1]; i++)
        {
            string text = fullList[Random.Range(0, fullList.Count)];
            _signs[i].Initialize(_rTransform, text);
            fullList.Remove(text);
        }
        for (int i = ScoreManager.Instance.PictoPerBatch[ScoreManager.Instance.Round-1]; i < _signs.Count; i++)
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