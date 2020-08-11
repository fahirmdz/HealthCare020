using System.Collections.Generic;

namespace Healthcare020.WinUI.Models
{
    public class Person
    {
        public string PersonId { get; set; }
        public IList<string> PersistedFaceIds { get; set; }
        public string Name { get; set; }
        public string UserData { get; set; }
    }
}