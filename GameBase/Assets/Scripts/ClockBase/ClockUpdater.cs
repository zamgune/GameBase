using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace YongSDK
{
    public class ClockUpdater : MonoBehaviour
    {
        public class ClockRelationship
        {
            private GameClock _owner;
            private List<GameClock> _childClock = new();

            public void SetOwner(GameClock owner)
            {
                _owner = owner;
            }

            public void RegistChild(in GameClock clock)
            {
                _childClock.Add(clock);
            }

            public void SetTimeScale(in float timeScale)
            {
                _owner.SetTimeScale(timeScale);
                foreach (var clock in _childClock)
                {
                    clock.SetTimeScale(timeScale);
                }
            }
        }

        private GameClock _globalClock;
        private GameClock _allianceClock;
        private GameClock _enemyClock;
        private Dictionary<EClockType, ClockRelationship> _clockToRelationshipFair = new();

        public float DeltaTime_GlobalClock => _globalClock.DeltaTime;
        public float FixedDeltaTime_GlobalClock => _globalClock.FixedDeltaTime;

        public float DeltaTime_AllianceClock => _allianceClock.DeltaTime;
        public float FixedDeltaTime_AllianceClock => _allianceClock.FixedDeltaTime;

        public float DeltaTime_EnemyClock => _enemyClock.DeltaTime;
        public float FixedDeltaTime_EnemyClock => _enemyClock.FixedDeltaTime;

        private void Awake()
        {
            _globalClock = new GameClock();
            _allianceClock = new GameClock();
            _enemyClock = new GameClock();

            _clockToRelationshipFair.Add(EClockType.Global, new ClockRelationship());
            _clockToRelationshipFair.Add(EClockType.Alliance, new ClockRelationship());
            _clockToRelationshipFair.Add(EClockType.Enemy, new ClockRelationship());

            _clockToRelationshipFair[EClockType.Global].SetOwner(_globalClock);
            _clockToRelationshipFair[EClockType.Global].RegistChild(_allianceClock);
            _clockToRelationshipFair[EClockType.Global].RegistChild(_enemyClock);

            _clockToRelationshipFair[EClockType.Alliance].SetOwner(_allianceClock);
            _clockToRelationshipFair[EClockType.Enemy].SetOwner(_enemyClock);
        }

        public void SetTimeScale(float timeScale)
        {
            _globalClock.SetTimeScale(timeScale);
        }

        private void Update()
        {
            _globalClock.CustomUpdate();
            _allianceClock.CustomUpdate();
            _enemyClock.CustomUpdate();
        }

        private void FixedUpdate()
        {
            _globalClock.CustomFixedUpdate();
            _allianceClock.CustomFixedUpdate();
            _enemyClock.CustomFixedUpdate();
        }

        private void Change(float scale)
        {
            _clockToRelationshipFair[EClockType.Alliance].SetTimeScale(scale);
        }
    }
}