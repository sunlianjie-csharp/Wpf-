using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolKit.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityToolKit.Messagers
{
    public class LoginInfoMessage : ValueChangedMessage<User>
    {
        public LoginInfoMessage(User value) : base(value)
        {
        }
    }
}
