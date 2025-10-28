namespace Character.Player
{
    using Camera;
    using UnityEngine;

    public class PlayerMover : Mover
    {
        [SerializeField] private FreeLookCamera _freeLookCamera;

        protected override Quaternion RotateForward() =>
            Quaternion.AngleAxis(_freeLookCamera.HorizontalAngle, Vector3.up);
    }
}