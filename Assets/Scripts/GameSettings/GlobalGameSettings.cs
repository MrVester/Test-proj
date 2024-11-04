using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalGameSettings",menuName = "ScriptableObjects/GlobalGameSettings")]
public class GlobalGameSettings : ScriptableObject
{
    [SerializeField] private bool _isTutorialCompleted;

    public bool IsTutorialCompleted => _isTutorialCompleted;

    public void SetTutorialState(bool isCompleted) => _isTutorialCompleted = isCompleted;
}
