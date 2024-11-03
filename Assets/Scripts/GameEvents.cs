using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents:MonoBehaviour
{
    public static GameEvents current;
    void Awake()
    {
        current = this;
    }

    public event Action onTutorialEnd;
    public void EndTutorial()
    {
        onTutorialEnd?.Invoke();
    }
    public event Action onPlayerMoveFinished;
    public void PlayerMoveFinished()
    {
        onPlayerMoveFinished?.Invoke();
    }
}
