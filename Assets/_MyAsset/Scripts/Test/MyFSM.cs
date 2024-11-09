using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

namespace CUBE_TEST
{
    public enum StateName
    {
        Idle,
        MoveVertical,
        MoveHorizontal
    }

    public class MyFSM : BaseFSMManager<StateName>
    {
        [SerializeField] private Transform _model;
        public Transform Model => _model;

        void Awake()
        {
            InitFSM(StateName.Idle,
                (StateName.Idle, new IdleState(this)),
                (StateName.MoveVertical, new MoveVerticalState(this)),
                (StateName.MoveHorizontal, new MoveHorizontalState(this))
            );
        }

        protected override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ChangeState(StateName.Idle);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeState(StateName.MoveVertical);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeState(StateName.MoveHorizontal);
            }

            base.Update();
        }
    }


    /// <summary>
    /// ============= IdleState =============
    /// </summary>
    public class IdleState : BaseState
    {
        private MyFSM _manager;
        public IdleState(MyFSM manager) : base()
        {
            _manager = manager;
        }

        float _timer = 0;
        public override void EnterState()
        {
            Debug.Log("[Enter Idle State]");
            _timer = 0;
        }
        public override void ExitState()
        {
            Debug.Log("Exit Idle State >>> ");
        }
        public override void UpdateState()
        {
            // _timer += Time.deltaTime;
            // if (_timer >= 4)
            // {
            //     _shareProperties.Model = null;
            //     _timer = float.MinValue;
            // }
        }
    }

    /// <summary>
    /// ============= MoveVerticalState =============
    /// </summary>
    public class MoveVerticalState : BaseState
    {
        private MyFSM _manager;
        public MoveVerticalState(MyFSM manager) : base()
        {
            _manager = manager;
        }

        public override void EnterState()
        {
            Debug.Log("[Enter MoveVertical State]");
        }
        public override void ExitState()
        {
            Debug.Log("Exit MoveVertical State >>> ");
        }
        public override void UpdateState()
        {
            _manager.Model.Translate(Time.deltaTime * Vector3.forward);
        }
    }

    /// <summary>
    /// ============= MoveHorizontalState =============
    /// </summary>
    public class MoveHorizontalState : BaseState
    {
        private MyFSM _manager;
        public MoveHorizontalState(MyFSM manager) : base()
        {
            _manager = manager;
        }

        public override void EnterState()
        {
            Debug.Log("[Enter MoveHorizontal State]");
        }
        public override void ExitState()
        {
            Debug.Log("Exit MoveHorizontal State >>> ");
        }
        public override void UpdateState()
        {
            _manager.Model.Translate(Time.deltaTime * Vector3.right);
        }
    }

}