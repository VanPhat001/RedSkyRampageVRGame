using UnityEngine;

namespace WarZombie
{
    public class IdleState : BaseState
    {
        private FSMManager _manager;

        public IdleState(FSMManager manager) : base()
        {
            _manager = manager;
        }


        private float _timer;
        public override void EnterState()
        {
            _timer = 2.4f;
            _manager.Agent.isStopped = true;
        }

        public override void UpdateState()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _manager.ChangeState(StateName.Walk);
            }
        }

        public override void ExitState()
        {
            _manager.Agent.isStopped = false;
        }
    }
}