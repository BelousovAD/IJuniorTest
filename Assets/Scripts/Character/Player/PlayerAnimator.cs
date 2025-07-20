namespace Character.Player
{
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
        private Dictionary<AnimationKey, int> _parameters;
        
        public enum AnimationKey
        {
            Move = 0,
            Fly = 1,
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _parameters = new Dictionary<AnimationKey, int>
            {
                [AnimationKey.Fly] = Animator.StringToHash(nameof(AnimationKey.Fly))
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
