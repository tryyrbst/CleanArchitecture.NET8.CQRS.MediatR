﻿using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Members.Queries.ListMembers
{
    public class ListMembersQueryHandler(IUnitOfWork _uow) : IRequestHandler<ListMembersQuery, List<Member>>
    {
        public async Task<List<Member>> Handle(ListMembersQuery request, CancellationToken cancellationToken)
        {
            return await _uow.MemberRepository.GetAllAsync();
        }
    }
}
