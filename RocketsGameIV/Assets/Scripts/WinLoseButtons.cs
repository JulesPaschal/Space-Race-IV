using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class WinLoseButtons : MonoBehaviour
{
	public GameObject WinUI;
	public GameObject LoseUI;
	public int CurrentLevel;
    // Start is called before the first frame update
    void Start()
    {
    	WinUI.SetActive(false);
    	LoseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextRace(){
    	if (CurrentLevel == 1){
    		SceneManager.LoadScene("Level2");
    	}
    	if(CurrentLevel == 2){
    		SceneManager.LoadScene("Level3");
    	}
    	if (CurrentLevel == 3){
    		SceneManager.LoadScene("Credits");
    	}
    }
}
