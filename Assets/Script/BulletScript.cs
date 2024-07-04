using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BulletScript : MonoBehaviour
{
    GameObject bulletInstance;
    [SerializeField] private float bulletDamage = 5f; // Thêm biến gây sát thương
    [SerializeField] private float attackCooldown = 0.5f; // Thêm biến thời gian hồi      
    [SerializeField] private float radius;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask enemyLayer;

    private Vector2 direction;
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
        //CheckCollision();
        //OnCollisionEnter();
    }
    //public void CheckCollision()
    //{
    //    RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, direction, distance, enemyLayer);
    //    if (hit.collider != null)
    //    {
    //        // Kiểm tra xem đối tượng va chạm có script EnemyTakeDamage không
    //        MeleEnemy enemy = hit.collider.GetComponent<MeleEnemy>();
    //        if (enemy != null)
    //        {
    //            // Gọi hàm EnemyTakeDamage của enemy
    //            enemy.EnemyTakeDamage(bulletDamage);

    //            // Hủy viên đạn
    //            Destroy(gameObject);
    //        }
    //    }
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

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Kiểm tra xem đối tượng va chạm có script EnemyTakeDamage không
            MeleEnemy enemy = col.collider.GetComponent<MeleEnemy>();
            if (enemy != null)
            {
                // Gọi hàm EnemyTakeDamage của enemy
                enemy.EnemyTakeDamage(bulletDamage);

                // Hủy viên đạn
                Destroy(gameObject);
            }
        }
    }
}