using UnityEngine;

namespace WarZombie
{
    public class AnimationManager
    {
        // public readonly int IdleState = Animator.StringToHash("idle");
        public readonly int WalkState = Animator.StringToHash("walk");
        public readonly int AttackState = Animator.StringToHash("attack");
        public readonly int DeathState = Animator.StringToHash("death");
        private Animator _anim;

        public AnimationManager(Animator anim)
        {
            _anim = anim;
        }

        // public void SetIdle(bool value)
        // {
        //     _anim.SetBool(IdleState, value);
        // }

        public void SetWalk(bool value)
        {
            _anim.SetBool(WalkState, value);
        }

        public void SetAttack(bool value)
        {
            _anim.SetBool(AttackState, value);
        }

        public bool IsAttacking()
        {
            return _anim.GetBool(AttackState);
        }

        public void SetDeath(bool value)
        {
            _anim.SetBool(DeathState, value);
        }
    }
}