/***********************************************************************
 * Module:  UserService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.UserService
 ***********************************************************************/

using Model.AllActors;
using Model.Doctor;
using System;
using System.Collections.Generic;
using Repository.UsersRepository;
using Backend;
using Microsoft.Extensions.Options;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Backend.Service.UsersServices;

namespace Service.UsersServices
{
    public class UserService : IService<User, int>
    {
        public IUserRepository userRepository;
        public PatientService patientService;
        public SystemAdministratorService systemAdministratorService;

        public UserService(IUserRepository userRepository, PatientService patientService, SystemAdministratorService systemAdministratorService)
        {
            this.userRepository = userRepository;
            this.patientService = patientService;
            this.systemAdministratorService = systemAdministratorService;
        }

        public User Authenticate(string username, string password, byte[] secretKey)
        {
            var user = GetAllPatientsAndSystemAdministrators().SingleOrDefault(user => user.Username == username && user.Password == password);

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = secretKey;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public IEnumerable<User> GetAllPatientsAndSystemAdministrators()
        {
            List<User> users = new List<User>();
            users.AddRange(patientService.GetAllEntities());
            users.AddRange(systemAdministratorService.GetAllEntities());
            return users;
        }

        public User Login(String username, String password)
        {
            if (password.Equals(FindPasswordByUsername(username)))
                return userRepository.GetUserByUsername(username);
            else
                return null;
        }

        public String FindPasswordByUsername(String username)
        {
            foreach(User user in GetAllEntities())
                if (user.Username.Equals(username))
                    return user.Password;
            return "";
        }

        public bool IsPasswordValid(String password)
        {
            throw new NotImplementedException();
        }

        public bool DoesUsernameExist(String username)
        {
            foreach (User user in GetAllEntities())
                if (user.Username.Equals(username))
                    return true;

            return false;
        }

        public bool DoesJmbgExsist(String jmbg)
        {
            foreach (User user in GetAllEntities())
                if (user.Jmbg.Equals(jmbg))
                    return true;
            return false;
        }

        public List<Doctor> GetAllDoctors()
        {
            return userRepository.GetAllDoctors();
        }

        public List<Patient> GetAllPatients()
        {
            return userRepository.GetAllPatients();
        }

        public List<Secretary> GetAllSecretaries()
        {
            return userRepository.GetAllSecretaries();
        }

        public List<Manager> GetAllManagers()
        {
            return userRepository.GetAllManagers();
        }

        public List<Doctor> GetDoctorBySpecialitation(Specialitation specialitation)
        {
            return userRepository.GetDoctorBySpecialitation(specialitation);
        }

        public User GetUserByUsername(String username)
        {
            return userRepository.GetUserByUsername(username);
        }

        public User GetUserByJMBG(String jmbg)
        {
            return userRepository.GetUserByJMBG(jmbg);
        }

        public User GetEntity(int id)
        {
            return userRepository.GetEntity(id);
        }

        public IEnumerable<User> GetAllEntities()
        {
            return userRepository.GetAllEntities();
        }

        public User AddEntity(User entity)
        {
            return userRepository.AddEntity(entity);
        }

        public void UpdateEntity(User entity)
        {
            userRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(User entity)
        {
            userRepository.DeleteEntity(entity);
        }
    }
}