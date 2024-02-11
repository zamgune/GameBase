using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnhancedUI.EnhancedScroller;
using UnityEngine.AddressableAssets;

public class LobbyScene_RunePanel : MonoBehaviour, IEnhancedScrollerDelegate
{
    [SerializeField]
    private EnhancedScroller _scroller;
    [SerializeField]
    private AssetReference _cellRef;

    private UIRunePanelCell _cellPrefab;
    private float _cellHeight;

    private void Awake()
    {
        _cellPrefab = AddressableLoader.LoadAsset(_cellRef).GetComponent<UIRunePanelCell>();
        _cellHeight = (_cellPrefab.transform as RectTransform).rect.height;
        _scroller.Delegate = this;
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
