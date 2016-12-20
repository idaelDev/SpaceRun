using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovementScript : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpForce = 10f;

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
        float verticalMove = (isGrounded) ? 0 : vertical;
        Vector3 direction = new Vector3(horizontal, verticalMove, 0) * moveSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + direction);
    }

    public void Jump()
    {
        rigid.AddForce(Vector3.up * jumpForce);
    }
}
