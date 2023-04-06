using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(FOV))]
public class FOVeditor : Editor
{
    private void OnSceneGUI()
    {
        FOV fow = (FOV)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
        Vector3 viewAngle1 = fow.DirectionFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngle2 = fow.DirectionFromAngle(fow.viewAngle / 2, false);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngle1 * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngle2 * fow.viewRadius);
        Handles.color = Color.red;
        foreach(Transform visibleTarget in fow.visibleTargets)
        {
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }
    }
}
