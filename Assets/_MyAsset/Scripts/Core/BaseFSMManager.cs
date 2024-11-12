using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFSMManager<EnumType> : MonoBehaviour where EnumType : struct, IConvertible
{
    private Dictionary<EnumType, BaseState> _stateDic = new();
    private EnumType _currentState;
    public EnumType CurrentState => _currentState;

    protected void InitFSM(EnumType defaultState, params (EnumType, BaseState)[] states)
    {
        foreach (var item in states)
        {
            _stateDic.Add(item.Item1, item.Item2);
        }
        _currentState = defaultState;
        _stateDic[defaultState].EnterState();
    }

    public void ChangeState(EnumType newState)
    {
        _stateDic[_currentState].ExitState();
        _currentState = newState;
        _stateDic[_currentState].EnterState();
    }

    protected EnumType GetCurrentState()
    {
        return _currentState;
    }

    protected virtual void Update()
    {
        _stateDic[_currentState].UpdateState();
    }


    protected virtual void OnTriggerEnter(Collider collider)
    {
        _stateDic[_currentState].OnTriggerEnter(collider);
    }
    protected virtual void OnTriggerStay(Collider collider)
    {
        _stateDic[_currentState].OnTriggerStay(collider);
    }
    protected virtual void OnTriggerExit(Collider collider)
    {
        _stateDic[_currentState].OnTriggerExit(collider);
    }


    protected virtual void OnCollisionEnter(Collision collision)
    {
        _stateDic[_currentState].OnCollisionEnter(collision);
    }
    protected virtual void OnCollisionStay(Collision collision)
    {
        _stateDic[_currentState].OnCollisionStay(collision);
    }
    protected virtual void OnCollisionExit(Collision collision)
    {
        _stateDic[_currentState].OnCollisionExit(collision);
    }

}