using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 *	We want the chapter developer to manually drag their page prefabs into these fields.
 */

public class ChapterMetaData : MonoBehaviour {

	public List<GameObject> pages;
	public GameObject initialPage;
	public GameObject finalPage;
	public int maxConcurrentPages;

}
