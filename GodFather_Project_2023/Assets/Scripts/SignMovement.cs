using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SignMovement", menuName = "ScriptableObjects/SignMovement", order = 1)]
public class SignMovement : ScriptableObject
{
    public float MaxSpeed;
    public Vector2 ChangeDirectiontimer;
    public List<AnimationCurve> AllMovementCurves;
}
