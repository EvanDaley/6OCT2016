using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextSwitcher : MonoBehaviour {
	
	public Canvas Canvas;
	public GameObject TextPrefab;
	public PlainText[] plainTextList;
	private float timeOfLoad; // the time in game seconds that this level loaded up at

	void Start()
	{
		timeOfLoad = Time.time;
	}

	void Update () 
	{
		// if time is passed the startTime of any objects and they haven't been created, create them and remove them from the list
		for(int i = 0; i < plainTextList.Length; i++)
		{
			if (plainTextList [i] .show == true)
			{
				if (Time.time > (plainTextList[i].startTime + timeOfLoad))
				{
					GameObject textInstance = GameObject.Instantiate (TextPrefab, Vector3.zero, transform.rotation) as GameObject;
					textInstance.transform.SetParent (Canvas.transform, false);

					DieAfterTime deathTimer = textInstance.GetComponent<DieAfterTime> ();
					deathTimer.SetDeathTime (plainTextList[i].endTime + timeOfLoad);

					Text UIText = textInstance.GetComponent<Text> ();
					UIText.text = plainTextList[i].text;

					plainTextList [i].show = false;
				}
			}
		}
	}
}

[System.Serializable]
public class PlainText
{
	// position
	// scroll effect

	public bool show = true;

	public string text = "";
	public float startTime = 0f;
	public float endTime = 0f;
}
