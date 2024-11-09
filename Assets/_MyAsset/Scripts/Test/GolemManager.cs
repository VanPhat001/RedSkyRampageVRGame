using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace GolemFSMManager
{
    public enum StateName
    {
        Idle,
        Walk,
        Attack,
        Sleep,
        Die
    }

    public class AnimationManager
    {
        public readonly int WalkState = Animator.StringToHash("walk");
        public readonly int AttackState = Animator.StringToHash("attack");
        public readonly int DieState = Animator.StringToHash("die");
        private Animator _anim;

        public AnimationManager(Animator anim)
        {
            _anim = anim;
        }

        public void SetWalk(bool value)
        {
            _anim.SetBool(WalkState, value);
        }

        public void SetAttack()
        {
            _anim.SetTrigger(AttackState);
        }

        public void SetDie(bool value)
        {
            _anim.SetBool(DieState, value);
        }

    }


    public class GolemManager : BaseFSMManager<StateName>
    {
        public Transform Model;
        [SerializeField] private Animator Anim;
        public NavMeshAgent Agent;
        public Transform Target;
        [HideInInspector] public AnimationManager AnimManager;
        public float HP = 100;
        [Range(0, 1)]
        public float DamageDecreaseRate = 0;


        void Awake()
        {
            AnimManager = new AnimationManager(Anim);
            InitFSM(StateName.Idle,
                (StateName.Idle, new IdleState(this)),
                (StateName.Walk, new WalkState(this)),
                (StateName.Attack, new AttackState(this)),
                (StateName.Sleep, new SleepState(this)),
                (StateName.Die, new DieState(this))
            );
        }

        protected override void Update()
        {
            if (HP <= 0)
            {
                return;
            }

            base.Update();
        }

        public void GetHit(float damage)
        {
            if (HP <= 0)
            {
                return;
            }

            damage *= 1 - DamageDecreaseRate;
            HP = Mathf.Clamp(this.HP - damage, 0, 100);

            if (HP <= 0)
            {
                ChangeState(StateName.Die);
            }
        }
    }


    public class IdleState : BaseState
    {
        private GolemManager _manager;

        public IdleState(GolemManager manager) : base()
        {
            _manager = manager;
        }

        private float _timer = 0;
        public override void EnterState()
        {
            _timer = 0;
            _manager.Agent.speed = 0;
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
            _timer += Time.deltaTime;
            if (_timer >= 3)
            {
                _manager.ChangeState(StateName.Walk);
            }
        }
    }


    public class WalkState : BaseState
    {
        private GolemManager _manager;

        public WalkState(GolemManager manager) : base()
        {
            _manager = manager;
        }

        public override void EnterState()
        {
            _manager.Agent.speed = 3;
            _manager.AnimManager.SetWalk(true);
        }

        public override void ExitState()
        {

            _manager.Agent.speed = 0;
            _manager.AnimManager.SetWalk(false);
        }

        public override void UpdateState()
        {
            _manager.Agent.destination = _manager.Target.position;
            if (_manager.Agent.remainingDistance <= _manager.Agent.stoppingDistance)
            {
                _manager.ChangeState(StateName.Attack);
            }
        }
    }


    public class AttackState : BaseState
    {
        private GolemManager _manager;
        private float _timer = 0;

        public AttackState(GolemManager manager) : base()
        {
            _manager = manager;
        }

        public override void EnterState()
        {
            _manager.AnimManager.SetAttack();
            _timer = 0;
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
            _timer += Time.deltaTime;

            if (_timer >= 1.2f)
            {
                _manager.ChangeState(StateName.Idle);
            }
        }
    }


    public class SleepState : BaseState
    {
        private GolemManager _manager;

        public SleepState(GolemManager manager) : base()
        {
            _manager = manager;
        }

        public override void EnterState()
        {
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
        }
    }


    public class DieState : BaseState
    {
        private GolemManager _manager;

        public DieState(GolemManager manager) : base()
        {
            _manager = manager;
        }

        public override void EnterState()
        {
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
        }
    }
}
