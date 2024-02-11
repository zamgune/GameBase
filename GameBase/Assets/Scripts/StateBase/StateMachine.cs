using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public int CurrentStateIdx { get; private set; }
    public IStateDelegate Delegate { private get; set; }

    private Dictionary<int, IState> _states;

    public void ChangeState(int stateIdx)
    {
        if (_states == null)
            InitStates();

        if (CurrentStateIdx == stateIdx)
            return;

        if (stateIdx > _states.Count)
            return;

        _states[CurrentStateIdx].Exit();
        CurrentStateIdx = stateIdx;
        _states[CurrentStateIdx].Enter();
    }

    private void InitStates()
    {
        _states = Delegate.InitStates();
    }
}