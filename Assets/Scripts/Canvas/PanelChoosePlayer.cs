using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PanelChoosePlayer : MonoBehaviour {
    public Image _PlayerList;
    public List<Sprite> _PlayerImg;
    public Text _PlayerName;
    private int i;
    public static TYPE_PLAYERNAMES PlayersType,Player2Type;
    public GameObject _NextBtn, PreviousBtn,Player2ChoosePanel;

	// Use this for initialization
	void Start () {
        //_PlayerImg = new List<Sprite>();
        i = 0;
        _PlayerList.sprite = _PlayerImg[i];
        Debug.Log(_PlayerImg.Count);
	}
    public enum TYPE_PLAYERNAMES
    {
        LionelMessi=0,
        CristianoRonaldo,
        LuisSuarez,
        MohamedSalah,
        SergioAguero,
        Imbrahimovic

    };
   public static  string[] Names = { "Lionel Messi", "Cristiano Ronaldo", "Luis Suarez", "Mohamed Salah", "Sergio Aguero", "Zalatan Ibrahimovic" };
	// Update is called once per frame
	void Update () {
        if(i==0)
        {
            PreviousBtn.gameObject.SetActive(false);
        }
        if(i==5)
        {
            _NextBtn.gameObject.SetActive(false);
        }
        if(i>0 && i<5)
        {
            PreviousBtn.gameObject.SetActive(true);
            _NextBtn.gameObject.SetActive(true);
        }

		
	}
  public   void NextPlayerBtn()
    {
        SoundController.instance.ClickSound();
        if (i<_PlayerImg.Count)
        {
            i++;
            _PlayerList.sprite = _PlayerImg[i];
            _PlayerName.text = Names[i];
        }
        else
        {
            return;
        }
    }
    public void _PreviousPlayer()
    {
        SoundController.instance.ClickSound();
        if (i > 0)
        {
            i--;
            _PlayerList.sprite = _PlayerImg[i];
            _PlayerName.text = Names[i];
        }
        else
        {
            return;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void ChoosePlayer()
    {
        SoundController.instance.ClickSound();
        PlayersType = (TYPE_PLAYERNAMES)i;
        PlayerPrefs.SetString("PlayerNames", Names[i]);
        if(PlayerPrefs.GetString("GameMode")== "Bot")
        {
            SceneManager.LoadScene(1);
        }
        if(PlayerPrefs.GetString("GameMode")=="1vs1")
        {
            Player2ChoosePanel.gameObject.SetActive(true);
            Player2ChoosePanel.transform.DOMove(new Vector3(360 * Screen.width / 720, 640 * Screen.width / 720, 0), 0.555f);
            transform.DOMove(new Vector3(-360 * Screen.width / 720, 640 * Screen.width / 720, 0), 0.55f);
        }
    }
    public void Player1Choose()
    {
        PlayersType = (TYPE_PLAYERNAMES)i;
        PlayerPrefs.SetString("Player1Names", Names[i]);
    }
    public void Player2Choose()
    {
        Player2Type = (TYPE_PLAYERNAMES)i;
        PlayerPrefs.SetString("Player2Names", Names[i]);
        SceneManager.LoadScene(1);
    }
}
