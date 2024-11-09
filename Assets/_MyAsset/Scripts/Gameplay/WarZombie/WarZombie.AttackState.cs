using UnityEngine;

namespace WarZombie
{
    public class AttackState : BaseState
    {
        private FSMManager _manager;

        public AttackState(FSMManager manager) : base()
        {
            _manager = manager;
        }

        public override void EnterState()
        {
            _manager.AnimManager.SetAttack(true);
        }

        public override void UpdateState()
        {
            if (!_manager.AnimManager.IsAttacking())
            {
                _manager.ChangeState(StateName.Idle);
            }
        }

        public override void ExitState()
        {
        }
    }
}