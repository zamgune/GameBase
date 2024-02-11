using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LobbyScenePageController : MonoBehaviour
{
    [SerializeField]
    private PageBase _garagePage;
    [SerializeField]
    private PageBase _runePage;
    [SerializeField]
    private PageBase _battlePage;
    [SerializeField]
    private PageBase _supportPage;
    [SerializeField]
    private PageBase _shopPage;

    [SerializeField]
    private ScrollRect _scrollView;
    [SerializeField]
    private float _scrollMoveSpeed = 2f;

    private IEnumerator _scrollMoveRoutine;
    private IEnumerator _inactivePanelRoutine;

    public void MoveScrollToPage(SceneConfigs.eLobbyScenePage page)
    {
        ActivePagePanel(page);
        //SceneConfigs.eLobbyScenePage에 None, MAX가 포함돼 있기 때문에 2를 빼준다.
        float targetPos = (float)((int)(page - 1) / (float)((int)SceneConfigs.eLobbyScenePage.MAX - 2));
        if (_scrollMoveRoutine != null)
            StopCoroutine(_scrollMoveRoutine);
        _scrollMoveRoutine = MoveToScrollAt(targetPos);
        StartCoroutine(_scrollMoveRoutine);
    }

    private IEnumerator MoveToScrollAt(float normalizedTargetPos)
    {
        float time = 0f;
        var startPos = _scrollView.horizontalNormalizedPosition;
        while (time < 1f)
        {
            time += Time.deltaTime * _scrollMoveSpeed;
            _scrollView.horizontalNormalizedPosition = Mathf.Lerp(startPos, normalizedTargetPos, time);
            yield return null;
        }

        _scrollView.horizontalNormalizedPosition = normalizedTargetPos;
    }

    private void ActivePagePanel(SceneConfigs.eLobbyScenePage page)
    {
        if (_inactivePanelRoutine != null)
            StopCoroutine(_inactivePanelRoutine);

        switch (page)
        {
            case SceneConfigs.eLobbyScenePage.Garage:
                _garagePage.SetActivePagePanel(true);
                _runePage.SetActivePagePanel(true);
                _inactivePanelRoutine = InactivePagePanel(_battlePage, _supportPage, _shopPage);
                StartCoroutine(_inactivePanelRoutine);
                break;
            case SceneConfigs.eLobbyScenePage.Rune:
                _garagePage.SetActivePagePanel(true);
                _runePage.SetActivePagePanel(true);
                _battlePage.SetActivePagePanel(true);
                _inactivePanelRoutine = InactivePagePanel(_supportPage, _shopPage);
                StartCoroutine(_inactivePanelRoutine);
                break;
            case SceneConfigs.eLobbyScenePage.Battle:
                _runePage.SetActivePagePanel(true);
                _battlePage.SetActivePagePanel(true);
                _supportPage.SetActivePagePanel(true);
                _inactivePanelRoutine = InactivePagePanel(_garagePage, _shopPage);
                StartCoroutine(_inactivePanelRoutine);
                break;
            case SceneConfigs.eLobbyScenePage.Support:
                _battlePage.SetActivePagePanel(true);
                _supportPage.SetActivePagePanel(true);
                _shopPage.SetActivePagePanel(true);
                _inactivePanelRoutine = InactivePagePanel(_garagePage, _runePage);
                StartCoroutine(_inactivePanelRoutine);
                break;
            case SceneConfigs.eLobbyScenePage.Shop:
                _supportPage.SetActivePagePanel(true);
                _shopPage.SetActivePagePanel(true);
                _inactivePanelRoutine = InactivePagePanel(_garagePage, _runePage, _battlePage);
                StartCoroutine(_inactivePanelRoutine);
                break;
        }
    }

    private IEnumerator InactivePagePanel(params PageBase[] pages)
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i != pages.Length; i++)
        {
            pages[i].SetActivePagePanel(false);
        }
    }
}

public interface ILobbyPage
{
    void SetActivePagePanel(bool active);
}

[Serializable]
public class PageBase : ILobbyPage
{
    [SerializeField]
    protected GameObject _pagePanelRoot;

    public void SetActivePagePanel(bool active)
    {
        if (_pagePanelRoot.activeSelf == active)
            return;

        _pagePanelRoot.SetActive(active);
    }
}

[Serializable]
public class Lobby_Empty : IState
{
    public void Enter() { }
    public void Exit() { }
}


[Serializable]
public class Lobby_Garage : PageBase, IState
{
    public void Enter()
    {
        Debug.Log("차고 들어옴");
    }

    public void Exit()
    {
        Debug.Log("차고 나감");
    }
}


[Serializable]
public class Lobby_Rune : PageBase, IState
{

    public void Enter()
    {
        Debug.Log("룬 들어옴");
    }

    public void Exit()
    {
        Debug.Log("룬 나감");
    }
}


[Serializable]
public class Lobby_Battle : PageBase, IState
{

    public void Enter()
    {
        Debug.Log("전투 들어옴");
    }

    public void Exit()
    {
        Debug.Log("전투 나감");
    }
}


[Serializable]
public class Lobby_Support : PageBase, IState
{
    public void Enter()
    {
        Debug.Log("지원 들어옴");
    }

    public void Exit()
    {
        Debug.Log("지원 나감");
    }
}


[Serializable]
public class Lobby_Shop : PageBase, IState
{
    public void Enter()
    {
        Debug.Log("상점 들어옴");
    }

    public void Exit()
    {
        Debug.Log("상점 나감");
    }
}