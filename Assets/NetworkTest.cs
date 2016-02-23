using UnityEngine;
using System.Collections;

public class NetworkTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void request(){
		NetworkManager.I.Request (TestModel.URL, (TestModel ret) => {
			Debug.Log (ret);
			
		});

	}
}
