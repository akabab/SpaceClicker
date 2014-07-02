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

  public Vector2 distance;
  public float curDistance;
  public float curProgress;

  private float deltaDist;

  private Ship ship;

  // Use this for initialization
  void Start () {
    ship = (Ship) FindObjectOfType(typeof(Ship));
    deltaDist = distance.y - distance.x;
  }

  // Update is called once per frame
  void Update () {
    curDistance += ship.speed * Time.deltaTime;
    curProgress = (curDistance / distance.y) * 100;
  }
}
