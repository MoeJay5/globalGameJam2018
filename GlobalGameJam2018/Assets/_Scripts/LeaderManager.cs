using System.Collections;
using UnityEngine;

public class LeaderManager : MonoBehaviour
{
    [Range(1f, 10f)]
    public float _speed = 2.1f;
    [Range(1f, 15f)]
    public float _speedMax = 2.4f;
    [HideInInspector]
    public bool _isMoving;
    public bool canMove;

    private float x, z, speedReset;

    private const int smoothness = 10;
    private Transform _t, _leader;

    private Animator _playerAnimator;
    private Animator _cameraAnimator;

    private Animator _animator;
    private bool _jump;

    private Rigidbody rb;

    public AudioSource[] playerSounds;
    public AudioSource running;
    public AudioSource ambient;
    private bool isPlaying = false;
    
    void Start()
    {
        canMove = true;
        _t = transform;
        _leader = _t.GetChild(0).transform;
        _playerAnimator = _t.GetChild(0).GetComponent<Animator>();
        _cameraAnimator = _t.GetChild(0).GetChild(1).GetComponent<Animator>();
        _animator = _t.GetChild(0).GetComponent<Animator>();

        rb = _leader.GetComponent<Rigidbody>();

        if (_speed > _speedMax)
            _speedMax = _speed;

        speedReset = _speed;

        playerSounds = GetComponentsInChildren<AudioSource>();
        running = playerSounds[0];
        ambient = playerSounds[1];
    }

    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey("s"))
            {
                _leader.position += -_leader.forward * _speed * Time.deltaTime;
            }

            if (Input.GetKey("d"))
            {
                _leader.position += _leader.right * _speed * Time.deltaTime;
            }

            if (Input.GetKey("a"))
            {
                _leader.position += -_leader.right * _speed * Time.deltaTime;
            }

            if (Input.GetKey("w"))
            {
                if (_speed <= _speedMax)
                {
                    _speed += Time.deltaTime * 2; //Slowly increase speed
                }

                _isMoving = true;
                _leader.position += _leader.forward * _speed * Time.deltaTime;

                StartCoroutine(PlaySound(0));
            }
            else
            {
                if (_speed <= speedReset) //Completely Stopped
                {
                    _isMoving = false;
                    _speed = speedReset;
                }

                else //Slowing Down
                {
                    _isMoving = true;
                    _speed -= Time.deltaTime * 8f; //Slowly decrease speed
                }

            }

            if (Input.GetKeyDown(KeyCode.Space) && _leader.GetComponent<JumpDetection>().isGrounded)
            {
                rb.AddForce(new Vector3(0f, 300000f, 0f));
                _jump = true;
            }
            else
                _jump = false;

            _animator.SetBool("jump", _jump);
            _animator.SetFloat("movementSpeed", _speed);
            _animator.SetBool("isMoving", _isMoving);
        }
        else
            _jump = false;

        _playerAnimator.SetBool("isJumping", _jump);
        _playerAnimator.SetFloat("movementSpeed", _speed);
        _playerAnimator.SetBool("isMoving", _isMoving);
        _cameraAnimator.SetBool("jump", _jump);
        _cameraAnimator.SetFloat("movementSpeed", _speed);
        _cameraAnimator.SetBool("isMoving", _isMoving);
    }

    IEnumerator PlaySound(int clipNum)
    {
        if(!isPlaying)
        {
            isPlaying = true;
            playerSounds[clipNum].Play();
            yield return new WaitForSeconds(playerSounds[clipNum].clip.length);
            isPlaying = false;
            yield return null;
        }
    }
}