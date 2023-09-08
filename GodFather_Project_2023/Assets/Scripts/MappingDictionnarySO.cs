using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MappingDictionnary", menuName = "ScriptableObjects/Mapping", order = 2)]
public class MappingDictionnarySO : ScriptableObject
{
    public List<string> Keys = new List<string>();
    public List<Sprite> Values = new List<Sprite>();
    public List<AudioClip> Clips = new List<AudioClip>();
}