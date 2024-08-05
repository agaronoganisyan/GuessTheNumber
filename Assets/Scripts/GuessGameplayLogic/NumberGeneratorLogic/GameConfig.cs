using System;
using UnityEngine;

namespace GuessGameplayLogic.NumberGeneratorLogic
{
    [CreateAssetMenu (fileName = "GameConfig", menuName = "GameConfig/New GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public int MaxNumberValue { get; private set; }
    }
}