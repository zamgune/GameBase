using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace YongSDK
{
    public class GameClock
    {
        public float DeltaTime { get; private set; }
        public float FixedDeltaTime { get; private set; }
        private float _timeScale = 1f;

        public void SetTimeScale(float timeScale)
        {
            _timeScale = Mathf.Clamp(timeScale, 0f, 1f);
        }

        public void CustomUpdate()
        {
            DeltaTime = (Time.unscaledDeltaTime * _timeScale);
        }

        public void CustomFixedUpdate()
        {
            FixedDeltaTime = (Time.fixedUnscaledDeltaTime * _timeScale);
        }
    }
}