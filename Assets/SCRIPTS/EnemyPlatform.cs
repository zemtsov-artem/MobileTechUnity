using UnityEngine;
using System.Collections;

public class EnemyPlatform : MonoBehaviour {
	public GameObject ballObject;
	private float Yboundary = 5.0f;
	private float Speed = 0.08f;
	
	void Update () {
		float Ydelta = ballObject.transform.position.y - transform.position.y;
		if (Mathf.Abs(Ydelta) > 0.5)
			transform.position = new Vector3 (transform.position.x, 
			                                  transform.position.y +
			                                  ((Ydelta > 0) ? Speed : -Speed));
		
		if (transform.position.y < -Yboundary + transform.localScale.y / 2) {
			transform.position = new Vector3 (transform.position.x, -Yboundary + 
			                                  transform.localScale.y / 2, transform.position.z);
		} 
		if (transform.position.y > Yboundary - transform.localScale.y / 2) {
			transform.position = new Vector3(transform.position.x, Yboundary - 
			                                 transform.localScale.y / 2, transform.position.z);     
		}
	}
}
