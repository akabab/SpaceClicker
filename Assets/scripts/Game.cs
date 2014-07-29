using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

  // singleton
  private static Game m_Instance = null;
  public static Game Get()
  {
      if (m_Instance == null)
          m_Instance = (Game) FindObjectOfType(typeof(Game));
      return m_Instance;
  }

  // public Vector2 distance;
  public float curDistance;
  public float curProgress;

  public enum State {STOPED, PLAYING, PAUSED, ERR};
  public State _state;

  private Ship ship;

  private Level _level;

  // Use this for initialization
  void Start () {
    ship = (Ship) FindObjectOfType(typeof(Ship));
    _state = State.PLAYING;
    _level = Level.Get();
  }

  // Update is called once per frame
  void Update () {
    curDistance += ship.speed * Time.deltaTime;
    curProgress = (curDistance / Level.Get().distance) * 100;
  }

  void OnGUI () {
    DisplayDeviceOrientation();

    for (int i=0; i < _level.obstacles.Count; i++) {
      if (_level.obstacles[i].start < curProgress && curProgress < _level.obstacles[i].end) {
        GUILayout.Label("DANGER: " + _level.obstacles[i].type + " !!!");
      }
    }

  }

  void DisplayDeviceOrientation () {
    GUILayout.Label("Orientation: " + Screen.orientation);
    GUILayout.Label("Device Orientation: " + Input.deviceOrientation);
  }
}
