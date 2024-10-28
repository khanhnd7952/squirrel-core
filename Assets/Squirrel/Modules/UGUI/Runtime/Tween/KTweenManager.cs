using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace Squirrel.UGUI
{
    [Serializable]
    public class KTweenManager
    {
#if SQUIRREL_DOTWEEN
        [SerializeField] private float test;
#endif
        [ReadOnly] [SerializeField] protected GameObject parent;
        [ReadOnly] [SerializeField] protected List<DOTweenAnimation> tweens;
        [ReadOnly] [SerializeField] protected DOTweenAnimation longestTween;
        [ReadOnly] [SerializeField] protected string tweenId;
        private bool _isPlaying = false;

        public void InitTween(GameObject parent, string id)
        {
            this.parent = parent;
            tweenId = id;
            DOTweenAnimation[] allTweens = this.parent.GetComponentsInChildren<DOTweenAnimation>(true);

            tweens = new List<DOTweenAnimation>();

            var longestShow = float.MinValue;
            foreach (DOTweenAnimation tween in allTweens)
            {
                if (tween.isActive && tween.duration > 0 && tween.id == tweenId)
                {
                    tween.autoGenerate = false;
                    tween.autoPlay = false;
                    tween.autoKill = false;
                    tween.loops = 1;
                    tween.isIndependentUpdate = true;

                    var tweenTime = tween.delay + tween.duration;
                    if (tweenTime > longestShow)
                    {
                        longestShow = tweenTime;
                        longestTween = tween;
                    }

                    tweens.Add(tween);
                }
            }

            if (longestTween != null)
            {
                longestTween.hasOnComplete = true;
                longestTween.onComplete = new UnityEvent();
                longestTween.onComplete.RemoveAllListeners();
                longestTween.onComplete.AddListener(OnPlayComplete);
            }
        }

        private void OnPlayComplete()
        {
            _isPlaying = false;
        }

        public async UniTask Play()
        {
            if (tweens.IsNullOrEmpty())
            {
                return;
            }

            _isPlaying = true;

            StopAllTween();

            foreach (DOTweenAnimation doTweenAnimation in tweens)
            {
                doTweenAnimation.CreateTween(false, false);
                doTweenAnimation.DORestartById(tweenId);
                doTweenAnimation.DOPlayById(tweenId);
            }

            await UniTask.WaitUntil(() => !_isPlaying);
        }

        public void StopAllTween()
        {
            foreach (DOTweenAnimation doTweenAnimation in tweens)
            {
                if (doTweenAnimation != null) continue;
                doTweenAnimation.DOPause();
            }
        }
    }
}