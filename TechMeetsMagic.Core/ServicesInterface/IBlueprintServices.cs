using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;

namespace TechMeetsMagic.Core.ServicesInterface
{
    public interface IBlueprintServices
    {
        Task<Blueprint> DetailsAsync(Guid id);
        Task<Blueprint> Create(BlueprintDto dto);
        Task<Blueprint> Update(BlueprintDto dto);
        Task<Blueprint> Delete(Guid id);
    }
}
