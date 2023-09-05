using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEditor.TerrainTools;
using UnityEditorInternal;
using UnityEngine;
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
    [SerializeField] TMP_Text _text;
    [SerializeField] BubbleManager _bubbleManager;

    private void Awake()
    {
        _inputAction = new Inputs();
        _inputAction.Keyboard.Enable();
        _text.text = "";
    }

    private void OnEnable()
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
        _inputAction.Keyboard.L.started += (x) => GetCharacterFromInput(";");
    }

    private void OnDisable()
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
        _inputAction.Keyboard.L.started -= (x) => GetCharacterFromInput(";");
    }

    private void GetCharacterFromInput(string character)
    {
        _text.text = character + "-" + _text.text;
        _bubbleManager.CheckAllSigns(character.ToUpper());
    }
}
