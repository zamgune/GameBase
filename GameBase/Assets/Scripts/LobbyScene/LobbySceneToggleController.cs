using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LobbySceneToggleController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    private Toggle _garageToggle;
    [SerializeField]
    private Toggle _runeToggle;
    [SerializeField]
    private Toggle _battleToggle;
    [SerializeField]
    private Toggle _supportToggle;
    [SerializeField]
    private Toggle _shopToggle;
    [SerializeField]
    private GameObject _checkmark;
    [SerializeField]
    private float _checkMarkMoveSpeed = 3f;

    private Vector2 _dragPos;
    private IEnumerator _moveCheckmarkRoutine;
    private LobbyScene _lobby;

    public void Initialize(LobbyScene lobbyScene)
    {
        _lobby = lobbyScene;
        _garageToggle.onValueChanged.AddListener(x => GoToPage(x, SceneConfigs.eLobbyScenePage.Garage));
        _runeToggle.onValueChanged.AddListener(x => GoToPage(x, SceneConfigs.eLobbyScenePage.Rune));
        _battleToggle.onValueChanged.AddListener(x => GoToPage(x, SceneConfigs.eLobbyScenePage.Battle));
        _supportToggle.onValueChanged.AddListener(x => GoToPage(x, SceneConfigs.eLobbyScenePage.Support));
        _shopToggle.onValueChanged.AddListener(x => GoToPage(x, SceneConfigs.eLobbyScenePage.Shop));
        GoToPage(true, SceneConfigs.eLobbyScenePage.Battle);
    }

    private void GoToPage(bool enter, SceneConfigs.eLobbyScenePage page)
    {
        if (enter == false)
            return;

        switch (page)
        {
            case SceneConfigs.eLobbyScenePage.Garage:
                GoToGaragePage();
                break;
            case SceneConfigs.eLobbyScenePage.Rune:
                GoToRunePage();
                break;
            case SceneConfigs.eLobbyScenePage.Battle:
                GoToBattlePage();
                break;
            case SceneConfigs.eLobbyScenePage.Support:
                GoToSupportPage();
                break;
            case SceneConfigs.eLobbyScenePage.Shop:
                GoToShopPage();
                break;
        }
    }

    private void GoToGaragePage()
    {
        MoveToCheckmark(SceneConfigs.eLobbyScenePage.Garage);
        _garageToggle.isOn = true;
        _lobby.ChangePage(SceneConfigs.eLobbyScenePage.Garage);
    }

    private void GoToRunePage()
    {
        MoveToCheckmark(SceneConfigs.eLobbyScenePage.Rune);
        _runeToggle.isOn = true;
        _lobby.ChangePage(SceneConfigs.eLobbyScenePage.Rune);
    }

    private void GoToBattlePage()
    {
        MoveToCheckmark(SceneConfigs.eLobbyScenePage.Battle);
        _battleToggle.isOn = true;
        _lobby.ChangePage(SceneConfigs.eLobbyScenePage.Battle);
    }

    private void GoToSupportPage()
    {
        MoveToCheckmark(SceneConfigs.eLobbyScenePage.Support);
        _supportToggle.isOn = true;
        _lobby.ChangePage(SceneConfigs.eLobbyScenePage.Support);
    }

    private void GoToShopPage()
    {
        MoveToCheckmark(SceneConfigs.eLobbyScenePage.Shop);
        _shopToggle.isOn = true;
        _lobby.ChangePage(SceneConfigs.eLobbyScenePage.Shop);
    }

    private void MoveToCheckmark(SceneConfigs.eLobbyScenePage page)
    {
        Vector2 targetPos = page switch
        {
            SceneConfigs.eLobbyScenePage.Garage => _garageToggle.transform.position,
            SceneConfigs.eLobbyScenePage.Rune => _runeToggle.transform.position,
            SceneConfigs.eLobbyScenePage.Battle => _battleToggle.transform.position,
            SceneConfigs.eLobbyScenePage.Support => _supportToggle.transform.position,
            SceneConfigs.eLobbyScenePage.Shop => _shopToggle.transform.position,
            _ => Vector2.zero
        };

        if (_moveCheckmarkRoutine != null)
            StopCoroutine(_moveCheckmarkRoutine);
        _moveCheckmarkRoutine = CoMoveToCheckmark(targetPos);
        StartCoroutine(_moveCheckmarkRoutine);
    }

    private IEnumerator CoMoveToCheckmark(Vector2 targetPos)
    {
        float time = 0f;
        var startPos = _checkmark.transform.position;
        while (time < 1f)
        {
            time += Time.deltaTime * _checkMarkMoveSpeed;
            _checkmark.transform.position = Vector2.Lerp(startPos, targetPos, time);
            yield return null;
        }
        _checkmark.transform.position = targetPos;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragPos = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var deltaPos = _dragPos - eventData.position;
        if (Mathf.Sign(deltaPos.x) > 0f)
        {
            GoToPageAtDrag((int)_lobby.CurrentPage - 1);
        }
        else
        {
            GoToPageAtDrag((int)_lobby.CurrentPage + 1);
        }
    }

    private void GoToPageAtDrag(int pageIdx)
    {
        pageIdx = Mathf.Clamp(pageIdx, 0, (int)SceneConfigs.eLobbyScenePage.MAX);
        GoToPage(true, (SceneConfigs.eLobbyScenePage)pageIdx);
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}