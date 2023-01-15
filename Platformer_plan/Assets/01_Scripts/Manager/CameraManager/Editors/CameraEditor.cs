using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraManager))]
public class CameraEditor : Editor
{
    private float shakeCamTime = 1;
    private float shakeCamValue = 5;
    private float zoomCamValue = 8;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("ChangeVCam"))
        {
            if (CameraManager.instance != null)
                CameraManager.instance.ChangeVCam();
        }
        if (GUILayout.Button("ChangeVRigCam"))
        {
            if (CameraManager.instance != null)
                CameraManager.instance.ChangeRigCam();
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(20);
        if (GUILayout.Button("ZoomCam"))
        {
            if (CameraManager.instance != null)
                CameraManager.instance.ZoomCam(0.5f, zoomCamValue);
        }
        zoomCamValue = GUILayout.HorizontalSlider(zoomCamValue, 0, 20);
        GUILayout.Space(30);
        if (GUILayout.Button("ShakeCam"))
        {
            if (CameraManager.instance != null)
                CameraManager.instance.ShakeCam(shakeCamTime, shakeCamValue);
        }
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.TextArea("time");
        shakeCamTime = GUILayout.HorizontalSlider(shakeCamTime, 0, 5);
        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        GUILayout.TextArea("value");
        shakeCamValue = GUILayout.HorizontalSlider(shakeCamValue, 0f, 50f);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        GUILayout.Space(20);

    }
}
