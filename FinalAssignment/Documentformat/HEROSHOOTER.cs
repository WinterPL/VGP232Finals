using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentformat
{
    public class HEROSHOOTER
    {
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Appearence { get; set; }
        public string Lore { get; set; }
        public List<string> PicPaths { get; set; }

        public Skill Skill1 { get; set; }
        public Skill Skill2 { get; set; }
        public Skill Skill3 { get; set; }
        public Skill ULT { get; set; }
    }
}
