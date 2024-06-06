﻿using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Members.Commands.AddMember
{
    public class AddMemberCommandHandler(IMemberRepository _memberRepository) : IRequestHandler<AddMemberCommand, Member>
    {
        public async Task<Member> Handle(AddMemberCommand request, CancellationToken cancellationToken)
        {

            Member member = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };

            var result = await _memberRepository.AddAsync(member);
            await _memberRepository.SaveAsync();
            
            if (result) return member;
            throw new Exception("Something went wrong!");
        }
    }
}