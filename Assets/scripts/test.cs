using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
  int[] t = new int[5] {0, 1, 2, 3, 4};
	 string test = "hello";


   foreach (int k in t)
    Debug.Log(k);

   Test(t, test);

   foreach (int k in t)
    Debug.Log(k);

    Debug.Log(test);

	}

	// Update is called once per frame
	void Update () {

	}

  void Test (int[] tt, string ww) {
    for (int i=0; i < tt.Length; i++) {
      tt[i] = (int) (Random.value * 10);
    }

    ww = "M" + ww.Substring(1);
  }
}
