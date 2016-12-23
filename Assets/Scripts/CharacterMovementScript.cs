using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovementScript : MonoBehaviour {

    [SerializeField]
    private float maxSpeed = 50;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]

    private bool isGrounded;
    private Rigidbody rigid;
    private SphereCollider footCollider;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        footCollider = GetComponentInChildren<SphereCollider>();
    }

    void FixedUpdate()
    {
        isGrounded = false;
        Collider[] colliders = Physics.OverlapSphere(footCollider.transform.position, footCollider.radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject.tag != gameObject.tag)
            {
                isGrounded = true;
            }
        }
    }

	public void Move(float horizontal, float vertical)
    {
        rigid.velocity = new Vector3(horizontal * maxSpeed, rigid.velocity.y, 0);

    }

    public void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            rigid.AddForce(Vector3.up * jumpForce);
        }
    }
}
