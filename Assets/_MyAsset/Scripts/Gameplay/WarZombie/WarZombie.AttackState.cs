using Unity.VisualScripting;
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
            _manager.RightHandColliders.EnableAll();
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
            _manager.RightHandColliders.DisableAll();
            // _manager.AnimManager.SetAttack(false); // auto set false

        }


        public override void OnTriggerEnter(Collider collider)
        {
            base.OnTriggerEnter(collider);

            // only contact with `Network Player`
            Debug.Log("[DEV] " + collider.gameObject.layer + "   " + LayerMask.NameToLayer("Network Player"));
            if (collider.gameObject.layer != LayerMask.NameToLayer("Network Player"))
            {
                return;
            }

            // Debug.Log(collider.gameObject.name);
            // Debug.Log(collider.transform.root.GetComponent<IDamageable>());
            collider.transform.root.GetComponent<IDamageable>()?.GetHit(_manager.RightHandDamage);
        }
    }
}