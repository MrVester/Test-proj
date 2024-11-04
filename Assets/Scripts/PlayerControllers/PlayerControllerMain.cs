using UnityEngine;
using Zenject;

namespace NS.PlayerControllerScripts
{
    public class PlayerControllerMain : PlayerController, ITickable
    {
        public PlayerControllerMain(Camera camera, Transform player) : base(camera, player) { }

        public void Tick()
        {
            Debug.Log("Tick main");
            if (Input.GetMouseButtonDown(0)) 
            {
                OnMouseClicked();
            }

            MovePlayer();
        }
    }
}