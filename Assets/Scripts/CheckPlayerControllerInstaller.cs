using NS.PlayerControllerScripts;
using UnityEngine;

public class CheckPlayerControllerInstaller
{
    private PlayerController _controller;
    private CheckPlayerControllerInstaller(PlayerController player)
    {
        Debug.Log(player.GetType());
    }
}
