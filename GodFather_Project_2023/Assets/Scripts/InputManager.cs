using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static readonly List<string> CHARACTERS = new List<string>(new[]
    {
        "A",
        "Z",
        "E",
        "R",
        "T",
        "Y",
        "U",
        "I",
        "Q",
        "S",
        "F",
        "G",
        "H",
        "J",
        "K",
        "W",
        "X",
        "C",
        "V",
        "B",
        "N",
        ",",
        ";",
    });


    Inputs _inputAction;
    public Action<string> OnAnyCharacter;
    public static InputManager Instance;

    [SerializeField] bool _isOnArcade;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        _inputAction = new Inputs();
        _inputAction.Keyboard.Enable();
        _inputAction.Qwerty.Enable();
    }

    private void OnEnable()
    {
        if (_isOnArcade)
        {
            _inputAction.Qwerty.A.started += (x) => GetCharacterFromInput("a");
            _inputAction.Qwerty.Z.started += (x) => GetCharacterFromInput("z");
            _inputAction.Qwerty.E.started += (x) => GetCharacterFromInput("e");
            _inputAction.Qwerty.R.started += (x) => GetCharacterFromInput("r");
            _inputAction.Qwerty.T.started += (x) => GetCharacterFromInput("t");
            _inputAction.Qwerty.Y.started += (x) => GetCharacterFromInput("y");
            _inputAction.Qwerty.U.started += (x) => GetCharacterFromInput("u");
            _inputAction.Qwerty.I.started += (x) => GetCharacterFromInput("i");
            _inputAction.Qwerty.Q.started += (x) => GetCharacterFromInput("q");
            _inputAction.Qwerty.S.started += (x) => GetCharacterFromInput("s");
            _inputAction.Qwerty.D.started += (x) => GetCharacterFromInput("d");
            _inputAction.Qwerty.F.started += (x) => GetCharacterFromInput("f");
            _inputAction.Qwerty.G.started += (x) => GetCharacterFromInput("g");
            _inputAction.Qwerty.H.started += (x) => GetCharacterFromInput("h");
            _inputAction.Qwerty.J.started += (x) => GetCharacterFromInput("j");
            _inputAction.Qwerty.K.started += (x) => GetCharacterFromInput("k");
            _inputAction.Qwerty.W.started += (x) => GetCharacterFromInput("w");
            _inputAction.Qwerty.X.started += (x) => GetCharacterFromInput("x");
            _inputAction.Qwerty.C.started += (x) => GetCharacterFromInput("c");
            _inputAction.Qwerty.V.started += (x) => GetCharacterFromInput("v");
            _inputAction.Qwerty.B.started += (x) => GetCharacterFromInput("b");
            _inputAction.Qwerty.N.started += (x) => GetCharacterFromInput("n");
            _inputAction.Qwerty.O.started += (x) => GetCharacterFromInput(",");
            _inputAction.Qwerty.P.started += (x) => GetCharacterFromInput(";");
        }
        else
        {
            _inputAction.Keyboard.A.started += (x) => GetCharacterFromInput("a");
            _inputAction.Keyboard.Z.started += (x) => GetCharacterFromInput("z");
            _inputAction.Keyboard.E.started += (x) => GetCharacterFromInput("e");
            _inputAction.Keyboard.R.started += (x) => GetCharacterFromInput("r");
            _inputAction.Keyboard.T.started += (x) => GetCharacterFromInput("t");
            _inputAction.Keyboard.Y.started += (x) => GetCharacterFromInput("y");
            _inputAction.Keyboard.U.started += (x) => GetCharacterFromInput("u");
            _inputAction.Keyboard.I.started += (x) => GetCharacterFromInput("i");
            _inputAction.Keyboard.Q.started += (x) => GetCharacterFromInput("q");
            _inputAction.Keyboard.S.started += (x) => GetCharacterFromInput("s");
            _inputAction.Keyboard.D.started += (x) => GetCharacterFromInput("d");
            _inputAction.Keyboard.F.started += (x) => GetCharacterFromInput("f");
            _inputAction.Keyboard.G.started += (x) => GetCharacterFromInput("g");
            _inputAction.Keyboard.H.started += (x) => GetCharacterFromInput("h");
            _inputAction.Keyboard.J.started += (x) => GetCharacterFromInput("j");
            _inputAction.Keyboard.K.started += (x) => GetCharacterFromInput("k");
            _inputAction.Keyboard.W.started += (x) => GetCharacterFromInput("w");
            _inputAction.Keyboard.X.started += (x) => GetCharacterFromInput("x");
            _inputAction.Keyboard.C.started += (x) => GetCharacterFromInput("c");
            _inputAction.Keyboard.V.started += (x) => GetCharacterFromInput("v");
            _inputAction.Keyboard.B.started += (x) => GetCharacterFromInput("b");
            _inputAction.Keyboard.N.started += (x) => GetCharacterFromInput("n");
            _inputAction.Keyboard.O.started += (x) => GetCharacterFromInput(",");
            _inputAction.Keyboard.P.started += (x) => GetCharacterFromInput(";");
        }
    }

    private void OnDisable()
    {
        if (_isOnArcade)
        {
            _inputAction.Qwerty.A.started -= (x) => GetCharacterFromInput("a");
            _inputAction.Qwerty.Z.started -= (x) => GetCharacterFromInput("z");
            _inputAction.Qwerty.E.started -= (x) => GetCharacterFromInput("e");
            _inputAction.Qwerty.R.started -= (x) => GetCharacterFromInput("r");
            _inputAction.Qwerty.T.started -= (x) => GetCharacterFromInput("t");
            _inputAction.Qwerty.Y.started -= (x) => GetCharacterFromInput("y");
            _inputAction.Qwerty.U.started -= (x) => GetCharacterFromInput("u");
            _inputAction.Qwerty.I.started -= (x) => GetCharacterFromInput("i");
            _inputAction.Qwerty.Q.started -= (x) => GetCharacterFromInput("q");
            _inputAction.Qwerty.S.started -= (x) => GetCharacterFromInput("s");
            _inputAction.Qwerty.D.started -= (x) => GetCharacterFromInput("d");
            _inputAction.Qwerty.F.started -= (x) => GetCharacterFromInput("f");
            _inputAction.Qwerty.G.started -= (x) => GetCharacterFromInput("g");
            _inputAction.Qwerty.H.started -= (x) => GetCharacterFromInput("h");
            _inputAction.Qwerty.J.started -= (x) => GetCharacterFromInput("j");
            _inputAction.Qwerty.K.started -= (x) => GetCharacterFromInput("k");
            _inputAction.Qwerty.W.started -= (x) => GetCharacterFromInput("w");
            _inputAction.Qwerty.X.started -= (x) => GetCharacterFromInput("x");
            _inputAction.Qwerty.C.started -= (x) => GetCharacterFromInput("c");
            _inputAction.Qwerty.V.started -= (x) => GetCharacterFromInput("v");
            _inputAction.Qwerty.B.started -= (x) => GetCharacterFromInput("b");
            _inputAction.Qwerty.N.started -= (x) => GetCharacterFromInput("n");
            _inputAction.Qwerty.O.started -= (x) => GetCharacterFromInput(",");
            _inputAction.Qwerty.P.started -= (x) => GetCharacterFromInput(";");
        }
        else
        {
            _inputAction.Keyboard.A.started -= (x) => GetCharacterFromInput("a");
            _inputAction.Keyboard.Z.started -= (x) => GetCharacterFromInput("z");
            _inputAction.Keyboard.E.started -= (x) => GetCharacterFromInput("e");
            _inputAction.Keyboard.R.started -= (x) => GetCharacterFromInput("r");
            _inputAction.Keyboard.T.started -= (x) => GetCharacterFromInput("t");
            _inputAction.Keyboard.Y.started -= (x) => GetCharacterFromInput("y");
            _inputAction.Keyboard.U.started -= (x) => GetCharacterFromInput("u");
            _inputAction.Keyboard.I.started -= (x) => GetCharacterFromInput("i");
            _inputAction.Keyboard.Q.started -= (x) => GetCharacterFromInput("q");
            _inputAction.Keyboard.S.started -= (x) => GetCharacterFromInput("s");
            _inputAction.Keyboard.D.started -= (x) => GetCharacterFromInput("d");
            _inputAction.Keyboard.F.started -= (x) => GetCharacterFromInput("f");
            _inputAction.Keyboard.G.started -= (x) => GetCharacterFromInput("g");
            _inputAction.Keyboard.H.started -= (x) => GetCharacterFromInput("h");
            _inputAction.Keyboard.J.started -= (x) => GetCharacterFromInput("j");
            _inputAction.Keyboard.K.started -= (x) => GetCharacterFromInput("k");
            _inputAction.Keyboard.W.started -= (x) => GetCharacterFromInput("w");
            _inputAction.Keyboard.X.started -= (x) => GetCharacterFromInput("x");
            _inputAction.Keyboard.C.started -= (x) => GetCharacterFromInput("c");
            _inputAction.Keyboard.V.started -= (x) => GetCharacterFromInput("v");
            _inputAction.Keyboard.B.started -= (x) => GetCharacterFromInput("b");
            _inputAction.Keyboard.N.started -= (x) => GetCharacterFromInput("n");
            _inputAction.Keyboard.O.started -= (x) => GetCharacterFromInput(",");
            _inputAction.Keyboard.P.started -= (x) => GetCharacterFromInput(";");
        }
    }

    private void GetCharacterFromInput(string character)
    {
        OnAnyCharacter?.Invoke(character.ToUpper());
    }
}
