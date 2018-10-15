using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BotControl : MonoBehaviour
{
    private GameObject _Ball;
    private bool _CheckBallPos, _Check; //Kiểm tra vi trí của ball có thuộc nửa phần trên ko.
    float i, _BallPosX, _BallPosY;
    float j;
    public GameObject _BotChild;
    public SpriteRenderer _PlayerFace;
    public List<Sprite> _PlayerFaceImage;
    public static int FaceID;

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        SetPlayerFace();
        if (PlayerPrefs.GetString("isBall") == "Live")
        {
            _Ball = GameObject.FindGameObjectWithTag("Ball");
            _BallPosX = _Ball.transform.position.x;
            _BallPosY = _Ball.transform.position.y;
        }
        if (BackGroundControl.i < 6)
        {
            if (_BallPosY > 0 && _BallPosY < 2.7f)
            {
                if (_BallPosX >= -2.0f && _BallPosX < 0)
                {
                    transform.DOMove(new Vector3(-1.33f, _BallPosY + 0.3f, 0), 0.5f);
                }
                else if (_BallPosX <= 2.0f && _BallPosX > 0)
                {
                    transform.DOMove(new Vector3(1.33f, _BallPosY + 0.3f, 0), 0.5f);
                }
            }

            else if (_BallPosY > 2.7f && _BallPosY < 3.3f)
            {
                if (_BallPosX < -2.0f)
                {
                    transform.DOMove(new Vector3(-1.05f, _BallPosY + 0.3f, 0), 0.5f);
                }
                else if (_BallPosX > 2.0f)
                {
                    transform.DOMove(new Vector3(1.05f, _BallPosY + 0.3f, 0), 0.5f);
                }
            }
            else if (_BallPosY > 3.3f)
            {
                if (_BallPosX < -2.0f)
                {
                    transform.DOMove(new Vector3(-1.05f, _BallPosY + 0.3f, 0), 0.5f);
                }
                else if (_BallPosX > 2.0f)
                {
                    transform.DOMove(new Vector3(1.06f, _BallPosY + 0.3f, 0), 0.5f);
                }
            }
        }
        else if (BackGroundControl.i >= 6)
        {
            if (_BallPosY > 0 && _BallPosY < 1.0f)
            {
                if (_BallPosX < 0 && _BallPosX > -2.0f)  //lệch trái
                {
                    transform.DOMove(new Vector3(-1.16f, _BallPosY + 0.2f, 0), 0.5f);
                }
                else if (_BallPosY > 0 && _BallPosY < 2.0f)
                {
                    transform.DOMove(new Vector3(1.16f, _BallPosY + 0.2f, 0), 0.5f);
                }
            }
            else if (_BallPosY > 1 && _BallPosY < 2.5f)
            {
                if (_BallPosX < 0 && _BallPosX > -2.0f)  //lệch trái
                {
                    transform.DOMove(new Vector3(-0.84f, _BallPosY + 0.2f, 0), 0.5f);
                }
                else if (_BallPosY > 0 && _BallPosY < 2.0f) // lệch phải
                {
                    transform.DOMove(new Vector3(0.84f, _BallPosY + 0.2f, 0), 0.5f);
                }
            }
            else if (_BallPosY > 2.5f && _BallPosY < 3.3f)
                {
                if (_BallPosX < 0 && _BallPosX > -2.0f)  //lệch trái
                {
                    transform.DOMove(new Vector3(-0.32f, _BallPosY + 0.2f, 0), 0.5f);
                }
                else if (_BallPosY > 0 && _BallPosY < 2.0f) // lệch phải
                {
                    transform.DOMove(new Vector3(0.32f, _BallPosY + 0.2f, 0), 0.5f);
                }
            }
        }
    
    transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.0f, 2.0f), Mathf.Clamp(transform.position.y, 0.0f, 3.4f), 0);
        //if (PlayerPrefs.GetString("isBall") == "Live")
        //{
        //    if (_BallPosY < 0)   //Ball ở phần sân khách.
        //    {
        //        _CheckBallPos = true;
        //        // BotMoveinNormalState();
        //    }
        //    else //Ball ở sân nhà.
        //    {
        //        //if (!BallControl._CheckStadiumCol)  //kiểm tra ball có bị dính với tường không? nếu dính thì lùi lại k  ép ball vào tường.
        //        //{
        //            transform.DOMove(new Vector3(_BallPosX , _BallPosY+0.5f, 0), Random.Range(0.5f, 0.7f));
        //            // _CheckBallPos = false;
        //      //  }
        // else
        //{
        //if (!_CheckBallPos)
        //  {
        // _CheckBallPos = true;
        //  transform.DOMove(new Vector3(transform.position.x, transform.position.y + 0.5f, 0), 1.0f);
        // _Ball.GetComponent<Rigidbody2D>().AddForce(_DirectionPlayertoBall(transform.position, _Ball.transform.position) * 200, ForceMode2D.Impulse);
        // }
        // }
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.17f, 2.17f), Mathf.Clamp(transform.position.y, 0.0f, 3.47f), 0);
        // StartCoroutine(BotPlay());
    }
//IEnumerator BotPlay() //Điều khiển Bot 
// {
//     while (_CheckBallPos)
//     {
//             yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
//             transform.DOMove(_Ball.transform.position, Random.Range(1.0f, 1.5f));
//             transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.17f, 2.17f), Mathf.Clamp(transform.position.y, 0.0f, 3.47f), 0);
//         _CheckBallPos = false;
//     }
// }


void Move() // di chuyen Bot  khi ball ở sân nhà.
{
    i = Random.Range(-2.17f, 2.17f);
    j = Random.Range(0.0f, 3.47f);
    transform.DOMove(new Vector3(i, 3.0f, 0), 0.8f);
}
void BotMoveinNormalState()
{
    _BotChild.GetComponent<Animator>().Play("Player2-Stay");
}
private Vector2 _DirectionPlayertoBall(Vector2 PlayerPostion, Vector2 BallPosition)
{
    Vector2 Direction = BallPosition - PlayerPostion;
    return Direction;
}
private void OnCollisionEnter2D(Collision2D _Col)
{
    if (_Col.gameObject.tag == "Ball")
    {

        if (BackGroundControl.i < 6)
        {
            if (_BallPosY > 0 && _BallPosY < 2.9f && _BallPosX > -1.3f && _BallPosX < 1.3f)
            {
                _Col.gameObject.GetComponent<Rigidbody2D>().AddForce(_DirectionPlayertoBall(transform.position, _Col.transform.position) * 50, ForceMode2D.Impulse);
            }
            else
            {
                _Col.gameObject.GetComponent<Rigidbody2D>().AddForce(_DirectionPlayertoBall(transform.position, _Col.transform.position) * 50, ForceMode2D.Impulse);
            }
        }
        else
        {
            if (_BallPosY > 0 && _BallPosY < 2.9f && _BallPosX > -1.0f && _BallPosX < 1.0f)
            {
                _Col.gameObject.GetComponent<Rigidbody2D>().AddForce(_DirectionPlayertoBall(transform.position, _Col.transform.position) * 50, ForceMode2D.Impulse);
            }
            else
            {
                _Col.gameObject.GetComponent<Rigidbody2D>().AddForce(_DirectionPlayertoBall(transform.position, _Col.transform.position) * 50, ForceMode2D.Impulse);
            }
            _Check = true;



        }
        if (BallControl._CheckStadiumCol)
        {
            Debug.Log(BallControl._CheckStadiumCol);
            // _Col.gameObject.transform.DOMove(new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, 0), 0.5f);
            // _Ball.GetComponent<Rigidbody2D>().AddForce(_DirectionPlayertoBall(transform.position, _Ball.transform.position) , ForceMode2D.Impulse);
        }
        //if (_Col.gameObject.transform.position.x < 2.0f && _Col.gameObject.transform.position.x > -2.0f && _Col.gameObject.transform.position.y > 0.0f && _Col.gameObject.transform.position.x < 3.3f) ;
        //if (BallControl._CheckStadiumCol)
        //{
        //    _Col.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        //    _Col.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        //    _Col.gameObject.GetComponent<Rigidbody2D>().AddForce(_DirectionPlayertoBall(transform.position, _Col.transform.position) * 100, ForceMode2D.Impulse);
        //}
        //        if (_Col.gameObject.transform.position.y >= 3.3f)
        //        {
        //            transform.DOMove(new Vector3(_BallPosX, _BallPosY - 0.5f, 0), 0.7f);
        //            _Col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, -1, 0) * 10, ForceMode2D.Impulse);

        //        }
        //        if (_Col.gameObject.transform.position.y > 0 && (_Col.gameObject.transform.position.y < 3.3f))
        //        {

        //            _Col.gameObject.GetComponent<Rigidbody2D>().AddForce(_DirectionPlayertoBall(transform.position, _Col.gameObject.transform.position) * 100, ForceMode2D.Impulse);
        //        }
        //        //PlayerPrefs.SetString("BallMoveFrom", "Player2");
        //        //Debug.Log(PlayerPrefs.GetString("BallMoveFrom"));
    }
}
private void OnCollisionExit2D(Collision2D _Col)
{
    if (_Col.gameObject.tag == "Ball")
    {
        _Check = false;
    }
}
private void SetPlayerFace()
{
    _PlayerFace.sprite = _PlayerFaceImage[FaceID];
}


}
