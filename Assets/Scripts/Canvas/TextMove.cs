using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class TextMove : MonoBehaviour
{
    public GameObject _ScorePlayer1, _ScorePlayer2, WinLosePlayer;
    public Text _Player1WinTxt, _Player2WinTxt;
    int _ScreenHeight, _ScreenWidth;
    public static TextMove _Trans;
    // Use this for initialization
    private void Awake()
    {
        _Trans = this;
    }
    void Start()
    {
        _ScreenHeight = Screen.height;
        _ScreenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        _CheckGameStatus();
    }
    void _CheckGameStatus() // kiem tra scored để hiện text score;
    {
        _ScorePlayer1.GetComponent<TextMesh>().text = GameManager._ScorePlayer1.ToString();
        _ScorePlayer2.GetComponent<TextMesh>().text = GameManager._ScorePlayer2.ToString();
    }
    public void _Player1Win()
    {
        WinLosePlayer.gameObject.SetActive(true);
        _Player1WinTxt.text = "You Win";
        _Player2WinTxt.text = "You Lose";
        WinLosePlayer.transform.DOMoveX(370 * _ScreenWidth / 720, 0.5f);
        StartCoroutine(WinLoseMoveOut());
    }
    public void _Player2Win()
    {
        WinLosePlayer.gameObject.SetActive(true);
        _Player1WinTxt.text = "You Lose";
        _Player2WinTxt.text = "You Win ";
        WinLosePlayer.transform.DOMoveX(370 * _ScreenWidth / 720, 0.5f);
        StartCoroutine(WinLoseMoveOut());
    }
   IEnumerator WinLoseMoveOut()
    {
            yield return new WaitForSeconds(1.0f);
            WinLosePlayer.transform.DOMoveX(-370 * _ScreenWidth / 720, 0.5f);
    }

}
