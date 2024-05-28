using System.Collections;
using UnityEngine;
public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform enemyPosition;
    [SerializeField] private float radius;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private float maxHp = 10;
    [SerializeField] private float curentHp = 10;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float attackCoolDown;
    private bool canAttack = true;
    [SerializeField] Character targetCharacter;
    GameObject enemy;
    Rigidbody2D rb;
    private Vector2 direction;

    private void Start()
    {
        targetCharacter = PlayerMovement.Instance.GetComponent<Character>();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = enemyPosition.gameObject;     
    }
    //public void SetTargetGameObject()
    //{
    //    targetGameObject = targetDestination.gameObject;
    //}
    private void Update()
    {
        if (targetCharacter != null)
        {
            // Di chuyển kẻ địch về phía mục tiêu
            Vector3 direction = (targetCharacter.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        CheckCollision();
    }
    public void CheckCollision()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, direction, distance, collisionLayer);
        if (hit.collider != null && canAttack)
        {
            Attack();
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
    private void Attack()
    {
        targetCharacter.TakeDamage(damage);
        canAttack = false;
        StartCoroutine(AttackCoolDown());
    }
    public void TakeDamage(float damage)
    {
        ScoreScript scoreScript = new ScoreScript();
        curentHp -= damage;
        if (curentHp <= 0)
        {
            Destroy(gameObject);
            ScoreScript.instance.AddScore();
        }
    }
    IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(attackCoolDown);
        canAttack = true;
    }
}
