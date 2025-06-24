using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInteractableButton : AbstractButton
{
    [SerializeField] private List<Selectable> _selectables = new();

    protected override void ClickHandler() =>
        _selectables.ForEach(selectable => selectable.interactable = !selectable.interactable);
}
