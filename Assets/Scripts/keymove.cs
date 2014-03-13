using UnityEngine;
using System.Collections;

public class keymove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.A))
		   this.transform.Translate(new Vector3(1f,0f,0f));
		if (Input.GetKey (KeyCode.D))
			this.transform.Translate (new Vector3 (-1f, 0f, 0f));
	
	}
}
