using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Networking;

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
        SoundController.instance.ClickSound();
        _PanelChoosePlayer.gameObject.SetActive(true);
        _PanelChoosePlayer.transform.DOMove(new Vector3(360*Screen.width/720,640 * Screen.width / 720, 0), 0.5f);
        Logo.gameObject.SetActive(false);
        _1PlayerBtn.gameObject.SetActive(false);
        _2PlayerBtn.gameObject.SetActive(false);
        PlayerPrefs.SetString("GameMode", "1vs1");   
    }
    public void PlayervsBot()
    {
        SoundController.instance.ClickSound();
        _PanelChoosePlayer.gameObject.SetActive(true);
        _PanelChoosePlayer.transform.DOMove(new Vector3(360 * Screen.width / 720, 640 * Screen.width / 720, 0), 0.5f);
        Logo.gameObject.SetActive(false);
        _1PlayerBtn.gameObject.SetActive(false);
        _2PlayerBtn.gameObject.SetActive(false);
        PlayerPrefs.SetString("GameMode", "Bot");
    }
    public void MoreGamges()
    {
        Application.OpenURL("https://mmgame.asia/");
    }
    void _Tracking()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            int checkinstall = 0;

            string packageGame;
            string androidID;
            PlayerPrefs.SetInt("installGame", 0);

            if (PlayerPrefs.GetInt("installGame") == 0)
            {
                PlayerPrefs.SetInt("installGame", 1);
                checkinstall = 1;
            }

            androidID = SystemInfo.deviceUniqueIdentifier;
            androidID = androidID.Replace("-", "");

            androidID = "1245667";

            packageGame = Application.identifier;

            string Url1 = "https://track.mmgame.asia/?install=" + checkinstall + "&pkg=" + packageGame + "&did=" + androidID;
            string Url2 = "https://trackmm.mmgame.asia/?install=" + checkinstall + "&pkg=" + packageGame + "&did=" + androidID;

            UnityWebRequest request = UnityWebRequest.Get(Url1);

            UnityWebRequest request2 = UnityWebRequest.Get(Url2);


            request.Send();
            request2.Send();
            //UnityWebRequest www = UnityWebRequest.Get("http://www.my-server.com");
            //yield return www.SendWebRequest();

            //if (www.isNetworkError || www.isHttpError)
            //{
            //    Debug.Log(www.error);
            //}
            //else
            //{
            //    // Show results as text
            //    Debug.Log(www.downloadHandler.text);

            //    // Or retrieve results as binary data
            //    byte[] results = www.downloadHandler.data;
            //}


            //if (request.isDone)
            //    Debug.Log("ket noi dc link 1 roi: ");
            //else
            //    Debug.Log("ket noi link 1 fail: " + Url1);

        }
        else
        {
            Debug.Log("no Internet");
        }


    }
}
