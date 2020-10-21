using System.Collections.Generic;

namespace dotnetthanks
{
    public class Release
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Tag { get; set; }
        public List<Contributor> Contributors { get; set; } = new List<Contributor>();

        public int Contributions { get; set; }

    }

}