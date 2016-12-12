using UnityEngine;
using System.Collections;

public class PlayerPlatform : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 curScreenPoint;
	private float Yboundary = 5.0f;
	
	void Update() {
		if(Input.touchCount == 1) {
			Touch touch = Input.touches[0];

			switch(touch.phase)	{
			case TouchPhase.Began:
				OnMouseDown();
				break;
			case TouchPhase.Canceled:
			case TouchPhase.Ended:
				break;
			case TouchPhase.Moved:
				OnMouseDrag();
				break;
			default:
				break;
			}
		}
	}
	
	void OnMouseDown() {
		Vector3 position = Vector3.zero;
		
		if(Input.touchCount > 0) {
			position = new Vector3(Input.touches[0].position.x,
			                       Input.touches[0].position.y, 0);
		} 
		else {
			position = Input.mousePosition;
		}
		
		screenPoint = Camera.main.WorldToScreenPoint(transform.position);
		offset = transform.position - Camera.main.ScreenToWorldPoint(
			new Vector3(screenPoint.x, position.y, screenPoint.z));
	}
	
	void OnMouseDrag() {
		Vector3 position = Vector3.zero;
		
		if(Input.touchCount > 0) {
			position = new Vector3(Input.touches[0].position.x, 
			                       Input.touches[0].position.y, 0);
		}
		else {
			position = Input.mousePosition;
		}
		curScreenPoint = new Vector3(screenPoint.x, position.y, screenPoint.z);
		transform.position = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		
		if (transform.position.y < -Yboundary + transform.localScale.y / 2) {
			transform.position = new Vector3 (transform.position.x,
			                                  -Yboundary + transform.localScale.y / 2,
			                                  transform.position.z);
		} 
		if (transform.position.y > Yboundary - transform.localScale.y / 2) {
			transform.position = new Vector3(transform.position.x, 
			                                 Yboundary - transform.localScale.y / 2, 
			                                 transform.position.z);     
		}
	}
}
