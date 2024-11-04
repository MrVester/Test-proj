using System;
using UnityEngine;
using Zenject;
using NS.GameEventsScripts;

namespace NS.PlayerControllerScripts
{
    public class PlayerControllerTutorial : PlayerController, ITickable, IDisposable
    {
        private RaycastHit2D _rayHit;
        private int _tutorialQuadsClicked = 0;

        public PlayerControllerTutorial(Camera camera, Transform player) : base(camera, player) { }

        public override void SubscribeEvents(GameEvents gameEvents) 
        {
            base.SubscribeEvents(gameEvents);
            _gameEvents.onPlayerMoveFinished += CheckIsTutorialOver;
        }

        public void Dispose()
        {
            _gameEvents.onPlayerMoveFinished -= CheckIsTutorialOver;
        }

        public bool IsRedSquare()
        {
            _rayHit = Physics2D.GetRayIntersection(_camera.ScreenPointToRay(Input.mousePosition));
            if (!_rayHit)
                return false;

            if (!_rayHit.collider.CompareTag("RedSquare"))
                return false;

            _targetPosition = _rayHit.collider.gameObject.transform.position;
            return true;
        }

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnMouseClicked();
            }

            MovePlayer();
        }

        protected override void OnMouseClicked()
        {
            if (IsRedSquare())
            {
                _tutorialQuadsClicked++;
                base.OnMouseClicked();
            }
        }

        private void CheckIsTutorialOver() 
        {
            if (_tutorialQuadsClicked >= 3) 
            {
                _gameEvents?.controllerChangeInDependencyContainer.OnPlayerControllerRebindCalled?.Invoke();
            }
        }
    }
}