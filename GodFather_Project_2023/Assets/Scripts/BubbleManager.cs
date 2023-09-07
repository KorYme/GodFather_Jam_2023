using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    [SerializeField] RectTransform _rTransform;
    [SerializeField] GameObject _inputSignPrefab;
    [SerializeField] List<int> _inputSignNumberPerRound;
    [SerializeField] List<InputSign> _signs = new List<InputSign>();
    int _roundNumber;

    private void Start()
    {
        _roundNumber = 0;
        InitializeSigns();
    }

    public void CheckAllSigns(string str)
    {
        _signs.ForEach(x => x.CheckText(str));
        if (_signs.TrueForAll(x => !x.gameObject.activeSelf))
        {
            InitializeSigns();
        }
    }

    public void InitializeSigns()
    {
        List<string> fullList = new List<string>(InputManager.CHARACTERS);
        for (int i = 0; i < _inputSignNumberPerRound[_roundNumber]; i++)
        {
            string text = fullList[Random.Range(0, fullList.Count)];
            _signs[i].Initialize(_rTransform, text);
            fullList.Remove(text);
        }
        for (int i = _inputSignNumberPerRound[_roundNumber]; i < _signs.Count; i++)
        {
            _signs[i].HideSign();
        }
    }

    public void HideAllSigns() => _signs.ForEach(x => x.HideSign());
}