public interface ITakeDamage
{
    float CurrentHP { get; set; }
    float MaxHP { get; set; }
    float BaseHP { get; set; }

    void TakeDamage(int damage);
    void AddHP(int hp);
}
