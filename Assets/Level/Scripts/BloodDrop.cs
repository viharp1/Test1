using UnityEngine;
using System.Collections;

public class BloodDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, .15f);
	}
}
