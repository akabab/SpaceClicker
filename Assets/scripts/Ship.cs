using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

  public int score;
  public float minSpeed;
  public float speed;
  public float delayBeforeDecay;

  private Transform flames;
  private float t;

  public int boost;
  public int maxBoost;

  // Use this for initialization
  void Start () {
    flames = transform.Find("Flames");
    t = delayBeforeDecay;
  }

  // Update is called once per frame
  void Update () {
    speed = minSpeed + boost;

    flames.GetComponent<Animator>().speed = speed / 10f; //


    t -= Time.deltaTime;
    if (t <= 0f) {
      speed -= Time.deltaTime;
    }
  }
}
