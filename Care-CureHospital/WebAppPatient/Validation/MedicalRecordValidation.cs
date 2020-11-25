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
            else
            {
                return true;
            }
        }

        private bool ValidateUsername(string username)
        {
            try
            {
                Match match = usernameRegex.Match(username);     
                
                if (string.IsNullOrEmpty(username))
                {
                    return false;
                }
                else if (!match.Success)
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

        private bool ValidatePassword(string password, string confirmedPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmedPassword))
                {
                    return false;
                }
                else if (!password.Equals(confirmedPassword))
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

        private bool ValidateLettersOnly(MedicalRecordDto dto)
        {
            try
            {
                Match matchName = lettersOnlyRegex.Match(dto.Patient.Name);
                Match matchParentName = lettersOnlyRegex.Match(dto.Patient.ParentName);
                Match matchSurame = lettersOnlyRegex.Match(dto.Patient.Surname);

                if (string.IsNullOrEmpty(dto.Patient.Name) || string.IsNullOrEmpty(dto.Patient.ParentName) || string.IsNullOrEmpty(dto.Patient.Surname))
                {
                    return false;
                }
                else if (!matchName.Success || !matchParentName.Success || !matchSurame.Success)
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

        private bool ValidateJmbg(string jmbg)
        {
            try
            {
                Match match = jmbgRegex.Match(jmbg);

                if (string.IsNullOrEmpty(jmbg))
                {
                    return false;
                }
                else if (!match.Success)
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

        private bool ValidateIdentityCard(string identityCard)
        {
            try
            {
                Match match = personalCardRegex.Match(identityCard);

                if (string.IsNullOrEmpty(identityCard))
                {
                    return false;
                }
                else if (!match.Success)
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

        private bool ValidateHealthInsuranceCard(string healthInsuranceCard)
        {
            try
            {
                Match match = healthInsuranceCardRegex.Match(healthInsuranceCard);

                if (string.IsNullOrEmpty(healthInsuranceCard))
                {
                    return false;
                }
                else if (!match.Success)
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

        private bool ValidateDateOfBirth(DateTime dateOfBirth)
        {
            try
            {
                if (string.IsNullOrEmpty(dateOfBirth.ToString()))
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

        private bool ValidateContactNumber(string contactNumber)
        {
            try
            {
                Match match = contactNumberRegex.Match(contactNumber);

                if (string.IsNullOrEmpty(contactNumber))
                {
                    return false;
                }
                else if (!match.Success)
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

        private bool ValidateEMail(string eMail)
        {
            try
            {
                Match match = eMailRegex.Match(eMail);

                if (string.IsNullOrEmpty(eMail))
                {
                    return false;
                }
                else if (!match.Success)
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

        private bool EmptyAddress(MedicalRecordDto medicalRecordDto)
        {
            try
            {
                if (string.IsNullOrEmpty(medicalRecordDto.Patient.City.Name) || string.IsNullOrEmpty(medicalRecordDto.Patient.City.PostCode.ToString()) ||
                    string.IsNullOrEmpty(medicalRecordDto.Patient.City.Address) || string.IsNullOrEmpty(medicalRecordDto.Patient.City.Country.Name))
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

