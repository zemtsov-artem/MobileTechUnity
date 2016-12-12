using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private bool ballIsActive;
	private Vector3 ballStartPosition;
	private Vector2 ballInitialForce;
	public Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		ballInitialForce = 
			new Vector2 (400.0f, Random.Range(-1.0f, 1.0f) > 0 ? 300.0f : -300.0f);
		ballIsActive = false;
		ballStartPosition = transform.position;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			BallStart();
		}
		if ((transform.position.x > 12)||(transform.position.x <- 12)) {
			BallFinish();
		}
	}

	void BallStart()	{
		if (!ballIsActive) {
			GetComponent<Rigidbody2D>().isKinematic = false;
			GetComponent<Rigidbody2D>().AddForce(ballInitialForce);
			ballIsActive = true;
		}
	}

	void BallFinish() {
		if (ballIsActive) {
			GetComponent<Rigidbody2D>().isKinematic = true;
			transform.position = ballStartPosition;
			ballIsActive = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		GetComponent<AudioSource>().Play();
	}
}
