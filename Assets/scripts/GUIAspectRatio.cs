using UnityEngine;
using System.Collections;

/*  Manage GUI Aspect Ratio
 *  Currently debug screen resolution every frame
 *
 *  Set AR calling the public method from extern scripts
 *
 *  Creator : Y.Cribier
*/

public class GUIAspectRatio : MonoBehaviour
{
  // singleton
  private static GUIAspectRatio m_Instance = null;
  public static GUIAspectRatio Get()
  {
      if (m_Instance == null)
          m_Instance = (GUIAspectRatio)FindObjectOfType(typeof(GUIAspectRatio));
      return m_Instance;
  }

  // class
  public int refWidth = 1024;
  public int refHeight = 768;

  public int screenWidth;
  public int screenHeight;

  void Update ()
  {
    screenWidth = Screen.width;
    screenHeight = Screen.height;
  }

  public void SetAspectRatio()
  {
    float horizRatio = screenWidth / (float) refWidth;
    float vertRatio = screenHeight / (float) refHeight;

    Vector3 translation = new Vector3(0, 0, 0);
    Quaternion rotation = Quaternion.identity;
    Vector3 scale = new Vector3(horizRatio, vertRatio, 1);

    GUI.matrix = Matrix4x4.TRS(translation, rotation, scale);
  }
}
