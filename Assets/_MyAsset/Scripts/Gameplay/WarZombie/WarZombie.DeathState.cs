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
            _manager.AnimManager.SetDeath(true);
            _manager.BodyCollider.enabled = false;

            GameObject.Destroy(_manager.gameObject, 4);
        }

        public override void UpdateState()
        {
        }

        public override void ExitState()
        {
        }
    }
}