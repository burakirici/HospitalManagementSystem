using HospitalManagementSystem.Business.DataProtection;
using HospitalManagementSystem.Business.Operations.User.Dtos;
using HospitalManagementSystem.Business.Types;
using HospitalManagementSystem.Data.Entities;
using HospitalManagementSystem.Data.Enums;
using HospitalManagementSystem.Data.Repositories;
using HospitalManagementSystem.Data.UnitOfwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business.Operations.User
{
    
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IDataProtection _dataProtection;
        public UserManager(IUnitOfWork unitOfWork, IRepository<UserEntity> userRepository, IDataProtection protector)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _dataProtection = protector;
        }
        public async Task<ServiceMessage> AddUser(AddUserDto user)
        {
            var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == user.Email.ToLower());

            if(hasMail.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "E-mail adress is already exist!"
                };
            }

            var userEntity = new UserEntity()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = _dataProtection.Protect(user.Password),
                BirthDate = user.BirthDate,
                Role = UserType.Patient
            };

            _userRepository.Add(userEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("An error occurred during user registration");
            }

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public ServiceMessage<UserInfoDto> LoginUser(LoginUserDto user)
        {
            var userEntity = _userRepository.Get(x => x.Email.ToLower() == user.Email.ToLower());

            if(userEntity is null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Username or password is incorrect!"
                };
            }

            var unprotectedPassword = _dataProtection.UnProtect(userEntity.Password);

            if(unprotectedPassword == user.Password)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = true,
                    Data = new UserInfoDto
                    {
                        Email = userEntity.Email,
                        FirstName = userEntity.FirstName,
                        LastName = userEntity.LastName,
                        Role = userEntity.Role
                    }
                };
            }
            else
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Username or Password is incorrect!"
                };
            }
        }
    }
}
