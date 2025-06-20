using ConsoleApp1.Assets;
using ConsoleApp1.Ui;

namespace ConsoleApp1.Helpers;

public class Actions
{
    public static void MovePlayerToRoom(Player player, Dungeon dungeon)
    {
        Console.WriteLine("Please enter the number of the door you wish to knock down: ");
        var roomNumStr = Console.ReadLine();
        //verify roomNumber is an int
        int roomNum = Globals.ParseStrToInt(roomNumStr);
        //Verify roomNumber is an existing room and is locked
        if (!(roomNum <= dungeon.totalRooms))
        {
            //try again!
        }

        Room room = Room.GetRoom(roomNum);
        if (room == null)
        {
            // try again!
        }
            
        if (room.isUnlocked)
        {
            //This door is unlocked, proceed anyway?
        }
        else
        {
            
            KickDownDoor(player,room);
        }
    }

    public static void KickDownDoor(Player player, Room room)
    {
        Console.Clear();
        player.UpdateRoom(room);
        
        string dialogue = $"-------------\nYou have kicked down the door to room {room.roomNumber}!";
        Console.WriteLine(dialogue);
        
        Monster summonedMonster = SummonNewMonster(room);
        room.monster = summonedMonster;
        string monsterIntro = $"\nFrom the darkness...\nA level {summonedMonster.level} "+summonedMonster.type.ToString()+" emerges!\n\n\n";
        Console.WriteLine(monsterIntro);
        
        StartCombatPhase(player,summonedMonster);
    }

    public static Monster SummonNewMonster(Room room)
    {
        //check bad rolls: \/\/\/\/
        Console.WriteLine("\nRoll a d20 for your mob type\nRolled number:");
        var rollStr = Console.ReadLine();
        Console.WriteLine("\n\nRoll a second d20 for your stat scaler roll\nRolled number: ");
        var statStr = Console.ReadLine();
       //Get stats from input
        int roll = Globals.ParseStrToInt(rollStr);
        int statScaler = Globals.ParseStrToInt(statStr);
        
        MonsterType type = Globals.GetMonsterTypeFromRoll(roll);
        Console.Clear();
        return AssetLoader.CreateNewMonster(type, statScaler, room);
    }

    public static void StartCombatPhase(Player player, Monster monster)
    {
        
        int result = 0;
        // Where 0 is a no kill attack phase, 1 is a monster death, -1 is a player death
        while (result == 0)
        {
            string menu = PhaseUi.GetCombatPhaseUi(player, monster);
            string options = "\n\n1.) Use Item\t2. Attack)";
            Console.WriteLine(menu+options);
            var choice = Console.ReadLine();
            if (choice == "1")
            {
                HealPlayer(player,monster);
            }
            if (choice == "2")
            {
                result = AttackMob(player, monster);
            }
            
        }

        if (result == 1)
        {
            //Monster death
            monster.isAlive = false;
            monster.currentRoom.isVanquished = true;
            Console.WriteLine("Monster is vanquished!");
            //give loot
        }
        else if (result == -1)
        {
            //PLayer died
            player.isAlive = false;
            Console.WriteLine($"{player.name} has fallen.");
            
        }

    }

    public static void HealPlayer(Player player, Monster monster)
    {
        Console.Clear();
        string menu = "---------------\nHeal Actions:\n\n1.) Use Potion\n2.) Use Food\n3.) Back\nEnter choice:\n";
        Console.WriteLine(menu);
        var choice = Console.ReadLine();
        if (choice == "3")
        {
            StartCombatPhase(player,monster);
        }

        if (choice == "2")
        {
            player.UpdateHp(15);
        }

        if (choice == "1")
        {
            int t = player.maxHp / 2;
            player.UpdateHp(t);
        }
    }

    public static int AttackMob(Player player, Monster monster)
    {
        Console.WriteLine("Roll d20 to attack\nEnter Roll:\n");
        var rollStr = Console.ReadLine();
        int roll = Globals.ParseStrToInt(rollStr);

        double damagePercentage = (double)roll / 20;
        double damage = damagePercentage * player.cp;
        monster.hp -= (int) damage;
        
        Console.WriteLine($"{player.name} dealt {damage}!");
        if (monster.hp <= 0)
        {
            return 1;
        }
        return MobAttackPlayer(player,monster);
    }

    public static int MobAttackPlayer(Player player, Monster monster)
    {
        int aiRoll = Util.GetRandomNum(1, 20);
        double damagePercentage = (double) aiRoll / 20;
        double damage = damagePercentage * monster.cp;
        player.hp -= (int) damage;
        Console.WriteLine($"{monster.type} dealt {damage}!");
        Console.WriteLine($"Press any key to continue...");
        Console.ReadKey();
        if (player.hp <= 0)
        {
            return -1;
        }
        return 0;
    }
}