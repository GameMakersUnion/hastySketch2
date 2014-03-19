using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnLevels : MonoBehaviour {

	Queue<AsyncOperation> pendingLoads = new Queue<AsyncOperation>();
	List<GameObject> chapters = new List<GameObject>();
	GameObject levelCamera;
	public Transform player;
	// Use this for initialization
	void Start () {
		Debug.Log (transform.parent);
		levelCamera = GameObject.Find("levelCamera");
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.P)) {

			StartCoroutine("loadChapter");
			print ("Load Called");
		}
		if (pendingLoads.Count != 0 && pendingLoads.Peek()!= null) {
			print("quack");
			if (pendingLoads.Peek ().isDone) {
				print("quack");
				pendingLoads.Dequeue();
				foreach(GameObject g in GameObject.FindGameObjectsWithTag("Chapter")){
					if (!chapters.Contains(g)) chapters.Add(g);
					g.transform.Translate(new Vector3(0,0,200));
					GameObject firstPage = g.GetComponent<ChapterMetaData>().initialPage;
					PageMetaData firstPageData = firstPage.GetComponent<PageMetaData>();
					levelCamera.transform.position = firstPageData.initialCamera.position;
					Instantiate(player,firstPageData.playerStart.position, Quaternion.identity);

				}						
			}
		}
	}

	IEnumerator loadChapter() {
		Debug.Log("Loading Started");
		AsyncOperation aOp = Application.LoadLevelAdditiveAsync ("Chapter1");
		yield return aOp;
		pendingLoads.Enqueue(aOp);
		Debug.Log("Loading complete");
	}
}
