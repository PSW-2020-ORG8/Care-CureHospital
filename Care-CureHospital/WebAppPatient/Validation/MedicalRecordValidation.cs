using Backend;
using Backend.Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebAppPatient.Dto;

namespace WebAppPatient.Validation
{
    public class MedicalRecordValidation
    {
        private Regex usernameRegex = new Regex(@"^[A-Za-zŠšĐđŽžČčĆć][A-Za-z0-9ŠšĐđŽžČčĆć]*$");
        private Regex lettersOnlyRegex = new Regex(@"^[A-ZŠĐŽČĆ][A-Za-zŠšĐđŽžČčĆć ]*$");
        private Regex jmbgRegex = new Regex(@"^[0-9]{13}$");
        private Regex personalCardRegex = new Regex(@"^[0-9]{9}$");
        private Regex healthInsuranceCardRegex = new Regex(@"^[0-9]{11}$");
        private Regex contactNumberRegex = new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
        private Regex eMailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

        public MedicalRecordValidation() { }

        public bool ValidateMedicalRecord(MedicalRecordDto medicalRecordDto)
        {
            if (!ValidateUsername(medicalRecordDto.Patient.Username) || !ValidatePassword(medicalRecordDto.Patient.Password, medicalRecordDto.ConfirmedPassword)
                || !ValidateLettersOnly(medicalRecordDto) || !ValidateJmbg(medicalRecordDto.Patient.Jmbg) || !ValidateIdentityCard(medicalRecordDto.Patient.IdentityCard)
                || !ValidateHealthInsuranceCard(medicalRecordDto.Patient.HealthInsuranceCard) || !ValidateDateOfBirth(medicalRecordDto.Patient.DateOfBirth)
                || !ValidateContactNumber(medicalRecordDto.Patient.ContactNumber) || !ValidateEMail(medicalRecordDto.Patient.EMail) || !EmptyAddress(medicalRecordDto))
            {
                return false;
            }
            return true;
        }

        private bool ValidateUsername(string username)
        {
            if(!ValidateString(username, usernameRegex))
            {
                return false;
            }
            else if (App.Instance().PatientService.DoesUsernameExist(username))
            {
                return false;
            }
            return true;           
        }

        private bool ValidatePassword(string password, string confirmedPassword)
        {
            if (!CheckIfStringIsEmptyOrNull(password) || !CheckIfStringIsEmptyOrNull(confirmedPassword))
            {
                return false;
            }
            else if (!password.Equals(confirmedPassword))
            {
                return false;
            }
            return true;
        }

        private bool ValidateLettersOnly(MedicalRecordDto dto)
        {
            if(!ValidateString(dto.Patient.Name, lettersOnlyRegex) 
                || !ValidateString(dto.Patient.ParentName, lettersOnlyRegex)
                    || !ValidateString(dto.Patient.Surname, lettersOnlyRegex))
            {
                return false;
            }
            return true;
        }

        private bool ValidateJmbg(string jmbg)
        {
            return ValidateString(jmbg, jmbgRegex);
        }

        private bool ValidateIdentityCard(string identityCard)
        {
            return ValidateString(identityCard, personalCardRegex);
        }

        private bool ValidateHealthInsuranceCard(string healthInsuranceCard)
        {
            return ValidateString(healthInsuranceCard, healthInsuranceCardRegex);
        }

        private bool ValidateContactNumber(string contactNumber)
        {
            return ValidateString(contactNumber, contactNumberRegex);
        }

        private bool ValidateEMail(string eMail)
        {
            return ValidateString(eMail, eMailRegex);
        }

        private bool EmptyAddress(MedicalRecordDto medicalRecordDto)
        {
            if(!CheckIfStringIsEmptyOrNull(medicalRecordDto.Patient.City.Name) 
                || !CheckIfStringIsEmptyOrNull(medicalRecordDto.Patient.City.PostCode.ToString())
                    || !CheckIfStringIsEmptyOrNull(medicalRecordDto.Patient.City.Address)
                        || !CheckIfStringIsEmptyOrNull(medicalRecordDto.Patient.City.Country.Name))
            {
                return false;
            }
            return true;
        }

        private bool ValidateDateOfBirth(DateTime dateOfBirth)
        {
            return CheckIfStringIsEmptyOrNull(dateOfBirth.ToString());
        }

        private bool CheckIfStringIsEmptyOrNull(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidateString(string input, Regex reg)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    return false;
                }
                else if (!reg.Match(input).Success)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

