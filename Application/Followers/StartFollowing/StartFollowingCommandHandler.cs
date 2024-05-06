﻿using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using SharedKernel;

namespace Application.Followers.StartFollowing
        private readonly FollowerService _followerService;
        private readonly IUnitOfWork _unitOfWork;


        public StartFollowingCommandHandler(
            IUserRepository userRepository,
            FollowerService followerService,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _followerService = followerService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(StartFollowingCommand command, CancellationToken cancellationToken)
            {
                return UserErrors.NotFound(command.UserId);
            }
            if (followed is null)
            {
                return UserErrors.NotFound(command.FollowedId);
            }
            {
                return Result.Failure(result.Error);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
    }