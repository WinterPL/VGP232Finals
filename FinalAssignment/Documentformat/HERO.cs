using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentformat
{
    public class Skill
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
    public class HERO
    {
        public string type = "hero";
        public string Name { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string kind { get; set; } = string.Empty;
        public string sex { get; set; } = string.Empty;
        public string Appearence { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Skill SkillP = new Skill();
        public Skill Skill1 = new Skill();
        public Skill Skill2 = new Skill();
        public Skill Skill3 = new Skill();
        public Skill ULT = new Skill();
    }
}
