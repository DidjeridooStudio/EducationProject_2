using HW29_30.HW29_30;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW29_30
{
    public class Inventory
    {
        private List<Item> _items1;

        private Dictionary<Item, int> _items;

        public int CurrentSize => _items.Values.Sum();

        public int MaxSize { get; }

        public IReadOnlyDictionary<IReadOnlyItem, int> Items => (IReadOnlyDictionary<IReadOnlyItem, int>)_items;

        public Inventory(Dictionary<Item, int> items, int maxSize)
        {
            _items = new Dictionary<Item, int>(items);

            if (maxSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxSize), "The max size cannot be negative or cannot be equal to zero");

            MaxSize = maxSize;
        }

        public bool IsEnoughSpace(Item item, int count) => CurrentSize + count <= MaxSize;

        public void Add(Item item, int count)
        {
            if (IsEnoughSpace(item, count) == false)
                throw new ArgumentOutOfRangeException(nameof(item), "Insufficient inventory space");

            _items.Add(item, count);
        }

        public Dictionary<Item, int> GetItemsBy(Item item, int count)
        {
            Dictionary<Item, int> selectedItems = new Dictionary<Item, int>();

            if (_items[item] >= count)
            {
                count = _items[item];
                _items.Remove(item);
            }
            else
            {
                _items[item] -= count;
            }

            selectedItems.Add(item, count);

            return selectedItems;
        }
    }
}

namespace HW29_30
{
    public class Item : IReadOnlyItem
    {
        public string Name { get; }
    }

    namespace HW29_30
    {
        public interface IReadOnlyItem
        {
            string Name { get; }
        }
    }
}