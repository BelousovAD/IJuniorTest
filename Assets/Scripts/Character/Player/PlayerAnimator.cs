using System.Collections.Generic;
using UnityEngine;

namespace Character.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
        private Dictionary<AnimationKey, int> _parameters;
        
        public enum AnimationKey
        {
            Fall = 0,
            Idle = 1,
            Jump = 2,
            Move = 3,
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _parameters = new Dictionary<AnimationKey, int>
            {
                [AnimationKey.Fall] = Animator.StringToHash(nameof(AnimationKey.Fall)),
                [AnimationKey.Jump] = Animator.StringToHash(nameof(AnimationKey.Jump)),
                [AnimationKey.Move] = Animator.StringToHash(nameof(AnimationKey.Move)),
            };
        }

        public void Play(AnimationKey animationKey)
        {
            foreach (int parameter in _parameters.Values)
            {
                _animator.SetBool(parameter, false);
            }

            if (_parameters.TryGetValue(animationKey, out int parameterId))
            {
                _animator.SetBool(parameterId, true);
            }
        }
    }
}
