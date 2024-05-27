using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletDamage = 5f; // Thêm biến gây sát thương
    [SerializeField] private float attackCooldown = 0.5f; // Thêm biến thời gian hồi
    GameObject bulletInstance;
    private Vector2 direction;
    [SerializeField] private float radius;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask enemyLayer;

    private bool canDealDamage = true;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    [SerializeField] private float timeDestroyBullet;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
 
    }
    void FixedUpdate()
    {
        CheckCollision();
    }

    public void CheckCollision()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, direction, distance, enemyLayer);
        if (hit.collider != null)
        {
            // Kiểm tra xem đối tượng va chạm có script Enemy không
            BasicEnemy enemy = hit.collider.GetComponent<BasicEnemy>();
            if (enemy != null)
            {
                // Gọi hàm TakeDamage của enemy
                enemy.TakeDamage(bulletDamage);

                // Hủy viên đạn
                Destroy(gameObject);
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    BasicEnemy enemy = col.collider.GetComponent<BasicEnemy>();
    //    if (col.gameObject.layer == 6)
    //    {
    //        enemy.TakeDamage(bulletDamage);
    //    }
    //    Destroy(gameObject);
    //}

    private void AttackEnemy()
    {

        canDealDamage = false;
        StartCoroutine(DamageCooldown());
    }
    void OnDrawGizmos()
    {
        // Vẽ vòng tròn tại vị trí hiện tại của đối tượng
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

        // Vẽ đường di chuyển của CircleCast
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)direction * distance);
        Gizmos.DrawWireSphere(transform.position + (Vector3)direction * distance, radius);
    }

    IEnumerator DamageCooldown()
    {
        canDealDamage = false;
        yield return new WaitForSeconds(attackCooldown);
        canDealDamage = true;
    }

}