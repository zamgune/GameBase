using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _percentText;
    [SerializeField]
    private Slider _percentSlider;

    private void Start()
    {
        StartCoroutine(SceneChanger.LoadScene());
    }

    private void Update()
    {
        _percentText.text = $"{SceneChanger.LoadingProgress:###.##}";
        _percentSlider.value = SceneChanger.LoadingProgress;
    }
}
