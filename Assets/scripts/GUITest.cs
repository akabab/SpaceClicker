using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {

  public Rect rect;
  public Texture2D img;

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }

  void OnGUI () {

    // GUIAspectRatio.Get().SetAspectRatio();
    GUISizer.BeginGUI();

    GUI.Label(rect, img);

    GUISizer.EndGUI();
  }
}
