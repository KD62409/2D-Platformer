using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    public float acceleration = 10;
    public float stoppingForce = 10;
    public float maxSpeedX = 10;
    public float stoppingPoint = 0.1f;
    public float jumpForce = 5;
    public float enemyHitForce = 50;
    public float DashForce = 10;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private bool _canJump = true;
    private bool _canDash = true;
    private float _iniScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int maxJump = 2;
    private int currentJumps;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _iniScale = transform.localScale.x;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //Check if moving right
        if(direction.x > 0)
        {
            transform.localScale = new Vector3(_iniScale, transform.localScale.y, transform.localScale.z);
        } else if(direction.x <0 )
        {
            transform.localScale = new Vector3(-_iniScale, transform.localScale.y, transform.localScale.z);
        }

            MovePlayer();
        LimitMaxSpeed();
    }

    private void LimitMaxSpeed()
    {
        if(!_canDash)
        {
            return;
        }
        //Limit max speed
        if (_rigidbody2D.linearVelocityX >= maxSpeedX)
        {
            _rigidbody2D.linearVelocityX = maxSpeedX;
        }
        else if (_rigidbody2D.linearVelocityX <= -maxSpeedX)
        {
            _rigidbody2D.linearVelocityX = -maxSpeedX;
        }
    }

    private void MovePlayer()
    {
        //accelerate if pressing button
        if (direction.x != 0)
        {
            _rigidbody2D.AddForce(new Vector2(direction.x * acceleration, 0));
            _animator.SetBool("isMoving", true);
        }
        //if not accelerating start slowing down
        else if (_rigidbody2D.linearVelocityX != 0)
        {
            //if almost stopped, force stop
            if (_rigidbody2D.linearVelocityX < stoppingPoint && _rigidbody2D.linearVelocityX > -stoppingPoint)
            {
                _rigidbody2D.linearVelocity = new Vector2(0.0f, _rigidbody2D.linearVelocityY);
                

            }
            //add stopping force
            else
            {
                _rigidbody2D.AddForce(new Vector2(-_rigidbody2D.linearVelocityX * stoppingForce, 0));
            }

        }
        if(direction.x == 0)
        {
            _animator.SetBool("isMoving", false);
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (_canJump)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            currentJumps++ ;
            if(currentJumps >= maxJump)
            {
                _canJump = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _canJump = true;
        currentJumps = 0;
    }
    private void OnDash() 
    {
        //Debug.Log("OnDash");
        if (_canDash)
        {
            if (direction.x != 0)
            {
                _rigidbody2D.AddForce(new Vector2(direction.x * DashForce, 0), ForceMode2D.Impulse);
            }
            else
            {
                _rigidbody2D.AddForce(new Vector2(DashForce, 0), ForceMode2D.Impulse);
            }
                
            _canDash = false;
            StartCoroutine(ResetDash(1));
        }
    }
    IEnumerator ResetDash(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        _canDash = true;
    }

    private void OnHealthChanged(int oldHealth, int amountChanged, Vector3 origin)
    {
        _rigidbody2D.AddForce(new Vector3(origin.x - transform.position.x, 0, 0) * enemyHitForce, ForceMode2D.Impulse);
    }

    private void OnMoneyChanged(int oldMoney, int amountChanged, Vector3 origin)
    {
        _rigidbody2D.AddForce(new Vector3(origin.x - transform.position.x, 0, 0) * enemyHitForce, ForceMode2D.Impulse);




    }

}
