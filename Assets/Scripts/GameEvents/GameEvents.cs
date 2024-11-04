using System;

namespace NS.GameEventsScripts {
    public class GameEvents
    {
        public ControllerChangeInDependencyContainer controllerChangeInDependencyContainer { get; private set; } = new();

        public Action onTutorialEnd;

        public void EndTutorial()
        {
            onTutorialEnd?.Invoke();
        }

        public Action onPlayerMoveFinished;

        public void PlayerMoveFinished()
        {
            onPlayerMoveFinished?.Invoke();
        }
    }
}