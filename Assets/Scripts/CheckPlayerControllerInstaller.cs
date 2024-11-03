using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckPlayerControllerInstaller
{
    private IPlayerController _controller;
    private CheckPlayerControllerInstaller(IPlayerController player)
    {
        Debug.Log(player.GetType());
    }
}
