using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.Media.AVProVideo;

public class sortPOS : MonoBehaviour 
{
	private List<GameObject> markers = new List<GameObject>();
	public MediaPlayer sound;
	int i = 0;

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
			OnOpenVideoFile ();
			sound.Control.Play ();
		}
			
	}

	public void OnVideoEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode)
	{
		switch (et)
		{
		case MediaPlayerEvent.EventType.ReadyToPlay:
			break;
		case MediaPlayerEvent.EventType.Started:
			break;
		case MediaPlayerEvent.EventType.FirstFrameReady:
			break;
		case MediaPlayerEvent.EventType.FinishedPlaying:
			OnOpenVideoFile ();
			break;
		}
		//Debug.Log("Event: " + et.ToString());
	}

	public void OnOpenVideoFile()
	{
		if (i < 8) {
			this.GetComponent<DisplayUGUI> ()._mediaPlayer = markers [i].GetComponent<MediaPlayer> ();
			markers [i].GetComponent<MediaPlayer> ().Events.AddListener (OnVideoEvent);
			markers [i].GetComponent<MediaPlayer> ().Control.Play ();
			i++;
		}
	}
}	