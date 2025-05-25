using System;
using System.Collections.Generic;
using System.Linq;
using HW_oop;

namespace HW_oop
{
    public class Library
    {
        private List<LibraryItem> items;

        // Constructor
        public Library()
        {
            items = new List<LibraryItem>();
        }

        // Existing method to add items
        public void AddItem(LibraryItem item)
        {
            items.Add(item);
        }

        // Existing method to search by title, updated to use extension method
        public LibraryItem SearchByTitle(string keyword)
        {
            return items.FirstOrDefault(item => item.Title.ContainsIgnoreCase(keyword));
        }

        // Existing method to display all items
        public void DisplayAllItems()
        {
            foreach (var item in items)
            {
                item.DisplayInfo();
            }
        }

        // New method with ref parameter
        public bool UpdateItemTitle(int itemId, ref string title)
        {
            var item = items.Find(i => i.Id == itemId);
            if (item == null)
                return false;

            string originalTitle = item.Title;
            item.Title = title; // Sử dụng tham số ref
            title = originalTitle; // Cập nhật tham số ref với tiêu đề gốc
            return true;
        }

        // New method with ref return
        //public ref LibraryItem GetItemReference(int itemId)
        //{
        //    var index = items.FindIndex(i => i.Id == itemId);
        //    if (index == -1)
        //        throw new KeyNotFoundException($"Item with ID {itemId} not found");

        //    return ref items[index];
        //}
    }
}
