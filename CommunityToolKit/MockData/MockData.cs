using CommunityToolKit.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityToolKit.MockData
{
    public class MockData
    {
        public static List<ViewUser> Users = new List<ViewUser>
        {
            new ViewUser { Id = 1, Name="张三1" },
             new ViewUser { Id = 2, Name="张三2" },
             new ViewUser { Id = 3, Name="张三3" }
        };
    }
}
