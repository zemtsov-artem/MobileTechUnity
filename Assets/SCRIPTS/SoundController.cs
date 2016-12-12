using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
	void Start () {
		GetComponent<AudioSource>().Play ();
	}
}
