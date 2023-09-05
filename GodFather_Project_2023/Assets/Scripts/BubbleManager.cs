using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    [SerializeField] List<InputSign> signs = new List<InputSign>();

    private void Start()
    {
        InitializeSigns();
    }

    public void CheckAllSigns(string str)
    {
        signs.ForEach(x => x.CheckText(str));
        if (signs.TrueForAll(x => !x.gameObject.activeSelf))
        {
            InitializeSigns();
        }
    }

    public void InitializeSigns()
    {
        List<string> fullList = new List<string>(InputManager.CHARACTERS);
        for (int i = 0; i < signs.Count; i++)
        {
            string text = fullList[Random.Range(0, fullList.Count)];
            signs[i].SetText(text);
            fullList.Remove(text);
        }
    }
}