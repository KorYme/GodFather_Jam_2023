using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCharacters : MonoBehaviour
{
    [SerializeField] Image _sprite;
    [SerializeField] bool isAliTurn;

    private void Start()
    {
        DisplayOrNot(ScoreManager.Instance.CurrentPlayer);
        ScoreManager.Instance.PlayerChange.AddListener(DisplayOrNot);
    }

    private void DisplayOrNot(int currentPlayer)
    {
        _sprite.enabled = Convert.ToInt32(isAliTurn) != currentPlayer;
    }
}
