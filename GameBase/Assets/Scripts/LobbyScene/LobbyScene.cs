using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LobbyScene : MonoBehaviour, IStateDelegate
{
    public SceneConfigs.eLobbyScenePage CurrentPage => (SceneConfigs.eLobbyScenePage)_stateMachine.CurrentStateIdx;

    [SerializeField]
    private LobbySceneToggleController _toggleController;
    [SerializeField]
    private LobbyScenePageController _pageController;

    private StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _stateMachine.Delegate = this;
        _toggleController.Initialize(this);
    }

    public void ChangePage(SceneConfigs.eLobbyScenePage page)
    {
        _pageController.MoveScrollToPage(page);
        _stateMachine.ChangeState((int)page);
    }

    #region IStateDelegate
    public Dictionary<int, IState> InitStates()
    {
        Dictionary<int, IState> states = new Dictionary<int, IState>();
        states.Add((int)SceneConfigs.eLobbyScenePage.None, new Lobby_Empty());
        states.Add((int)SceneConfigs.eLobbyScenePage.Garage, new Lobby_Garage());
        states.Add((int)SceneConfigs.eLobbyScenePage.Rune, new Lobby_Rune());
        states.Add((int)SceneConfigs.eLobbyScenePage.Battle, new Lobby_Battle());
        states.Add((int)SceneConfigs.eLobbyScenePage.Support, new Lobby_Support());
        states.Add((int)SceneConfigs.eLobbyScenePage.Shop, new Lobby_Shop());
        return states;
    }
    #endregion
}