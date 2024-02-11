using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScene : MonoBehaviour
{
    public Button SceneChangeTestBtn;
    public Button PopupTestBtn;

    private void Start()
    {
        SceneChangeTestBtn.onClick.AddListener(() => SceneChanger.LoadSceneAsync(SceneConfigs.eSceneName.Lobby, 1f));

    }

}
