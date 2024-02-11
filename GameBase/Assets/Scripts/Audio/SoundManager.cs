using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _bgmRoot;
    [SerializeField]
    private GameObject _sfxRoot;
    [SerializeField]
    private int _maxSFX = 15;

    private AudioSource _bgmAudio;

    private Queue<AudioSource> _sfxAudios = new();

    public void PlayBGM(string soundName, string extension = ".ogg")
    {
        var clip = AddressableLoader.LoadAsset<AudioClip>($"{AddressableConfigs.BGM_PATH_PREFIX}{soundName}{extension}");
        if (clip == null)
            return;

        _bgmAudio.clip = clip;
        PlayBGM();
    }

    public void PauseBGM()
    {
        _bgmAudio.Pause();
    }

    public void PlayBGM()
    {
        _bgmAudio.Play();
    }

    public void Play2DSfx(string soundName, string extension = ".wav")
    {
        var clip = AddressableLoader.LoadAsset<AudioClip>($"{AddressableConfigs.SFX_PATH_PREFIX}{soundName}{extension}");
        if (clip == null)
            return;

        var audio = _sfxAudios.Dequeue();
        audio.Stop();
        audio.clip = clip;
        audio.spatialBlend = 0f;
        audio.Play();
        _sfxAudios.Enqueue(audio);
    }

    public void Play3DSfx(string soundName, Vector3 soundPos, string extension = ".wav")
    {
        var clip = AddressableLoader.LoadAsset<AudioClip>($"{AddressableConfigs.SFX_PATH_PREFIX}{soundName}{extension}");
        if (clip == null)
            return;

        var audio = _sfxAudios.Dequeue();
        audio.Stop();
        audio.clip = clip;        
        audio.transform.position = soundPos;
        audio.spatialBlend = 1f;
        audio.Play();
        _sfxAudios.Enqueue(audio);
    }

    protected void Awake()
    {
        InitBGMLayer();
        InitSFXLayer();
    }

    private void InitBGMLayer()
    {
        _bgmAudio = new GameObject("BGMAudio").AddComponent<AudioSource>();
        _bgmAudio.loop = true;
        _bgmAudio.playOnAwake = false;
        _bgmAudio.transform.SetParent(_bgmRoot.transform);
    }

    private void InitSFXLayer()
    {
        for (int i = 0; i != _maxSFX; i++)
        {
            var obj = new GameObject($"SFXAudio_{i + 1}").AddComponent<AudioSource>();
            obj.loop = false;
            obj.playOnAwake = false;
            obj.transform.SetParent(_sfxRoot.transform);
            _sfxAudios.Enqueue(obj);
        }
    }
}
