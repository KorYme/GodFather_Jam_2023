using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    [SerializeField] RectTransform _rTransform;
    [SerializeField] GameObject _inputSignPrefab;
    [SerializeField] List<int> _inputSignNumberPerRound;

    List<InputSign> _signs = new List<InputSign>();
    int _roundNumber;

    private void Start()
    {
        _signs.Clear();
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
            Vector3 newposition = _rTransform.transform.position 
                + new Vector3(_rTransform.rect.width * Random.Range(-.5f,.5f), _rTransform.rect.height * Random.Range(-.5f, .5f));
            InputSign newSign = Instantiate(_inputSignPrefab, newposition, Quaternion.identity, transform).GetComponent<InputSign>();
            _signs.Add(newSign);
            newSign.Initialize(_rTransform.rect, text);
            fullList.Remove(text);
        }
    }

    public void HideAllSigns() => _signs.ForEach(x => x.HideSign());
}