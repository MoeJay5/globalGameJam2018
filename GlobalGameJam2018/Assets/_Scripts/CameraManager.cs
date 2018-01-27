using UnityEngine;

public class CameraManager : MonoBehaviour {

    public Transform _target;

    public float _smoothSpeed = 10f;
    public Vector3 _offset;

    private Transform _t;

    private Vector3 desiredPos;
    private Vector3 smoothedPos;
    private Vector3 mousePos;

    void Start()
    {
        _t = transform;
    }

    void LateUpdate()
    {
        //mousePos = new Vector3(Input.GetAxis("Mouse X") * 2, Input.GetAxis("Mouse Y") * 2, 0);
        //desiredPos = _target.position + _offset + mousePos;
        desiredPos = _target.position + _offset;
        smoothedPos = Vector3.Slerp(_t.position, desiredPos, _smoothSpeed * Time.deltaTime);
        //_t.position = smoothedPos + mousePos;
        _t.position = smoothedPos;

        _t.LookAt(_target);
    }
}