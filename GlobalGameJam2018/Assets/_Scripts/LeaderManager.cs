using UnityEngine;

public class LeaderManager : MonoBehaviour
{
    [Range(1f, 10f)]
    public float _speed = 2.1f;
    [Range(1f, 15f)]
    public float _speedMax = 2.4f;
    [HideInInspector]
    public bool _isMoving;

    private float x, z, speedReset;

    private const int smoothness = 10;
    private Transform _t, _leader;

    private Animator _animator;

    private Rigidbody rb;
    

    void Start()
    {
        _t = transform;

        _leader = _t.GetChild(0).transform;
        _animator = _t.GetChild(0).GetChild(0).GetComponent<Animator>();
        rb = _leader.GetComponent<Rigidbody>();

        if (_speed > _speedMax)
            _speedMax = _speed;

        speedReset = _speed;
    }

    void Update()
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
        }

        //if (_isMoving)
        //{
        //    _aim.DetachChildren();
        //    _aim.position = _leader.position;
        //    _leader.SetParent(_aim);
        //}

        //_animator.SetFloat("movementSpeed", _speed);
        //_animator.SetBool("isMoving", _isMoving);
    }
}