using UnityEngine;

namespace Character
{
    public static class AnimatorParameters
    {
        public static class Player
        {
            public static readonly int Fall = Animator.StringToHash("Fall");
            public static readonly int Idle = Animator.StringToHash("Idle");
            public static readonly int Jump = Animator.StringToHash("Jump");
            public static readonly int Move = Animator.StringToHash("Move");
        }
    }
}