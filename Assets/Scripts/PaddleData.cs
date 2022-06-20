#define ANDROID

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PaddleData", menuName = "ScriptableObjects/PaddleData", order = 1)]
public class PaddleData : ScriptableObject
{
    public float Speed = 4f;
}
