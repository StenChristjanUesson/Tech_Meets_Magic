using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;

namespace TechMeetsMagic.Core.ServicesInterface
{
    public interface ITheUserMadeOpenWorldService
    {
        Task<TheUserMadeOpenWorld> DetailsAsync(Guid id);
        Task<TheUserMadeOpenWorld> Create(TheUserMadeOpenWorldDto dto);
        Task<TheUserMadeOpenWorld> Update(TheUserMadeOpenWorldDto dto);
        Task<TheUserMadeOpenWorld> Delete(Guid id);
    }
}
