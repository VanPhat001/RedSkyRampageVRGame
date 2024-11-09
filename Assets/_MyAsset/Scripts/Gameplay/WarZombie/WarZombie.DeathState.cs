using UnityEngine;

namespace WarZombie
{
    public class DeathState : BaseState
    {
        private FSMManager _manager;

        public DeathState(FSMManager manager) : base()
        {
            _manager = manager;
        }

        public override void EnterState()
        {
        }

        public override void UpdateState()
        {
        }

        public override void ExitState()
        {
        }
    }
}