using System;

namespace Healthcare020.Mobile.Models
{
    public class CollectionViewItem
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string PrimaryTextTitle { get; set; }
        public string PrimaryTextContent { get; set; }
        public bool ItemFlag { get; set; }
    }
}