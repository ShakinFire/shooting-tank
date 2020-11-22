using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float moveSpeed = 40f;
    public float horizontalMove = 0f;
    private Rigidbody2D m_Rigidbody2D;
    public Triangle Triangle;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;

    // Update is called once per frame
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2((horizontalMove * Time.fixedDeltaTime) * 10f, m_Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("collectable-bullet"))
        {
            Destroy(collider.transform.parent.gameObject);
            Triangle.bulletCount += 1;
        }
    }
}
