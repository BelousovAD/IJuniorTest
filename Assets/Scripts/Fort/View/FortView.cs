namespace Fort.View
{
    using System;
    using System.Collections.Generic;
    using States;
    using UnityEngine;

    public class FortView : MonoBehaviour
    {
        [SerializeField] private Fort _fort;
        [SerializeField] private List<GameObject> _buildingStateObjects = new();
        [SerializeField] private List<GameObject> _creationFortStateObjects = new();
        [SerializeField] private List<GameObject> _creationUnitStateObjects = new();

        private void OnEnable()
        {
            _fort.Initialized += Subscribe;

            if (_fort.StateMachine is not null)
            {
                Subscribe();
            }
        }

        private void OnDisable() =>
            Unsubscribe();

        private void Subscribe()
        {
            _fort.Initialized -= Subscribe;
            _fort.StateMachine.StateChanged += UpdateView;
            UpdateView();
        }

        private void Unsubscribe()
        {
            _fort.Initialized -= Subscribe;

            if (_fort.StateMachine is not null)
            {
                _fort.StateMachine.StateChanged -= UpdateView;
            }
        }

        private void UpdateView()
        {
            _buildingStateObjects.ForEach(obj => obj.SetActive(false));
            _creationFortStateObjects.ForEach(obj => obj.SetActive(false));
            _creationUnitStateObjects.ForEach(obj => obj.SetActive(false));

            switch (_fort.StateMachine.CurrentState)
            {
                case BuildingState:
                    _buildingStateObjects.ForEach(obj => obj.SetActive(true));
                    break;
                case CreationFortState:
                    _creationFortStateObjects.ForEach(obj => obj.SetActive(true));
                    break;
                case CreationUnitState:
                    _creationUnitStateObjects.ForEach(obj => obj.SetActive(true));
                    break;
            }
        }
    }
}