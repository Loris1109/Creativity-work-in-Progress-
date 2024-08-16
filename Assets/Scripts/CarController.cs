using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private CinemachineFreeLook FreeLookCam;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        MouseMovmentwhilePlaying();
    }
    public void MouseMovmentwhilePlaying()
    {
        FreeLookCam.m_YAxis.m_InputAxisName = ""; //noraml Value = "Mouse Y"
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontal, 00f, vertical).normalized;

        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.position += moveDir * speed * Time.deltaTime;
        }
    }

    public void OnCollisionEnter(Collision collision) 
    {
        if (collision.collider.tag == "obstical")
        {
            Debug.Log(collision);
        }
           
    }

}
