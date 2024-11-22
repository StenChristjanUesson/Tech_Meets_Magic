using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;

namespace TechMeetsMagic.Core.ServicesInterface
{
    public interface IAvatarServices
    {
        Task<Avatar> DetailsAsync(Guid id);
    }
}
