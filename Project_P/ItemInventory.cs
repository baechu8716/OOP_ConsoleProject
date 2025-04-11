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
        public bool isItemUsed { get; set; }
        public ItemInventory()
        {
            items = new List<Item>();
            stack = new Stack<string>();
        }
        public void UseItem(int index)
        {
            items[index].Use();
            isItemUsed = true;
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
            isItemUsed = false;
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
                if (GameManager.isBattleOn == false)
                {
                    Console.WriteLine("2. 버린다.");
                }
                Console.WriteLine("돌아가려면 0번");
                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        stack.Push("UseMenu");
                        break;
                    case ConsoleKey.D2:
                        if (GameManager.isBattleOn == false)
                        {
                            stack.Push("DropMenu");
                        } 
                        break;
                    case ConsoleKey.D0:
                        stack.Clear();
                        break;
                    default: break;

                }
            }     
            else
            {
                Console.WriteLine("아이템이 없습니다.");
                Console.WriteLine("0키를 두번 눌러 종료.");
                if (Console.ReadKey(true).Key == ConsoleKey.D0)
                {
                    stack.Clear();
                }
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
                isItemUsed = false;
            }
            else
            {
                int select = (int)input - (int)ConsoleKey.D1;
                if (select < 0 || select >= items.Count)
                {
                    Console.WriteLine("범위 내의 아이템을 선택하세요.");
                    Console.ReadKey(true);
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
                    Console.ReadKey(true);
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
                    selectItem.Use();
                    stack.Clear();
                    Console.ReadKey(true);
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
                    Console.WriteLine($"몇개 버리시겠습니까? 현재 아이템 개수 : {selectItem.count}");
                    bool isTrue = false;
                    do
                    {
                        if(int.TryParse(Console.ReadLine(),out int useCount))
                        {
                            if (useCount > 0 && useCount < selectItem.count)
                            {
                                selectItem.count -= useCount;
                                isTrue = true;
                            }
                            else
                            {
                                Console.WriteLine($"1부터 {selectItem.count}사이의  값을 입력하세요.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("유효한 숫자를 입력해주세요");
                        }
                    }
                    while (!isTrue);
                    Console.WriteLine($"{selectItem.name}을 버렸습니다. 남은 아이템 개수 : {selectItem.count}");
                    if (selectItem.count <= 0)
                    {
                        items.Remove(selectItem);
                    }
                    Console.ReadKey(true);
                    stack.Pop();
                    break;
                case ConsoleKey.N:
                    stack.Pop();
                    break;
                default:
                    break;
            }
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
