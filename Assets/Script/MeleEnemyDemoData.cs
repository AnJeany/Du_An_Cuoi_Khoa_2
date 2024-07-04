using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MeleEnemyDemoData : MonoBehaviour
{
    //EnemyData enemyData;
    //GameObject enemy;
    //[SerializeField] Character targetCharacter;
    //[SerializeField] private readonly Transform enemyPosition;
    //[SerializeField] private LayerMask collisionLayer;
    //[SerializeField] private float curentHp = 10;
    //private bool canAttack = true;
    //private void Start()
    //{
    //    targetCharacter = PlayerMovement.Instance.GetComponent<Character>();
    //}
    //private void Awake()
    //{
    //    //rb = GetComponent<Rigidbody2D>();
    //    enemy = enemyPosition.gameObject;
    //}
    //private void Update()
    //{
    //    if (targetCharacter != null)
    //    {
    //        // Di chuyển kẻ địch về phía mục tiêu
    //        Vector3 direction = (targetCharacter.transform.position - transform.position).normalized;
    //        transform.position += direction * enemyData.Speed * Time.deltaTime;
    //    }
    //    CheckCollision();
    //}
    //public void CheckCollision()
    //{
    //    RaycastHit2D hit = Physics2D.CircleCast(transform.position, enemyData.Radius, enemyData.Direction, enemyData.Distance, collisionLayer);
    //    if (hit.collider != null && canAttack)
    //    {
    //        EnemyAttack();
    //    }
    //}
    //void OnDrawGizmos()
    //{
    //    // Vẽ vòng tròn tại vị trí hiện tại của đối tượng
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, enemyData.Radius);

    //    // Vẽ đường di chuyển của CircleCast
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawLine(transform.position, transform.position + (Vector3)enemyData.Direction * enemyData.Distance);
    //    Gizmos.DrawWireSphere(transform.position + (Vector3)enemyData.Direction * enemyData.Distance, enemyData.Radius);
    //}
    //private void EnemyAttack()
    //{
    //    targetCharacter.PlayerTakeDamage(enemyData.Damage);
    //    canAttack = false;
    //    StartCoroutine(AttackCoolDown());
    //}
    //public void EnemyTakeDamage(float damage)
    //{
    //    curentHp -= damage;
    //    if (curentHp <= 0)
    //    {
    //        Destroy(gameObject);
    //        ScoreScript.instance.AddScore();
    //    }
    //}
    //IEnumerator AttackCoolDown()
    //{
    //    yield return new WaitForSeconds(enemyData.AttackCoolDown);
    //    canAttack = true;
    //}
}
