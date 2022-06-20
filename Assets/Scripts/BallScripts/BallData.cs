using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallData", menuName = "ScriptableObjects/BallData", order = 1)]
public class BallData : ScriptableObject
{
    [SerializeField]
    internal float MinSpeed = 2.5f;
    [SerializeField]
    internal float MaxSpeed = 4f;
    [SerializeField]
    internal float MinScale = 0.2f;
    [SerializeField]
    internal float MaxScale = 1f;

    [SerializeField]
    internal float MinimalCollisionPositionDelta = 0.5f;
}
