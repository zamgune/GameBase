using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger
{
    const float LOADING_COMPLETE_SYSTEM_VALUE = 0.9f;
    const float LOADING_COMPLETE_VALUE = 100f;

    public static float LoadingProgress;

    private static SceneConfigs.eSceneName _curChangeScene;
    private static float _delayTime;

    public static void LoadSceneAsync(SceneConfigs.eSceneName sceneName, float delayTime = 0.01f)
    {
        _curChangeScene = sceneName;
        _delayTime = Mathf.Clamp(delayTime, 0.01f, float.MaxValue);
        SceneManager.LoadSceneAsync((int)SceneConfigs.eSceneName.Loading);
    }

    public static IEnumerator LoadScene()
    {      
        var ao = SceneManager.LoadSceneAsync((int)_curChangeScene, LoadSceneMode.Single);
        ao.allowSceneActivation = false;
        var completeValue = LOADING_COMPLETE_SYSTEM_VALUE + _delayTime;
        var progressTime = 0f;
        while (!ao.isDone)
        {
            progressTime += Time.deltaTime;
            LoadingProgress = Mathf.Clamp((ao.progress + (progressTime / _delayTime) / completeValue) * LOADING_COMPLETE_VALUE, 0f, 100f);
            if (LoadingProgress >= LOADING_COMPLETE_VALUE)
            {
                //UI상에서 100프로를 보여주기위해 잠깐 기다려줌
                yield return new WaitForSeconds(0.1f);
                break;
            }
            yield return null;
        }
        ao.allowSceneActivation = true;
        LoadingProgress = 0f;
    }
}
