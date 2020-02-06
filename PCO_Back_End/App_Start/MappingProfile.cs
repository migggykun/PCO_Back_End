using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PCO_Back_End.DTOs;
using PCO_Back_End.Models.Accounts;

namespace PCO_Back_End.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Accounts Related
            Mapper.CreateMap<Account, AccountsDTO>();
            Mapper.CreateMap<AccountsDTO, Account>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<MembershipTypeDTO, MembershipType>();
            Mapper.CreateMap<PRCDetail, PRCDetailsDTO>();
            Mapper.CreateMap<PRCDetailsDTO, PRCDetail>();
            Mapper.CreateMap<LoginCredential, LoginCredentialDTO>();
            Mapper.CreateMap<LoginCredentialDTO, LoginCredential>();
        }
    }
}