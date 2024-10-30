using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace Squirrel.UGUI
{
    [Serializable]
    public class KTweenManager : MonoBehaviour
    {
         string _tweenId;
        
        DOTweenAnimation[] _tweens;
        DOTweenAnimation _longestTween;
        bool _isPlaying;
        private bool _init;

        [Button]
        public void InitTween(string id)
        {
            _tweenId = id;
            _tweens = GetComponents<DOTweenAnimation>();

            var longestShow = float.MinValue;
            foreach (DOTweenAnimation tween in _tweens)
            {
                if (tween.isActive && tween.duration > 0)
                {
                    tween.autoGenerate = false;
                    tween.autoPlay = false;
                    tween.autoKill = false;
                    tween.loops = 1;
                    tween.isIndependentUpdate = true;
                    tween.id = _tweenId;
                    //tween.CreateTween(true, false); 

                    var tweenTime = tween.delay + tween.duration;
                    if (tweenTime > longestShow)
                    {
                        longestShow = tweenTime;
                        _longestTween = tween;
                    }
                }
            }

            if (_longestTween != null)
            {
                _longestTween.hasOnComplete = true;
                _longestTween.onComplete = new UnityEvent();
                _longestTween.onComplete.RemoveAllListeners();
                _longestTween.onComplete.AddListener(OnPlayComplete);
            }
        }

        private void OnPlayComplete()
        {
            _isPlaying = false;
        }

        [Button]
        public async UniTask Play()
        {
            if (_tweens.IsNullOrEmpty())
            {
                return;
            }

            _isPlaying = true;

            StopAllTween();

            foreach (DOTweenAnimation doTweenAnimation in _tweens)
            {
                doTweenAnimation.CreateTween(false, false);
                doTweenAnimation.DORestartById(_tweenId);
                doTweenAnimation.DOPlayById(_tweenId);
            }

            await UniTask.WaitUntil(() => !_isPlaying);
        }

        public void StopAllTween()
        {
            foreach (DOTweenAnimation doTweenAnimation in _tweens)
            {
                doTweenAnimation.DOPauseAllById(_tweenId);
            }
        }
    }
}