using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishExam.Models.Entities
{
    public class User: BaseModel
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public int AuthorityId { get; set; }
        [ForeignKey("AuthorityId")]
        public Authority Authority { get; set; }
       
    }
}
