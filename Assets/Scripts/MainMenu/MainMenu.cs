using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public GameObject _1PlayerBtn, _2PlayerBtn,Logo,_PanelChoosePlayer;
   // public static string _PlayerNames;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  public  void Play1vs1()
    {
        _PanelChoosePlayer.gameObject.SetActive(true);
        _PanelChoosePlayer.transform.DOMove(new Vector3(360*Screen.width/720,640 * Screen.width / 720, 0), 0.5f);
        Logo.gameObject.SetActive(false);
        _1PlayerBtn.gameObject.SetActive(false);
        _2PlayerBtn.gameObject.SetActive(false);
        PlayerPrefs.SetString("GameMode", "1vs1");   
    }
    public void PlayervsBot()
    {
        _PanelChoosePlayer.gameObject.SetActive(true);
        _PanelChoosePlayer.transform.DOMove(new Vector3(360 * Screen.width / 720, 640 * Screen.width / 720, 0), 0.5f);
        Logo.gameObject.SetActive(false);
        _1PlayerBtn.gameObject.SetActive(false);
        _2PlayerBtn.gameObject.SetActive(false);
        PlayerPrefs.SetString("GameMode", "Bot");
    }
    
}
