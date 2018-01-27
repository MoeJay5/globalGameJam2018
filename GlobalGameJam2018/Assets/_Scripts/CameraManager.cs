using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject target;
    public float rotateSpeed = 5f;
    public Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0f, horizontal, 0f);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0f, desiredAngle, 0f);
        transform.position = target.transform.position - (rotation * offset);
    }
}