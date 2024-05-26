using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject bulletInstance;
    private Vector2 direction;
    [SerializeField] private float radius;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask collisionLayer;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) *Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    public void CheckCollision()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, direction, distance, collisionLayer);
        if (hit.collider != null)
        {
            Destroy(bulletInstance);
        }
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
