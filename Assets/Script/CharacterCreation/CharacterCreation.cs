using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour {
	public GameObject[] characters;
	public int characterId;
    public UIInput nameInput;

	private GameObject[] chaObjs;
	private int length;

	// Use this for initialization
	void Start () {
		length = characters.Length;
		chaObjs = new GameObject[length];
		for(int i=0; i<length;i++){
			//实例化对象
			chaObjs[i] = GameObject.Instantiate (characters [i], transform.position, transform.rotation) as GameObject;
		}
		UpdateCha ();
	}

	//显示角色
	void UpdateCha(){
		for(int i= 0; i<length; i++){
			if (i == characterId) {
				chaObjs [i].SetActive (true);
			} else {
				chaObjs [i].SetActive (false);
			}
		}
	}

	public void Next(){
		characterId++;
//		characterId %= length;
		if(characterId>length-1){
			characterId = 0;
		}
		UpdateCha ();
	}

	public void Prev(){
		characterId--;
		if(characterId<0){
			characterId = length-1;
		}
		UpdateCha ();
	}

    public void OkBtn()
    {
        PlayerPrefs.SetInt("selectCharacterIndex", characterId);
        PlayerPrefs.SetString("characterName", nameInput.value);

        Debug.Log(PlayerPrefs.GetInt("selectCharacterIndex")
            + "   " + PlayerPrefs.GetString("characterName"));
    }

}
