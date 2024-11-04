using System;
using NS.PlayerControllerScripts;

namespace NS.GameEventsScripts
{
    public class ControllerChangeInDependencyContainer
    {
        public Action<PlayerController> OnPlayerControllerRebinded;
        public Action OnPlayerControllerRebindCalled;
    }
}
