using UnityEditor;
using UnityEngine;

public class SpawnPlaneGizmoDrawer
{
    private static readonly Color _transparentLightBlue = new(0f, 0.5f, 1f, 0.5f);

    [DrawGizmo(GizmoType.Active | GizmoType.NonSelected | GizmoType.Pickable)]
    private static void DrawGizmo(SpawnPlane target, GizmoType gizmoType)
    {
        Gizmos.color = _transparentLightBlue;
        Gizmos.DrawCube(target.transform.position, new Vector3(target.Size.x, 0f, target.Size.z));
    }
}
