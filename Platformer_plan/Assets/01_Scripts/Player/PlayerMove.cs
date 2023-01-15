using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 플레이어 이동 관련 코드
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _jumpPower;

    private PlayerKey _playerKey;

    private Transform _playerTransform;
    private Rigidbody2D _playerRigidbody;

    private CircleCollider2D _groundCheckCollider;
    private int _groundLayer;

    private Animator _playerAnimator;

    [SerializeField]
    private bool _isJump = false;
    private bool _isGrounded = true;
    private bool _isMove = false;

    private void Awake()
    {
        _playerKey = GetComponent<PlayerKey>();
        _playerTransform = transform.GetChild(0).GetComponent<Transform>();
        _playerRigidbody = _playerTransform.GetComponent<Rigidbody2D>();
        _playerAnimator = _playerTransform.GetComponent<Animator>();
        _groundCheckCollider = _playerTransform.GetChild(0).GetComponent<CircleCollider2D>();
        _groundLayer = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        MoveVertical();
        Jump();
        SetAnimation();
    }

    private void Jump()
    {
        GroundCheck();
        float veloX = _playerRigidbody.velocity.x;
        if (Input.GetKeyDown(_playerKey.JumpKey) && _isGrounded)
        {
            _playerRigidbody.AddForce(new Vector2(0, _jumpPower), ForceMode2D.Impulse);
            _isJump = true;
        }
    }
    private void GroundCheck()
    {
        //
        RaycastHit2D checkCol = Physics2D.CircleCast(_groundCheckCollider.bounds.center, 
            _groundCheckCollider.radius, Vector2.down, 
            _groundCheckCollider.radius+0.1f, _groundLayer);
        _isGrounded = checkCol.collider;
        _isJump = !checkCol.collider;
        Debug.Log(checkCol.collider);
        Debug.Log(_groundCheckCollider.gameObject);
        
    }
    private void MoveVertical()
    {
        float veloY = _playerRigidbody.velocity.y;
        _isMove = false;
        _playerRigidbody.velocity = new Vector2(0, veloY);
        if (Input.GetKey(_playerKey.LeftMoveKey) && !Input.GetKey(_playerKey.RightMoveKey))
        {
            _playerRigidbody.velocity = new Vector2(-_moveSpeed, veloY);
            _isMove = true;
        }
        if (Input.GetKey(_playerKey.RightMoveKey) && !Input.GetKey(_playerKey.LeftMoveKey))
        {
            _playerRigidbody.velocity = new Vector2(_moveSpeed, veloY);
            _isMove = true;
        }
        CheckVelocity();
        _isMove = (_playerRigidbody.velocity.x != 0);

    }
    private void CheckVelocity()
    {
        float dirX = _playerRigidbody.velocity.x;
        if (dirX > 0)
            _playerTransform.localScale = new Vector3(-1, 1, 1);
        else if(dirX < 0)
            _playerTransform.localScale = new Vector3(1, 1, 1);
        
    }
    private void SetAnimation()
    {
        _playerAnimator.SetFloat("PlayerX", _playerRigidbody.velocity.x);
        _playerAnimator.SetFloat("PlayerY", _playerRigidbody.velocity.y);
        _playerAnimator.SetBool("IsJump", _isJump);
        _playerAnimator.SetBool("IsMove", _isMove);
    }


}
