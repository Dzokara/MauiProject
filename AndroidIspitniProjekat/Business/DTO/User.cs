using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidIspitniProjekat.Business.DTO
{
    public class User : TokenDto
    {
        public string Username { get; set; }
        public int Id { get; set; }
        
        public string Role {  get; set; }   
    }
}
