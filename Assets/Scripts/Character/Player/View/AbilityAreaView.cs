using Character.Player.ChangeableValue;
using Common.View;
using UnityEngine;

namespace Character.Player.View
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class AbilityAreaView : AbstractParameterView<Ability>
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake() =>
            _spriteRenderer = GetComponent<SpriteRenderer>();

        protected override void UpdateView() =>
            _spriteRenderer.enabled = Parameter.Value;
    }
}
