using System.Collections.Generic;
using static SpartaTextRPG.Program;
using static SpartaTextRPG.Program.Item;

namespace SpartaTextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameLogic = new GameLogic();

            gameLogic.Start_Game();
            gameLogic.Standard_Scene();

        }

        public class Player
        {
            //배열로?
            public float lv = 01;
            public string player_Name;
            public string player_Class;
            public float player_AttackPower = 10;
            public float player_DeffencePower = 5;
            public float player_Hp = 100;
            public float player_Gold = 1500;

            

            public void Player_Buy_Item(Item item)
            {
                if (item.item_Have == true)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                }
                else if (player_Gold - item.item_Price >= 0)
                {
                    Console.WriteLine("아이템 구매를 완료했습니다.");
                    player_Gold -= item.item_Price;
                    item.item_Have = true;
                    //인벤토리 아이템 넣기
                    Inventory list_Armor_Common = new Inventory("수련자 갑옷", 0, 5, 1000, " 수련에 도움을 주는 갑옷입니다.                   ");
                    //Item(list_Armor_Common);

                }
                else
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        public class Item
        {
            public string item_Name;
            public float item_AttackStat;
            public float item_DeffenceStat;
            public float item_Price;
            public string item_Explain;

            public bool item_Have = false;
            public bool item_Equip = false;

            public int item_Index;

            public Item(int index, string name, float atk, float def, float price, string explain)
            {
                item_Index = index;
                item_Name = name;
                item_AttackStat = atk;
                item_DeffenceStat = def;
                item_Price = price;
                item_Explain = explain;
            }

            public class Inventory
            {
                public string invenItem_Name;
                public float invenItem_AttackStat;
                public float invenItem_DeffenceStat;
                public float invenItem_Price;
                public string invenItem_Explain;

                public List<Inventory> playerItems;
                public Inventory()
                {
                    playerItems = new List<Inventory>();
                }

                public void Items(Inventory inventory)
                {
                    playerItems.Add(inventory);
                }

                public Inventory(string name, float atk, float def, float price, string explain)
                {
                    invenItem_Name = name;
                    invenItem_AttackStat = atk;
                    invenItem_DeffenceStat = def;
                    invenItem_Price = price;
                    invenItem_Explain = explain;
                }
            }

            public void ShowItem(Item item)
            {
                if(item.item_Have == false)
                {
                    Console.WriteLine($"- {item.item_Name}   | 공격력 +{item.item_AttackStat} | 방어력 +{item.item_DeffenceStat}  |{item.item_Explain}|  {item.item_Price} G");
                }
                else
                {
                    Console.WriteLine($"- {item.item_Name}   | 공격력 +{item.item_AttackStat} | 방어력 +{item.item_DeffenceStat}  |{item.item_Explain}|  구매완료 ");
                }
            }
            public void ShowBuyItem(Item item)
            {
                if (item.item_Have == false)
                {
                    Console.WriteLine($"- {item_Index} {item.item_Name}    | 공격력 +{item.item_AttackStat}  | 방어력 +{item.item_DeffenceStat}  |{item.item_Explain}|  {item.item_Price} G");
                }
                else
                {
                    Console.WriteLine($"- {item_Index} {item.item_Name}    | 공격력 +{item.item_AttackStat} | 방어력 +{item.item_DeffenceStat}  |{item.item_Explain}|  구매완료 ");
                }
            }
            public void ShowPlayerHaveItem(List<Item> item)
            {
                //if (item.item_Equip == true)
                //{
                //    Console.WriteLine($"- {item_Index} {item.item_Name}    | 공격력 +{item.item_AttackStat}  | 방어력 +{item.item_DeffenceStat}  |{item.item_Explain}|  {item.item_Price} G");
                //}
                //else
                //{
                //    Console.WriteLine($"- {item_Index} {item.item_Name}    | 공격력 +{item.item_AttackStat} | 방어력 +{item.item_DeffenceStat}  |{item.item_Explain}|  구매완료 ");
                //}
            }

        }
        enum Game_Class
        {
            전사 = 1,
            도적,
            궁수,
            법사,
            술사
        }

        enum Item_List
        {
            갑옷_흔함 = 1,
            갑옷_안흔함,
            갑옷_특별함,
            무기_흔함,
            무기_안흔함,
            무기_특별함
        }
        static public void WrongInput()
        {
            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.\n");
            Thread.Sleep(1000);
            Console.Clear();
        }

        class GameLogic
        {
            Player player = new Player();
            public List<Inventory> playerItem = new List<Inventory>();

            

            Item armor_Common = new Item(1, "수련자 갑옷", 0, 5, 1000, " 수련에 도움을 주는 갑옷입니다.                   ");
            Item armor_Uncommon = new Item(2, "무쇠 갑옷", 0, 9, 2100, " 무쇠로 만들어져 튼튼한 갑옷입니다.               ");
            Item armor_Rare = new Item(3, "스파르타의 갑옷", 0, 15, 3500, " 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.");
            Item weapon_Common = new Item(4, "낡은 검", 2, 0, 600, " 쉽게 볼 수 있는 낡은 검 입니다.                  ");
            Item weapon_Uncommon = new Item(5, "청동 도끼", 5, 0, 1500, " 어디선가 사용됐던거 같은 도끼입니다.             ");
            Item weapon_Rare = new Item(6, "스파르타의 창", 7, 0, 2400, " 스파르타의 전사들이 사용했다는 전설의 창입니다.  ");

            public void Start_Game()
            {

                while (true)
                {
                    Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                    Console.WriteLine("원하시는 이름을 설정해주세요.\n");
                    player.player_Name = Console.ReadLine();
                    Console.WriteLine($"\n입력하신 이름은 {player.player_Name} 입니다.\n");
                    Console.WriteLine("1. 저장");
                    Console.WriteLine("2. 취소");
                    Console.WriteLine("\n 원하시는 행동을 숫자로 입력해주세요.");
                    int caseNumber = int.Parse(Console.ReadLine());

                    switch (caseNumber)
                    {
                        case 1:     //저장
                            break;
                        case 2:     //취소
                            player.player_Name = null;
                            Console.Clear();
                            continue;
                        default:
                            WrongInput();
                            continue;
                    }
                    if (caseNumber == 1)
                    {
                        Console.Clear();
                        break;
                    }
                }
                Select_Class();

            }

            public void Select_Class()
            {
                while (true)
                {
                    Console.WriteLine($"반갑습니다.{player.player_Name} 님! ");
                    Console.WriteLine($"원하시는 직업을 숫자로 선택해주세요\n");

                    int count = System.Enum.GetValues(typeof(Game_Class)).Length;
                    Game_Class className;
                    for (int i = 1; i <= count; i++)
                    {
                        className = (Game_Class)i;
                        Console.WriteLine($"{i}. {className}");
                    }

                    int caseNumber = int.Parse(Console.ReadLine());

                    switch (caseNumber)
                    {
                        case (int)Game_Class.전사:
                            player.player_Class = "전사";
                            Console.Clear();
                            Console.WriteLine($"{(Game_Class)caseNumber}을(를) 선택하셨습니다!\n");
                            break;
                        case (int)Game_Class.도적:
                            player.player_Class = "도적";
                            Console.Clear();
                            Console.WriteLine($"{(Game_Class)caseNumber}을(를) 선택하셨습니다!\n");
                            break;
                        case (int)Game_Class.궁수:
                            player.player_Class = "궁수";
                            Console.Clear();
                            Console.WriteLine($"{(Game_Class)caseNumber}을(를) 선택하셨습니다!\n");
                            break;
                        case (int)Game_Class.법사:
                            player.player_Class = "법사";
                            Console.Clear();
                            Console.WriteLine($"{(Game_Class)caseNumber}을(를) 선택하셨습니다!\n");
                            break;
                        case (int)Game_Class.술사:
                            player.player_Class = "술사";
                            Console.Clear();
                            Console.WriteLine($"{(Game_Class)caseNumber}을(를) 선택하셨습니다!\n");
                            break;
                        default:
                            WrongInput();
                            continue;
                    }
                    break;
                }
              
            }

            public void Standard_Scene()
            {
                while (true)
                {
                    Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                    Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
                    Console.WriteLine("1. 상태 보기");
                    Console.WriteLine("2. 인벤토리");
                    Console.WriteLine("3. 상점");
                    Console.WriteLine("\n0. 게임 종료");
                    Console.WriteLine("\n원하시는 행동을 숫자로 입력해주세요.\n>> ");
                    int caseNumber = int.Parse(Console.ReadLine());
                    switch (caseNumber)
                    {
                        case 0:
                            break;
                        case 1: //상태 보기
                            Console.Clear();
                            Show_Status();
                            break;
                        case 2: //인벤토리
                            Console.Clear();
                            Show_Iventory();
                            break;
                        case 3: //상점
                            Console.Clear();
                            Show_Shop();
                            break;
                        default :
                            WrongInput();
                            continue;
                    }
                    if (caseNumber == 0)
                    {
                        Console.WriteLine("\n게임을 종료합니다.");
                        break;
                    }
                }
            }

            public void Show_Status()
            {
                while (true)
                {
                    Console.WriteLine("상태 보기");
                    Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
                    Console.WriteLine($"Lv. {player.lv} ");
                    Console.WriteLine($"{player.player_Name}  ({player.player_Class})");
                    Console.WriteLine($"공격력 :  {player.player_AttackPower} ");
                    Console.WriteLine($"방어력 :  {player.player_DeffencePower} ");
                    Console.WriteLine($"체  력 :  {player.player_Hp}");
                    Console.WriteLine($"Gold   :  {player.player_Gold} G");
                    Console.WriteLine("\n0. 나가기");
                    Console.WriteLine("\n원하시는 행동을 숫자로 입력해주세요.\n>> ");
                    int caseNumber = int.Parse(Console.ReadLine());
                    if (caseNumber == 0)
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        WrongInput();
                        continue;
                    }
                }
            }


            public void Show_Iventory()
            {

                while (true)
                {
                    Console.WriteLine("인벤토리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                    Console.WriteLine("[아이템 목록]");
                    Console.WriteLine("\n1. 장착 관리");
                    Console.WriteLine("\n0. 나가기");
                    Console.WriteLine("\n원하시는 행동을 숫자로 입력해주세요.\n>> ");
                    int caseNumber = int.Parse(Console.ReadLine());
                    switch (caseNumber)
                    {
                        case 0:
                            Console.Clear();
                            break;
                        case 1:
                            Console.Clear();
                            //장착 관리 창
                            continue;
                        default:
                            WrongInput();
                            continue;
                    }
                    break;
                }
            }
            public void Show_Iventory_Equip_Manage()
            {
                while (true)
                {
                    Console.WriteLine("인벤토리 - 장착 관리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                    Console.WriteLine("[아이템 목록]");
                    //보유 아이템 목록
                    Console.WriteLine("\n1. 장착 관리");
                    Console.WriteLine("\n0. 나가기");
                    Console.WriteLine("\n원하시는 행동을 숫자로 입력해주세요.\n>> ");
                    int caseNumber = int.Parse(Console.ReadLine());
                    switch (caseNumber)
                    {
                        case 0:
                            Console.Clear();
                            break;
                        case 1:
                            Console.Clear();
                            //장착 관리 창
                            continue;
                        default:
                            WrongInput();
                            continue;
                    }
                    break;
                }
            }

            public void Show_Shop()
            {


                while (true)
                {
                    Console.WriteLine("상점");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine($" {player.player_Gold} G\n");
                    Console.WriteLine("[아이템 목록]");
                    armor_Common.ShowItem(armor_Common);
                    armor_Uncommon.ShowItem(armor_Uncommon);
                    armor_Rare.ShowItem(armor_Rare);
                    weapon_Common.ShowItem(weapon_Common);
                    weapon_Uncommon.ShowItem(weapon_Uncommon);
                    weapon_Rare.ShowItem(weapon_Rare);
                    Console.WriteLine("\n1. 아이템 구매");
                    Console.WriteLine("\n0. 나가기");
                    Console.WriteLine("\n원하시는 행동을 숫자로 입력해주세요.\n>> ");
                    int caseNumber = int.Parse(Console.ReadLine());
                    switch (caseNumber)
                    {
                        case 0:
                            Console.Clear();
                            break;
                        case 1:
                            Console.Clear();
                            Show_Buy_Shop();
                            continue;
                        default:
                            WrongInput();
                            continue;
                    }
                    break;
                }
            }

            public void Show_Buy_Shop()
            {
                while (true)
                {
                    Console.WriteLine("상점 - 아이템 구매");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine($" {player.player_Gold} G\n");
                    Console.WriteLine("[아이템 목록]");
                    armor_Common.ShowBuyItem(armor_Common);
                    armor_Uncommon.ShowBuyItem(armor_Uncommon);
                    armor_Rare.ShowBuyItem(armor_Rare);
                    weapon_Common.ShowBuyItem(weapon_Common);
                    weapon_Uncommon.ShowBuyItem(weapon_Uncommon);
                    weapon_Rare.ShowBuyItem(weapon_Rare);
                    Console.WriteLine("\n0. 나가기");
                    Console.WriteLine("\n원하시는 행동을 숫자로 입력해주세요.\n>> ");
                    int caseNumber = int.Parse(Console.ReadLine());
                    switch (caseNumber)
                    {
                        case 0:
                            Console.Clear();
                            break;
                        case 1:
                            player.Player_Buy_Item(armor_Common);
                                continue;
                        case 2:
                            player.Player_Buy_Item(armor_Uncommon);
                            continue;
                        case 3:
                            player.Player_Buy_Item(armor_Rare);
                            continue;
                        case 4:
                            player.Player_Buy_Item(weapon_Common);
                            continue;
                        case 5:
                            player.Player_Buy_Item(weapon_Uncommon);
                            continue;
                        case 6:
                            player.Player_Buy_Item(weapon_Rare);
                            continue;
                        default:
                            WrongInput();
                            continue;
                    }
                    break;
                }
            }
        }
    }
}
