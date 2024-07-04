using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData_", menuName = "EnemyTakeDamage/EnemyData_")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float radius;
    [SerializeField] private float distance;
    [SerializeField] private float maxHp = 10;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float attackCoolDown;
    private Vector2 direction;
    [SerializeField] Character targetCharacter;

    public float Speed => speed;
    public float Radius => radius;
    public float Distance => distance;
    public float MaxHp => maxHp;
    public float Damage => damage;
    public Vector2 Direction => direction;
    public float AttackCoolDown => attackCoolDown;
}
