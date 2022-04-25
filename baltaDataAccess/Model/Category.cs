using System;
namespace BaltaDataAccses.Model
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string Summary { get; set; }
        public bool Featured { get; set; }

    }
}