using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    [SerializeField]
    private Transform triangleTip;

    [SerializeField]
    private GameObject bullet;

    private Vector2 lookDirection;
    private float lookAngle;
    public int bulletCount = 10;

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        if (Input.GetMouseButtonDown(0)) {
            if (bulletCount > 0) {
                bulletCount -= 1;
                FireBullet();
            }
        }
    }

    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(bullet, triangleTip.position, triangleTip.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = triangleTip.up * 20f;
    }
}
