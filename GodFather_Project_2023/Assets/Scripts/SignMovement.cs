using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SignMovement", menuName = "ScriptableObjects/SignMovement", order = 1)]
public class SignMovement : ScriptableObject
{
    public float MaxSpeed;
    [MinMaxSlider(0f,10f)] public Vector2 ChangeDirectionTimerRange;
    public List<AnimationCurve> AllMovementCurves;
}
