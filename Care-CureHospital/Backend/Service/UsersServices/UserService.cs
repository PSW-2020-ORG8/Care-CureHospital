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

namespace Service.UsersServices
{
    public class UserService : IService<User, int>
    {
        public IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
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
            foreach(User user in this.GetAllEntities())
                if (user.UserName.Equals(username))
                    return user.Password;
            return "";
        }

        public bool IsPasswordValid(String password)
        {
            throw new NotImplementedException();
        }

        public bool IsUsernameExist(String username)
        {
            foreach (User user in this.GetAllEntities())
                if (user.UserName.Equals(username))
                    return true;
            return false;
        }


        public bool DoesJmbgExsist(String jmbg)
        {
            foreach (User user in GetAllEntities())
            {
                if (user.Jmbg.Equals(jmbg))
                    return true;
            }
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