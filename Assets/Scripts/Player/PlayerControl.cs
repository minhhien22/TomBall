using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Vector2 DirPlayertoBall;// Vector hướng từ player -> ball đẻ tính hướng đi của ball.
    public static Vector3 _BallPosition; // vị trí của ball khi va chạm với player;
    private List<Vector2> _PlayerPositionList; // List lưu lại vị trí của player để tính vector cho ball khi player va chạm với ball.
    private float _Force;
    public static bool _isColWithPlayer; //kiểm tra ball có va chạm với player ko;
    Vector3 _Mousepos;
    bool isClick;
    public SpriteRenderer _PlayerFace;
    public List<Sprite> _PlayerFaceImage;
    private int FaceID;
    // Use this for initialization
    void Start()
    {
        FaceID = (int)PanelChoosePlayer.PlayersType;
        SetPlayerFace();
        _PlayerPositionList = new List<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {
        //if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 0)
        //{
        //    transform.position = new Vector3(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -2.0f, 2.21f),
        //                                               Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -4.65f, 0.0f), 0);
        //}
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.17f, 2.17f), Mathf.Clamp(transform.position.y, -3.7f, 0.0f), 0);

        if (isClick)
        {
            PlayerPositionControl();
        }
    }
    private void OnCollisionEnter2D(Collision2D _Col)
    {
        if (_Col.gameObject.tag == "Ball")
        {

            _isColWithPlayer = true;
            //_Col.gameObject.GetComponent<Rigidbody2D>().velocity = _DirectionPlayertoBall(transform.position, _Col.transform.position);
            _BallPosition = _Col.gameObject.transform.position;
            _Col.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            _Col.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            _Col.gameObject.GetComponent<Rigidbody2D>().AddForce(_DirectionPlayertoBall(transform.position, _Col.transform.position) * 150, ForceMode2D.Impulse);
        }
        //PlayerPrefs.SetString("BallMoveFrom", "Player1");
        // Debug.Log(PlayerPrefs.GetString("BallMoveFrom"));
    }
    private Vector2 _DirectionPlayertoBall(Vector2 PlayerPostion, Vector2 BallPosition)
    {
        Vector2 Direction = BallPosition - PlayerPostion;
        return Direction;
    }
    public void OnTouchDown()
    {
        isClick = true;
    }
    public void OnTouchUp()
    {
        isClick = false;
    }
    public void PlayerPositionControl()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                _Mousepos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                if (_Mousepos.y < 0)
                {
                    transform.position = new Vector3(Mathf.Clamp(_Mousepos.x, -2.17f, 2.17f), Mathf.Clamp(_Mousepos.y, -3.7f, 0.0f), 0.0f);
                }
            }
            else if (Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                _Mousepos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                if (_Mousepos.y < 0)
                {
                    transform.position = new Vector3(Mathf.Clamp(_Mousepos.x, -2.17f, 2.17f), Mathf.Clamp(_Mousepos.y, -3.7f, 0.0f), 0.0f);
                }
            }
        }
    }
    void BallColPlayer() // kiểm tra trạng thái ball va cham voi player để giảm tốc độ của ball lại;
    {

    }
    private void SetPlayerFace()
    {
        _PlayerFace.sprite = _PlayerFaceImage[FaceID];
    }
}

