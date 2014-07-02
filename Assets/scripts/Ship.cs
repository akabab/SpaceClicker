using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

  public int score;
  public int speed;

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }

  void OnMouseUp () {
    score += 1;
  }
}
