using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

  public Rect rect;

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {
    rect = new Rect(0, 0, Screen.width * 0.5f, Screen.height * 0.33f);
  }

  void OnGUI () {

    GUIAspectRatio.Get().SetAspectRatio();

    // GUISizer.BeginGUI();

    GUI.Box(rect, "Distance: " + Game.Get().distance + " ly");

    // GUISizer.EndGUI();
  }
}
