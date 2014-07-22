using UnityEngine;
using System.Collections;

// [ExecuteInEditMode]
public class Booster : MonoBehaviour {

  public float upZone;
  public float upZoneMin;
  public float criticZone;
  public float inc;
  public float dec;
  public float cur;
  public enum State {SAFE, UP, CRITIC};
  public State state;

  public struct Init {
    public float upZone;
    public float criticZone;
    public float inc;
    public float dec;
  }
  public Init _init;


  private Vector2 _upRange;
  private Vector2 _criticalRange;



  private float t;
  public float delayToUp;

  public Texture boosterTexture;
  //private Color[] col = {Color.cyan, Color.blue, Color.red};

  public Rect barRect;// = new Rect(800, 400, 20, 200);
  public Color[] barColors;

  private Ship _ship;

  void Start () {
    Initialize();
    _ship = gameObject.GetComponent<Ship>();
    cur = 0f;
    state = State.SAFE;
  }

  private void Initialize () {
    _init.upZone = upZone;
    _init.criticZone = criticZone;
    _init.inc = inc;
    _init.dec = dec;
  }


  void Update () {

    state = getState();

    cur -= dec * Time.deltaTime;
    if (cur > 100f) cur = 100f;
    if (cur < 0f) cur = 0f;

    if (state == State.UP) {
      t += Time.deltaTime;
    }
    else {
      t = 0f;
    }

    //UPGRADE
    if (_ship.boost <= _ship.maxBoost && t >= delayToUp) {
      _ship.boost += 1;
      cur = 0f;
    }

    //Up Zone
    upZone = (((upZoneMin - _init.upZone) / _ship.maxBoost) * _ship.boost + _init.upZone) * (1); //+ bonusP / 100

    _criticalRange = new Vector2(100f - criticZone, 100f);
    _upRange = new Vector2(100f - criticZone - upZone, 100f - criticZone);
  }

  void OnGUI () {
    drawBoostBar();
  }

  void OnMouseDown () {
    cur += inc;
  }

  public State getState () {
    if (cur >= _criticalRange.x)
      return State.CRITIC;
    else if (cur >= _upRange.x && cur < _upRange.y)
      return State.UP;
    else
      return State.SAFE;
  }

  public void drawBoostBar () {

    GUI.BeginGroup(barRect);

    //Background
    GUI.color = barColors[0];
    GUI.DrawTexture(new Rect(0, 0, barRect.width, barRect.height), boosterTexture);
    GUI.color = barColors[1];
    GUI.DrawTexture(new Rect(0, 0, barRect.width, barRect.height * ((upZone + criticZone) / 100f)), boosterTexture);
    GUI.color = barColors[2];
    GUI.DrawTexture(new Rect(0, 0, barRect.width, barRect.height * (criticZone / 100f)), boosterTexture);

    //Cursor
    GUI.color = barColors[(int) state] * 0.2f;
    GUI.DrawTexture(new Rect(0, barRect.height - (cur / 100f) * barRect.height, barRect.width, barRect.height), boosterTexture);

    GUI.EndGroup();

    GUI.color = Color.white;
    GUI.Label(new Rect(barRect.x, barRect.y - 20, 100, 20), "Boost: " + _ship.boost);
  }
}
