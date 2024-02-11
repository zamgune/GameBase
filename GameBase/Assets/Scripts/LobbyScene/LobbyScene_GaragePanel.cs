using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using EnhancedUI.EnhancedScroller;
using UnityEngine.AddressableAssets;

public class LobbyScene_GaragePanel : MonoBehaviour, IEnhancedScrollerDelegate
{
    [SerializeField]
    private GaragePanel_SelectedUnitPanel _selectedUnitPanel;
    [SerializeField]
    private EnhancedScroller _scroller;
    [SerializeField]
    private AssetReference _cellRef;

    private UIGaragePanelCell _cellPrefab;
    private float _cellHeight;

    private void Awake()
    {        
        _cellPrefab = AddressableLoader.LoadAsset(_cellRef).GetComponent<UIGaragePanelCell>();
        _cellHeight = (_cellPrefab.transform as RectTransform).rect.height;
        _scroller.Delegate = this;
    }

    private void OnDestroy()
    {
        AddressableLoader.Release(_cellPrefab.gameObject);
    }

    #region EnhancedScroller
    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
        var cellView = scroller.GetCellView(_cellPrefab);
        return cellView;
    }

    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return _cellHeight;
    }

    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        return 5;
    }
    #endregion
}

[Serializable]
public class GaragePanel_SelectedUnitPanel
{
    [SerializeField]
    private List<SelectedSlot> _slots;


    [Serializable]
    public class SelectedSlot
    {
        [SerializeField]
        private GameObject _slotObj;
        [SerializeField]
        private Image _unitPortrait;
    }
}
