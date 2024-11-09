using UnityEngine;

namespace WarZombie
{
    public class WalkState : BaseState
    {
        private FSMManager _manager;

        public WalkState(FSMManager manager) : base()
        {
            _manager = manager;
        }

        public override void EnterState()
        {
            _manager.Agent.isStopped = false;
            _manager.AnimManager.SetWalk(true);
        }

        public override void UpdateState()
        {
            _manager.Agent.destination = _manager.Target.position;

            if (ReachTarget())
            {
                _manager.Agent.velocity = Vector3.zero;
                _manager.ChangeState(StateName.Attack);
            }
        }

        public override void ExitState()
        {
            _manager.Agent.isStopped = true;
            _manager.AnimManager.SetWalk(false);
        }

        private bool ReachTarget()
        {
            var sqrLen = (_manager.Agent.destination - _manager.transform.position).sqrMagnitude;
            return sqrLen <= _manager.Agent.stoppingDistance * _manager.Agent.stoppingDistance;
        }
    }
}