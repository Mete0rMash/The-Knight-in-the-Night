using System;
using UnityEngine;

namespace LMA.Weapons
{
    public class AnimationEventHandler : MonoBehaviour
    {
        public event Action OnFinish;

        private void AnimationFinishedTrigger() => OnFinish?.Invoke();
    }
}
