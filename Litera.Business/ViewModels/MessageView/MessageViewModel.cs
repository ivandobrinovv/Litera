using Litera.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litera.Business.ViewModels.MessageView
{
    public class MessageViewModel
    {
        public byte[]? Content { get; set; } = null;
        public string DataType { get; set; } = string.Empty;
        public DateTime DateOfCreation { get; set; }
        public DateTime LastEditedTime { get; set; }
        public bool IsRead { get; set; }
        public Guid UserId { get; set; }
    }
}
