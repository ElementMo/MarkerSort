using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortPOS : MonoBehaviour 
{
	private List<GameObject> markers = new List<GameObject>();

	// Use this for initialization
	void Start () {
		markers.Add(GameObject.Find("1"));
		markers.Add(GameObject.Find("2"));
		markers.Add(GameObject.Find("3"));
		markers.Add(GameObject.Find("4"));
		markers.Add(GameObject.Find("5"));
		markers.Add(GameObject.Find("6"));
		markers.Add(GameObject.Find("7"));
		markers.Add(GameObject.Find("8"));

		foreach (GameObject m in markers) {
			Debug.Log (m.name);
		}
		Debug.Log ("###############");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			markers.Sort (delegate(GameObject x, GameObject y) {
				return x.transform.position.x.CompareTo (y.transform.position.x);
			});
			foreach (GameObject m in markers) {
				Debug.Log (m.name);
			}
		}
	}
}