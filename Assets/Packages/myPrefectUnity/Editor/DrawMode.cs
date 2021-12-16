using UnityEditor;

#pragma warning disable 618

public class DrawMode
{
    [MenuItem("Tools/Change Draw Camera Mode &w", false)]
    public static void ChangeDrawCameraMode()
    {
        if (SceneView.lastActiveSceneView == null) return;

        SceneView.lastActiveSceneView.renderMode =
            SceneView.lastActiveSceneView.renderMode == DrawCameraMode.Textured
                ? DrawCameraMode.Wireframe
                : DrawCameraMode.Textured;
    }
}