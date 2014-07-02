using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Interface : MonoBehaviour {

  public Rect[] rect;
  public Texture[] t;

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {
    rect[0] = new Rect(0, 0, Screen.width * 0.5f, Screen.height * 0.33f);
  }

  void OnGUI () {

    // GUIAspectRatio.Get().SetAspectRatio();

    // GUISizer.BeginGUI();
    GUI.Box(rect[0], "Distance: " + Game.Get().curDistance.ToString("F0") + " ly");
    GUI.Box(new Rect(rect[0].x, rect[0].y + 20, rect[0].width, rect[0].height), "Progress: " + Game.Get().curProgress.ToString("F1") + "%");

    displayProgressBar();
    // GUISizer.EndGUI();
  }

  public float margin = 20f;

  void displayProgressBar() {

    //progress bar
    Rect progressBarRect = new Rect(margin, Screen.height - 30, Screen.width - (2 * margin), 10);
    GUI.DrawTexture(progressBarRect, t[0]);
    //pbar cursor
    float cursorPos = margin + (Game.Get().curProgress / 100 * progressBarRect.width);
    GUI.DrawTexture(new Rect(cursorPos - 20, Screen.height - 50, 50, 35), t[1]);

  }
}
