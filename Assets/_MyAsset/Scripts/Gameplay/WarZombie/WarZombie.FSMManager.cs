using CUBE_TEST;
using UnityEngine;
using UnityEngine.AI;

namespace WarZombie
{
    public enum StateName
    {
        Idle, Walk, Attack, Death
    }

    public class FSMManager : BaseFSMManager<StateName>
    {
        // public Transform Model;
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
                (StateName.Death, new DeathState(this))
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
    }
}
