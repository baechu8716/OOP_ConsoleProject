using Project_P.GameObjects.Items;
using Project_P.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Project_P
{
    public class ItemInventory
    {
        public List<Item> items;
        public Stack<string> stack;
        public int selectIndex;
        public ItemInventory()
        {
            items = new List<Item>();
            stack = new Stack<string>();
        }
        public void UseItem(int index)
        {
            items[index].Use();
        }
        public void Add(Item item)
        {
            var existingItem = items.Find(i => i.name == item.name);
            if (existingItem != null)
            {
                existingItem.count += item.count;
            }
            else
            {
                items.Add(item);
            }
        }
        public void Remove(Item item)
        {
            items.Remove(item);
        }

        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }
        
        public void Open()
        {
            
            stack.Push("Menu");
            while(stack.Count > 0)
            {
                Console.Clear();
                switch (stack.Peek())
                {
                    case "Menu":
                        Menu();
                        break;
                    case "UseMenu":
                        UseMenu();
                        break;
                    case "DropMenu":
                        DropMenu();
                        break;
                    case "UseConfirm":
                        UseConfirm();
                        break;
                    case "DropConfirm":
                        DropConfirm();
                        break;
                    case "Check":
                        Check();
                        break;
                    default:
                        break;
                }
            }
            
        }

        public void Menu()         
        {   
            if(items.Count > 0)
            {
                Print();
                Console.WriteLine("1. 사용한다.");
                Console.WriteLine("2. 버린다.");
                Console.WriteLine("돌아가려면 0번");
            }
            else
            {
                Console.WriteLine("아이템이 없습니다.");
                Console.WriteLine("아무키나 눌러 종료...");
                Console.ReadKey(true);
                stack.Pop();
            }

                ConsoleKey input = Console.ReadKey(true).Key;
            switch(input)
            {
                case ConsoleKey.D1:
                    stack.Push("UseMenu");
                    break;
                case ConsoleKey.D2:
                    stack.Push("DropMenu");
                    break;
                case ConsoleKey.D0:
                    stack.Pop();
                    break;
                default: break;
            }
        }
        public void UseMenu()
        {
            Print();
            Console.WriteLine("사용할 아이템의 번호를 선택해주세요");
            Console.WriteLine("돌아가려면 0번");

            ConsoleKey input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.D0)
            {
                stack.Pop();
            }
            else
            {
                int select = (int)input - (int)ConsoleKey.D1;
                if (select < 0 || select >= items.Count)
                {
                    Console.WriteLine("범위 내의 아이템을 선택하세요.");
                    Console.ReadLine();
                }
                else
                {
                    selectIndex = select;
                    stack.Push("UseConfirm");
                }
            }
        }
        public void DropMenu()
        {
            Print();
            Console.WriteLine("버릴 아이템의 번호를 선택해주세요");
            Console.WriteLine("돌아가려면 0번");

            ConsoleKey input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.D0)
            {
                stack.Pop();
            }
            else
            {
                int select = (int)input - (int)ConsoleKey.D1;
                if (select < 0 || select >= items.Count)
                {
                    Console.WriteLine("범위 내의 아이템을 선택하세요.");
                    Console.ReadLine();
                }
                else
                {
                    selectIndex = select;
                    stack.Push("DropConfirm");
                }
            }
        }
        public void UseConfirm()
        {
            Item selectItem = items[selectIndex];
            Util.TextColor($"해당 {selectItem.name}을 정말로 사용하시겠습니까? ( Y / N )", ConsoleColor.Red);

            ConsoleKey input = Console.ReadKey(true).Key;
            switch(input)
            {
                case ConsoleKey.Y:
                    if (selectItem is Potion)
                    {
                        stack.Push("Check");  
                    }
                    else
                    {
                        selectItem.Use();
                        Console.WriteLine($"{selectItem.name}을 사용하였습니다.");
                        items.Remove(selectItem); Console.ReadKey(true);
                        stack.Pop();
                    }
                    break;
                case ConsoleKey.N:
                    stack.Pop();
                    break;
                default:
                    break;
            }
        }
        public void DropConfirm()
        {
            Item selectItem = items[selectIndex];
            Util.TextColor($"해당 {selectItem.name}을 버리시면 다시 주울 수 없습니다.", ConsoleColor.Red);
            Util.TextColor($"정말로 버리시겠습니까? ( Y / N )", ConsoleColor.Red);

            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.Y:
                    Console.WriteLine($"{selectItem.name}을 버렸습니다.");
                    items.Remove(selectItem);
                    stack.Pop();
                    break;
                case ConsoleKey.N:
                    stack.Pop();
                    break;
                default:
                    break;
            }
        }

        public void Check()
        {
            Item selectItem = items[selectIndex];
            if (!(selectItem is Potion potion))
            {
                Console.WriteLine("선택한 아이템은 Potion이 아닙니다.");
                Console.ReadKey(true);
                stack.Pop();
                return;
            }
            int index = -1;
            int useCount = 0;
            
            GameManager.Player.Inventory.PrintAll();
            Console.WriteLine("아이템을 사용할 몬스터를 지정해주세요");
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.D1:
                    index = 0;
                    break;
                case ConsoleKey.D2:
                    index = 1;
                    break;
                case ConsoleKey.D3:
                    index = 2;
                    break;
                case ConsoleKey.D4:
                    index = 3;
                    break;
                case ConsoleKey.D5:
                    index = 4;
                    break;
                case ConsoleKey.D6:
                    index = 5;
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 1~6을 선택하세요.");
                    Console.ReadKey(true);
                    break;
            }
            Monster selectMonster = GameManager.Player.Inventory.monsters[index];
            if (index < 0 || index >= GameManager.Player.Inventory.monsters.Length)
            {
                Console.WriteLine("잘못된 몬스터 슬롯입니다.");
                Console.ReadKey(true);
                stack.Pop();
                return;
            }
            if (selectMonster == null)
            {
                Console.WriteLine("선택한 슬롯에 몬스터가 없습니다.");
                Console.ReadKey(true);
                stack.Pop();
                return;
            }
            if (selectMonster.CurHP >= selectMonster.MaxHP)
            {
                Console.WriteLine($"{selectMonster.Name}의 HP가 이미 최대입니다.");
                Console.ReadKey(true);
                stack.Pop();
                return;
            }
            Console.WriteLine($"사용할 개수를 선택하세요 (1 이상) 남은 개수 : {potion.count} 대상의 현재 체력 : {selectMonster.CurHP}");
            bool correctInput = false;
            do
            {
                if (int.TryParse(Console.ReadLine(), out useCount))
                {
                    if (useCount > 0 && useCount <= potion.count)
                    {
                        correctInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"1에서 {potion.count} 사이의 값을 입력하세요.");
                    }
                }
                else
                {
                    Console.WriteLine("유효한 숫자를 입력하세요.");
                }
            }
            while (!correctInput);
            selectItem.Use(selectMonster, useCount);
            Console.WriteLine($"{selectItem.name}을 사용하였습니다. {selectMonster.Name}의 HP가 30 회복되어서 {selectMonster.CurHP}가 되었습니다.");
            Console.ReadKey(true);
            stack.Clear();
        }

        public void Print()
        {
            if (items != null && items.Count > 0)
            {
                Console.WriteLine("==================아이템 목록==================");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] 이름 : {items[i].name} 갯수 :{items[i].count}개\n" +
                        $"아이템 정보 : {items[i].info}");
                }
                Console.WriteLine("==============================================");
            }
        }
    }
}
