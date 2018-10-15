using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    public static GameManager _Trans;
    public GameObject _Ball ,_Player2, Bot;
    public static int _ScorePlayer1, _ScorePlayer2,_Score1,_Score2; // Win/Lose vs Score
    public static bool _CheckWin, _CheckLose, _isScored; //Kiểm tra trạng thái ghi điểm,Kiểm tra trạng thai Lose,Đã ghi điểm hay chưa.
    public GameObject _ScoreLabelPlayer1,_ScoreLabelPlayer2,_YouWinPlayer1,_YouWinPlayer2,_YouLosePlayer1,_YouLosePlayer2;
    public Image _ReplayBtn;
    public Text _OnscreenScore1, _OnscreenScore2;
    public static bool GameTracking; // Biến kiểm tra trạng thái game để next qua stadium khác.Dùng trong trường hợp reload hoặc tỷ số chạm đến 7;
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
       if(PlayerPrefs.GetString("GameMode")=="Bot")
        {
            _ScoreLabelPlayer2.gameObject.SetActive(false);
            Bot.gameObject.SetActive(true);
        }
       if(PlayerPrefs.GetString("GameMode") == "1vs1")
        {
            _Player2.gameObject.SetActive(true);
        }
        _isScored = false;
        _ScorePlayer1 = 0;
        _ScorePlayer2 = 0;
        Instantiate(_Ball, new Vector3(0, 0, 0), Quaternion.identity);
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
            if(_ScorePlayer1<3 && _ScorePlayer2 <3 && _isScored)
            {
             StartCoroutine(_CreateBall());
                GameTracking = false;
            }
             if(_ScorePlayer1==3 )
            {
                _ReplayBtn.gameObject.SetActive(true);  
            }
             else if (_ScorePlayer2==3)
            {
                _ReplayBtn.gameObject.SetActive(true); 
            }
        }
    IEnumerator _CreateBall() //Ham tao ball moi
    {
        if (_isScored)
        {
            _isScored = false;
            yield return new WaitForSeconds(1.0f);
            Instantiate(_Ball, new Vector3(0, 0, 0), Quaternion.identity);
            PlayerPrefs.SetString("isBall", "Live");
        }
    }
    public void _Replay()
    {
        _ReplayBtn.gameObject.SetActive(false);
        _ScorePlayer1 = 0;
        _ScorePlayer2 = 0;
        GameTracking = false;
        BackGroundControl._Trans.CreateStadium();
        BackGroundControl._Trans.MoveIn();
        BackGroundControl._Trans.MoveOut();
        BotControl.FaceID = Random.Range(0, 6);
    }
    void Play1vs1()
    {
        SceneManager.LoadScene(1);
        
    }
}

