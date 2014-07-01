using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

  // singleton
  private static Game m_Instance = null;
  public static Game Get()
  {
      if (m_Instance == null)
          m_Instance = (Game)FindObjectOfType(typeof(Game));
      return m_Instance;
  }

  public float distance;

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }
}
