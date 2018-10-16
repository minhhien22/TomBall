using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameManager : MonoBehaviour
{

    public static GameManager _Trans;
    public GameObject _Ball, _Player2, Bot;
    public static int _ScorePlayer1, _ScorePlayer2, _Score1, _Score2; // Win/Lose vs Score
    public static bool _CheckWin, _CheckLose, _isScored; //Kiểm tra trạng thái ghi điểm,Kiểm tra trạng thai Lose,Đã ghi điểm hay chưa.
    public GameObject _ScoreLabelPlayer1, _ScoreLabelPlayer2, _YouWinPlayer1, _YouWinPlayer2, _YouLosePlayer1, _YouLosePlayer2;
    public Image _ReplayBtn;
    public Text _OnscreenScore1, _OnscreenScore2;
    public static int _RoungCount;
    public Text _RoundTxt, _BestTxt, _ScoreTxt, _RoundLastTxt;
    public GameObject _PanelLose;
    public static bool GameTracking,isPlayer1Win; // Biến kiểm tra trạng thái game để next qua stadium khác.Dùng trong trường hợp reload hoặc tỷ số chạm đến 7;
    // Use this for initialization
    private void Awake()
    {
        PlayerPrefs.SetString("BallMoveFrom", "Stadium");// khởi tạo giá trị BallMoveFrom để xác định ball vừa chạm player1-> Player2 hay không để giảm tóc độ của ball lại.
        _Trans = this;
    }
    void Start()
    {
        _Score1 = 0;
        _Score2 = 0;
        _RoungCount = 1;
        if (PlayerPrefs.GetString("GameMode") == "Bot")
        {
            _ScoreLabelPlayer2.gameObject.SetActive(false);
            Bot.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetString("GameMode") == "1vs1")
        {
            _Player2.gameObject.SetActive(true);
        }
        _isScored = false;
        _ScorePlayer1 = 0;
        _ScorePlayer2 = 0;
        Instantiate(_Ball, new Vector3(0, 0, -5), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        _OnscreenScore1.text = _Score1.ToString();
        _OnscreenScore2.text = _Score2.ToString();
        Scored();
    }
    void Scored() //ham kiem tra trang thai ghi diem.
    {
        if (_isScored)
        {
            if(isPlayer1Win && _ScorePlayer1 <3)
            {
              StartCoroutine(_CreateBall(new Vector3(0, 1,-5)));
            }
            else if(!isPlayer1Win && _ScorePlayer2 < 3)
            {
                StartCoroutine(_CreateBall(new Vector3(0, -1, -5)));
            }
            GameTracking = false;
        }
        if (_ScorePlayer1 == 3 && !GameTracking)
        {
            GameTracking = true;
            TextMove._Trans._Player1Win();
            _RoungCount++;
            NextMap();

        }
        else if (_ScorePlayer2 == 3)
        {
            if (PlayerPrefs.GetString("GameMode") == "Bot")
            {
                TextMove._Trans._Player2Win();
                _ScoreTxt.text = ":" + _Score1.ToString();
                _RoundLastTxt.text = ":" + _RoungCount.ToString();
                if (PlayerPrefs.GetInt("BestScore") < _Score1)
                {
                    PlayerPrefs.SetInt("BestScore", _Score1);
                }
                _BestTxt.text =":" +PlayerPrefs.GetInt("BestScore").ToString();
                _PanelLose.gameObject.SetActive(true);
                _PanelLose.transform.DOMoveY(640 * Screen.height / 1280, 0.5f);
                GameTracking = true;
            }
            else if (PlayerPrefs.GetString("GameMode") == "1vs1")
            {
                TextMove._Trans._Player2Win();
                GameTracking = true;
                NextMap();
            }
        }
    }
    public void _BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator _CreateBall(Vector3 _BallPos) //Ham tao ball moi
    {
        if (_isScored)
        {
            _isScored = false;
            yield return new WaitForSeconds(1.0f);
            Instantiate(_Ball, _BallPos, Quaternion.identity);
            PlayerPrefs.SetString("isBall", "Live");
        }
    }
    public void _Replay()
    {
        SoundController.instance.ClickSound();
        _PanelLose.transform.DOMoveY(-1280 * Screen.height / 1280, 0.5f);
        _ScorePlayer1 = 0;
        _ScorePlayer2 = 0;
        _Score1 = 0;
        _RoungCount = 0;
        GameTracking = false;
        BackGroundControl._Trans.CreateStadium();
        BackGroundControl._Trans.MoveIn();
        BackGroundControl._Trans.MoveOut();
        BotControl.FaceID = Random.Range(0, 6);
        BallControl.i = Random.Range(0, 5);
    }
    private void NextMap()
    {
        _ScorePlayer1 = 0;
        _ScorePlayer2 = 0;
        BackGroundControl._Trans.CreateStadium();
        BackGroundControl._Trans.MoveIn();
        BackGroundControl._Trans.MoveOut();
        BotControl.FaceID = Random.Range(0, 6);
        _RoundTxt.text = "Round: " + _RoungCount.ToString();
        _RoundTxt.gameObject.SetActive(true);
        StartCoroutine(_ActiveRound());
        BallControl.i = Random.Range(0, 5);
        GameTracking = false;
    }
    void Play1vs1()
    {
        SoundController.instance.ClickSound();
        SceneManager.LoadScene(1);
    }
    public void MoreGameBtn()
    {
        Application.OpenURL("https://mmgame.asia/");
    }
    private IEnumerator _ActiveRound()
    {
        yield return new WaitForSeconds(1.0f);
        _RoundTxt.gameObject.SetActive(false);
    }
}

