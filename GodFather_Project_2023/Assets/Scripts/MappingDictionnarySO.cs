using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MappingDictionnary", menuName = "ScriptableObjects/Mapping", order = 1)]
public class MappingDictionnarySO : ScriptableObject
{
    SerializableDictionary<string, Sprite> AllIcons;
}
