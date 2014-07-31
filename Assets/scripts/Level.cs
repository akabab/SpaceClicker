using UnityEngine;
using System.Text;
using System.IO;
using SimpleJSON;
using System.Collections.Generic;

public class Level : MonoBehaviour {

  private static Level m_Instance = null;
  public static Level Get() {
      if (m_Instance == null)
          m_Instance = (Level) FindObjectOfType(typeof(Level));
      return m_Instance;
  }

  public string fileName;
  private string line;
  private string file;
  public JSONNode node;

  public int level;
  public string lvlName;
  public int distance;

  [System.Serializable]
  public class Obst {
    public string type;
    public int start;
    public int end;
  }
  public List<Obst> obstacles = new List<Obst>();


  void Start () {
    StreamReader theReader = new StreamReader(fileName, Encoding.Default);

    using (theReader) {
      do {
          line = theReader.ReadLine();
          file += line;
      }
      while (line != null);
    }

    ParseLvl();
  }

  void ParseLvl () {
    node = JSONNode.Parse(file);

    JSONNode _lvl = node["level"][level];

    lvlName = _lvl["name"];
    distance = _lvl["distance"].AsInt;

    int obstCount = _lvl["obstacles"].Count;
    for (int i=0; i < obstCount; i++) {
      Obst o = new Obst();
      o.type  = _lvl["obstacles"][i]["type"];
      o.start = _lvl["obstacles"][i]["start"].AsInt;
      o.end   = _lvl["obstacles"][i]["end"].AsInt;
      obstacles.Add(o);
    }
  }

}