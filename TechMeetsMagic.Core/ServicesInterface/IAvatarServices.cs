using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;

namespace TechMeetsMagic.Core.ServicesInterface
{
    public interface IAvatarServices
    {
        Task<Avatar> DetailsAsync(Guid id);
        Task<Avatar> Create(AvatarDto dto);
        Task<Avatar> Update(AvatarDto dto);
        Task<Avatar> Delete(Guid id);
    }
}
