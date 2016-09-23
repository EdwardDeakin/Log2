using System;
using SQLite.Net;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FirstAid.Database
{
    class CategoryDatabase
    {
        private SQLiteConnection _Database;

        public CategoryDatabase()
        {
            System.Diagnostics.Debug.WriteLine("I'm in the category database");
            _Database = DependencyService.Get<IDatabaseConnection>().GetConnection();

            // Create the table if it doesn't not exist.
            _Database.CreateTable<Category>();

            // Check how many rows are in the table, if it's empty. Add the initial data.
            if(_Database.Table<Category>().Count() == 0)
            {
                // Add data here.
                _Database.Insert(new Category { CategoryName = "Burns" });
                _Database.Insert(new Category { CategoryName = "Broken Bones" });
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            // Get all of the categories from the database table.
            return _Database.Table<Category>();
        }
    }
}
