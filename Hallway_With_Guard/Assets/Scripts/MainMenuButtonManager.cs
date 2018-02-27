using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonManager : MonoBehaviour {

	// Use this for initialization
	/*void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
	public void PlayGameBtn(string Scene1)
	{
		SceneManager.LoadScene (Scene1);
	}

	public void ExitGameBTN()
	{
		Debug.Log ("Quit!");
		Application.Quit ();
	}
}
