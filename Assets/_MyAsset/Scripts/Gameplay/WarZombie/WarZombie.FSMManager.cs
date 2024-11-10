using UnityEngine;
using UnityEngine.AI;

namespace WarZombie
{
    public enum StateName
    {
        Idle, Walk, Attack, Death
    }

    public class FSMManager : BaseFSMManager<StateName>, IDamageable
    {
        // public Transform Model;
        [SerializeField] private Animator Anim;

        [SerializeField] public NavMeshAgent _agent;
        public NavMeshAgent Agent => _agent;

        [SerializeField] private Transform _target;
        public Transform Target => _target;

        [HideInInspector] public AnimationManager AnimManager;

        [SerializeField] private HealthBarSlider _healthBarSlider;
        // public HealthBarSlider HealthBarSlider => _healthBarSlider;

        [Range(0, 100)]
        public float HP = 100;

        // [Range(0, 1)]
        // public float DamageDecreaseRate = 0;

        [SerializeField] private Collider _bodyCollider;
        public Collider BodyCollider => _bodyCollider;

        [SerializeField] private ColliderList _rightHandColliders;
        public ColliderList RightHandColliders => _rightHandColliders;

        [SerializeField] private float _rightHandDamage = 5f;
        public float RightHandDamage => _rightHandDamage;


        void Awake()
        {
            BodyCollider.enabled = true;
            RightHandColliders.DisableAll();

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
            if (IsDeath())
            {
                return;
            }

            base.Update();
        }

        public bool IsDeath()
        {
            return HP <= 0;
        }

        public void GetHit(float damage)
        {
            if (IsDeath())
            {
                return;
            }

            HP = Mathf.Clamp(HP - damage, 0, 100);
            _healthBarSlider.SetValue(HP / 100f);

            if (HP <= 0)
            {
                ChangeState(StateName.Death);
            }
        }
    }
}
