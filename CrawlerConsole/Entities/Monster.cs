using ConsoleApp1.Assets;

public interface Monster
{
    MonsterType type { get; set; }
    int level { get; set; }
    int hp { get; set; }
    int cp { get; set; }
    bool isAlive { get; set; }
    int lootRolls { get; set; }
    public void SetMaxHpFromLevel(int level) { }
    public void SetMaxCpFromLevel(int level) { }
    public void setLootRollsFromLevel(int level) { }
    public int GetCurrentHp() { return hp; }
    public void UpdateLiving(bool isAlive) { }
    public bool IsAlive() { return isAlive; }
    public void CriticalHit() { }
}