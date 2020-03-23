public interface IDamageable
{
    float health {get;}
    float currentHealth {get;}
    void GetDamage(int damage, IDamageable attacker);
}
