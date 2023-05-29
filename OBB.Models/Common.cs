using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OBB.Models
{
    public class Common
    {
       public enum Role {
        User=1,
        Admin=2,
        
        }
  
       

    }

}