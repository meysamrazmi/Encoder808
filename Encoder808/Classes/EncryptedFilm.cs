using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder808.Classes
{
    public class EncryptedFilm
    {
        public string nid { get; set; }
        public string title { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string extension { get; set; }
        public string new_name { get; set; }
        public string new_extension { get; set; }


        //"nid" : 17063,
        //"title" : "test",
        //"password" : "123546",
        //"name" : "nam2",
        //"extension" : "extension",
        //"new_name" : "new_name",  //should be unique
        //"new_extension" : "new_extension"
    }
}
