using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HW29_30
{
    public class Inventory
    {
        private List<Item> _items;

        public int CurrentSize => _items.Sum(item => item.Count);

        public int MaxSize { get; private set; }

        public IReadOnlyList<IReadOnlyItem> Items => _items;

        public Inventory(List<Item> items, int maxSize)
        {
            _items = new List<Item>(items);

            if (maxSize < 0)
            {
                Debug.LogError(nameof(maxSize));
                return;
            }

            MaxSize = maxSize;
        }

        public bool IsEnoughSpace(Item item) => CurrentSize + item.Count > MaxSize;

        public void Add(Item item)
        {
            if (IsEnoughSpace(item) == false)
                return;

            _items.Add(item);
        }

        public List<Item> GetItemsBy(string name, int count)
        {
            List<Item> selectedItems = new List<Item>();

            for (int i = 0; i < count; i++)
            {
                Item item = _items.First(item => item.Name == name);
                selectedItems.Add(item);
                _items.Remove(item);
            }

            return selectedItems;
        }
    }
}

namespace HW29_30
{
    public class Item : IReadOnlyItem
    {
        public string Name { get; private set; }
        public int Count { get; private set; }
    }
}

namespace HW29_30
{
    public interface IReadOnlyItem
    {
        string Name { get; }
        int Count { get; }
    }
}