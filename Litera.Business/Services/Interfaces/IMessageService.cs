using Litera.Business.ViewModels.MessageView;
using Litera.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litera.Business.Services.Interfaces
{
    public interface IMessageService : IBaseService<Message, MessageViewModel>
    {

    }
}
