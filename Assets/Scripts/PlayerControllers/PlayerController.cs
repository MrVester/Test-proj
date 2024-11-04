using UnityEngine;
using NS.GameEventsScripts;
using Zenject;

namespace NS.PlayerControllerScripts
{
    public abstract class PlayerController
    {
        protected Camera _camera;
        protected Transform _player;
        protected float _movementSpeed;
        protected bool _isPlayerCanMove;
        protected Vector2 _targetPosition;
        protected GameEvents _gameEvents;
        public PlayerController(Camera camera, Transform player)
        {
            _camera = camera;
            _player = player;
        }

        public virtual void Init(float movementSpeed) 
        {
            _movementSpeed = movementSpeed;
        }

        public virtual void SubscribeEvents(GameEvents gameEvents) 
        {
            _gameEvents = gameEvents;
        }

        protected virtual void MovePlayer()
        { 
            if (_isPlayerCanMove)
            {
                _player.position = Vector2.Lerp(_player.position, _targetPosition, _movementSpeed * Time.deltaTime);
                if(Vector2.Distance(new Vector2(_player.position.x, _player.position.y), _targetPosition) <= 0.1f) 
                {
                    _isPlayerCanMove = false;
                    _gameEvents?.PlayerMoveFinished();
                } 
            }
        }

        protected virtual void OnMouseClicked() 
        {
            _targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _isPlayerCanMove = true;
        }
    }
}
