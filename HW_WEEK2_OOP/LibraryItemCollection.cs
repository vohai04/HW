using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_oop
{
   public class LibraryItemCollection<T> where T : LibraryItem
    {
        private readonly List<T> _items = new List<T>();

        // Thêm một mục vào bộ sưu tập
        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }

        // Lấy mục tại chỉ số được chỉ định
        public T GetItem(int index)
        {
            if (index < 0 || index >= _items.Count)
                throw new IndexOutOfRangeException($"Chỉ số {index} nằm ngoài phạm vi của bộ sưu tập.");
            return _items[index];
        }

        // Tìm mục theo Id
        public T? FindById(int id)
        {
            return _items.FirstOrDefault(item => item.Id == id);
        }

        // Xóa mục khỏi bộ sưu tập
        public bool Remove(T item)
        {
            if (item == null)
                return false;
            return _items.Remove(item);
        }

        // Thuộc tính đếm số mục
        public int Count => _items.Count;
    }
}