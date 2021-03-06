﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI;
using Domain.Persistence;
using PhoneNumbers;

namespace Domain.Business
{
	public class BusinessCode
	{
		private PersistenceCode _persistence;

        public BusinessCode()
		{
			_persistence = new PersistenceCode();
		}
        
        #region Get
        public List<ClientCode> GetClients(string sortingPar)
		{
            return _persistence.GetClients(sortingPar);
        }
        public List<ContractCode> GetContracts(string sortingPar)
        {
            return _persistence.GetContracts(sortingPar);
        }
        public List<CRACode> GetCRAs(string sortingPar)
        {
            return _persistence.GetCRAs(sortingPar);
        }
        public List<DepartmentCode> GetDepartments(string sortingPar)
        {
            return _persistence.GetDepartments(sortingPar);
        }
        public List<DoctorCode> GetDoctors(string sortingPar)
        {
            return _persistence.GetDoctors(sortingPar);
        }
        public List<EvaluationCode> GetEvaluations(string sortingPar)
        {
            return _persistence.GetEvaluations(sortingPar);
        }
        public List<HospitalCode> GetHospitals(string sortingPar)
        {
            return _persistence.GetHospitals(sortingPar);
        }
        public List<ProjectCode> GetProjects(string sortingPar)
        {
            return _persistence.GetProjects(sortingPar);
        }
        public List<ProjectManagerCode> GetProjectManagers(string sortingPar)
        {
            return _persistence.GetProjectManagers(sortingPar);
        }
        public List<StudyCoordinatorCode> GetStudyCoordinators(string sortingPar)
        {
            return _persistence.GetStudyCoordinators(sortingPar);
        }
        public List<UserCode> GetUsers(string sortingPar)
        {
            return _persistence.GetUsers(sortingPar);
        }
        #endregion

        #region GetRelation

        #region Doctor + Hospital
        public List<int> GetRelationDoctorHasHospitals(int Doctor_ID_p2)
        {
            return _persistence.GetRelationDoctorHasHospitals(Doctor_ID_p2);
        }

        public List<int> GetRelationHospitalHasDoctors(int Hospital_ID_p2)
        {
            return _persistence.GetRelationDoctorHasHospitals(Hospital_ID_p2);
        }
        #endregion

        #region StudyCoordinator + Doctor
        public List<int> GetRelationStudyCoordinatorHasDoctors(int StudyCoordinator_ID_p2)
        {
            return _persistence.GetRelationStudyCoordinatorHasDoctors(StudyCoordinator_ID_p2);
        }

        public List<int> GetRelationDoctorHasStudyCoordinators(int Doctor_ID_p2)
        {
            return _persistence.GetRelationDoctorHasStudyCoordinators(Doctor_ID_p2);
        }
        #endregion

        #region Project + CRA
        public List<int> GetRelationProjectHasCRAs(int StudyCoordinator_ID_p2)
        {
            return _persistence.GetRelationProjectHasCRAs(StudyCoordinator_ID_p2);
        }

        public List<int> GetRelationCRAHasProjects(int Doctor_ID_p2)
        {
            return _persistence.GetRelationCRAHasProjects(Doctor_ID_p2);
        }
        #endregion

        #region Project + Doctor
        public List<int> GetRelationProjectHasDoctors(int StudyCoordinator_ID_p2)
        {
            return _persistence.GetRelationProjectHasDoctors(StudyCoordinator_ID_p2);
        }

        public List<int> GetRelationDoctorHasProjects(int Doctor_ID_p2)
        {
            return _persistence.GetRelationDoctorHasProjects(Doctor_ID_p2);
        }
        #endregion

        #region Project + Hospital
        public List<int> GetRelationProjectHasHospitals(int StudyCoordinator_ID_p2)
        {
            return _persistence.GetRelationProjectHasHospitals(StudyCoordinator_ID_p2);
        }

        public List<int> GetRelationHospitalHasProjects(int Doctor_ID_p2)
        {
            return _persistence.GetRelationHospitalHasProjects(Doctor_ID_p2);
        }
        #endregion

        #region Project + Project Manager
        public List<int> GetRelationProjectHasProjectManagers(int StudyCoordinator_ID_p2)
        {
            return _persistence.GetRelationProjectHasProjectManagers(StudyCoordinator_ID_p2);
        }

        public List<int> GetRelationProjectManagerHasProjects(int Doctor_ID_p2)
        {
            return _persistence.GetRelationProjectManagerHasProjects(Doctor_ID_p2);
        }
        #endregion
        //------------------------------------------------------------------------------ 1 op 1

        public int GetRelationHospitalHasDepartment(int Department_ID_p2)
        {
            return _persistence.GetRelationHospitalHasDepartment(Department_ID_p2);
        }
        #endregion

        #region GetDropDownContent
        public List<List<string>> GetClientDropDownContent()
        {
            return _persistence.GetClientDropDown();
        }
        public List<List<string>> GetCRADropDownContent()
        {
            return _persistence.GetCRADropDown();
        }
        public List<List<string>> GetContractDropDown()
        {
            return _persistence.GetContractDropDown();
        }
        public List<List<string>> GetDoctorDropDownContent()
        {
            return _persistence.GetDoctorDropDown();
        }
        public List<List<string>> GetHospitalDropDownContent()
        {
            return _persistence.GetHospitalDropDown();
        }
        public List<List<string>> GetProjectDropDownContent()
        {
            return _persistence.GetProjectDropDown();
        }
        public List<List<string>> GetProjectManagerDropDownContent()
        {
            return _persistence.GetProjectManagerDropDown();
        }
        public List<List<string>> GetStudyCoordinatorDropDownContent()
        {
            return _persistence.GetStudyCoordinatorDropDown();
        }
        #endregion
        
        #region Add
        public void AddClient(ClientCode client)
        {
            _persistence.AddClient(client);
        }
        public void AddContract(ContractCode contract)
        {
            _persistence.AddContract(contract);
        }
        public void AddCRA(CRACode cra)
        {
            _persistence.AddCRA(cra);
        }
        public void AddDepartment(DepartmentCode department)
        {
            _persistence.AddDepartment(department);
        }
        public void AddDoctor(DoctorCode doctor)
        {
            _persistence.AddDoctor(doctor);
        }
        public void AddEvaluation(EvaluationCode evaluation)
        {
            _persistence.AddEvaluation(evaluation);
        }
        public void AddHospital(HospitalCode hospital)
        {
            _persistence.AddHospital(hospital);
        }
        public void AddProject(ProjectCode project)
        {
            _persistence.AddProject(project);
        }
        public void AddProjectManager(ProjectManagerCode projectmanager)
        {
            _persistence.AddProjectManager(projectmanager);
        }
        public void AddStudyCoordinator(StudyCoordinatorCode studycoordinator)
        {
            _persistence.AddStudyCoordinator(studycoordinator);
        }
        public void AddUser(UserCode user)
        {
            _persistence.AddUser(user);
        }
        #endregion

        #region AddRelation
        public void AddHospitalToDoctor(int hospital_id_p2, int doctor_id_p2)
        {
            _persistence.AddHospitalToDoctor(hospital_id_p2, doctor_id_p2);
        }
        public void AddDoctorToStudyCoordinator(int doctor_id_p2, int studycoordinator_id_p2)
        {
            _persistence.AddDoctorToStudyCoordinator(doctor_id_p2, studycoordinator_id_p2);
        }
        public void AddCRAToProject(int cra_id_p, int project_id_p)
        {
            _persistence.AddCRAToProject(cra_id_p, project_id_p);
        }
        public void AddDoctorToProject(int doctor_id_p, int project_id_p)
        {
            _persistence.AddDoctorToProject(doctor_id_p, project_id_p);
        }
    
        public void AddHospitalToProject(int hospital_id_p, int project_id_p)
        {
            _persistence.AddHospitalToProject(hospital_id_p, project_id_p);
        }
        public void AddProjectManagerToProject(int projectmanager_id_p, int project_id_p)
        {
            _persistence.AddProjectManagerToProject(projectmanager_id_p, project_id_p);
        }
        #endregion
        
        #region Update
        public void UpdateClient(ClientCode client)
        {
            _persistence.UpdateClient(client);
        }
        public void UpdateContract(ContractCode contract)
        {
            _persistence.UpdateContract(contract);
        }
        public void UpdateCRA(CRACode cra)
        {
            _persistence.UpdateCRA(cra);
        }
        public void UpdateDepartment(DepartmentCode department)
        {
            _persistence.UpdateDepartment(department);
        }
        public void UpdateDoctor(DoctorCode doctor)
        {
            _persistence.UpdateDoctor(doctor);
        }
        public void UpdateEvaluation(EvaluationCode evaluation)
        {
            _persistence.UpdateEvaluation(evaluation);
        }
        public void UpdateHospital(HospitalCode hospital)
        {
            _persistence.UpdateHospital(hospital);
        }
        public void UpdateProject(ProjectCode project)
        {
            _persistence.UpdateProject(project);
        }
        public void UpdateProjectManager(ProjectManagerCode projectmanager)
        {
            _persistence.UpdateProjectManager(projectmanager);
        }
        public void UpdateStudyCoordinator(StudyCoordinatorCode studycoordinator)
        {
            _persistence.UpdateStudyCoordinator(studycoordinator);
        }
        public void UpdateUser(UserCode user)
        {
            _persistence.UpdateUser(user);
        }
        #endregion

        #region UpdateRelation
        //-------------------------------------------------------------------------
        #endregion

        #region Delete
        public void DeleteClient(int id_p2)
        {
            _persistence.DeleteClient(id_p2);
        }
        public void DeleteContract(int id_p2, string sortingPar_p2)
        {
            _persistence.DeleteContract(id_p2, sortingPar_p2);
        }
        public void DeleteCRA(int id_p2)
        {
            _persistence.DeleteCRA(id_p2);
        }
        public void DeleteDepartment(int id_p2, string sortingPar_p2)
        {
            _persistence.DeleteDepartment(id_p2, sortingPar_p2);
        }
        public void DeleteDoctor(int id_p2)
        {
            _persistence.DeleteDoctor(id_p2);
        }
        public void DeleteEvaluation(int id_p2, string sortingPar_p2)
        {
            _persistence.DeleteEvaluation(id_p2, sortingPar_p2);
        }
        public void DeleteHospital(int id_p2)
        {
            _persistence.DeleteHospital(id_p2);
        }
        public void DeleteProject(int id_p2)
        {
            _persistence.DeleteProject(id_p2);
        }
        public void DeleteProjectManager(int id_p2)
        {
            _persistence.DeleteProjectManager(id_p2);
        }
        public void DeleteStudyCoordinator(int id_p2)
        {
            _persistence.DeleteStudyCoordinator(id_p2);
        }
        public void DeleteUser(int id_p2)
        {
            _persistence.DeleteUser(id_p2);
        }
        #endregion

        #region DeleteRelation

        #region Doctor + Hospital
        public void DeleteRelationDoctorHasHospitals(int doctor_id_p2)
        {
            _persistence.DeleteRelationDoctorHasHospitals(doctor_id_p2);
        }

        public void DeleteRelationHospitalHasDoctors(int doctor_id_p2)
        {
            _persistence.DeleteRelationHospitalHasDoctors(doctor_id_p2);
        }
        #endregion

        #region Study Coordinator + Doctor
        public void DeleteRelationStudyCoordinatorHasDoctors(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationStudyCoordinatorHasDoctors(studycoordinator_id_p2);
        }

        public void DeleteRelationDoctorHasStudyCoordinators(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationDoctorHasStudyCoordinators(studycoordinator_id_p2);
        }
        #endregion

        #region Project + CRA
        public void DeleteRelationProjectHasCRAs(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationProjectHasCRAs(studycoordinator_id_p2);
        }

        public void DeleteRelationCRAHasProjects(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationCRAHasProjects(studycoordinator_id_p2);
        }
        #endregion

        #region Project + Doctor
        public void DeleteRelationProjectHasDoctors(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationProjectHasDoctors(studycoordinator_id_p2);
        }

        public void DeleteRelationDoctorHasProjects(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationDoctorHasProjects(studycoordinator_id_p2);
        }
        #endregion

        #region Project + Hospital
        public void DeleteRelationProjectHasHospitals(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationProjectHasHospitals(studycoordinator_id_p2);
        }

        public void DeleteRelationHospitalHasProjects(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationHospitalHasProjects(studycoordinator_id_p2);
        }
        #endregion

        #region Project + Project Manager
        public void DeleteRelationProjectHasProjectManagers(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationProjectHasProjectManagers(studycoordinator_id_p2);
        }

        public void DeleteRelationProjectManagerHasProjects(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationProjectManagerHasProjects(studycoordinator_id_p2);
        }
        #endregion

        #endregion
        
        #region Search
        public List<ClientCode> SearchClients(string sortingPar)
        {
            return _persistence.SearchClients(sortingPar);
        }
        public List<ContractCode> SearchContracts(string sortingPar)
        {
            return _persistence.SearchContracts(sortingPar);
        }
        public List<CRACode> SearchCRAs(string sortingPar)
        {
            return _persistence.SearchCRAs(sortingPar);
        }
        public List<DepartmentCode> SearchDepartments(string sortingPar)
        {
            return _persistence.SearchDepartments(sortingPar);
        }
        public List<DoctorCode> SearchDoctors(string sortingPar)
        {
            return _persistence.SearchDoctors(sortingPar);
        }
        public List<EvaluationCode> SearchEvaluations(string sortingPar)
        {
            return _persistence.SearchEvaluations(sortingPar);
        }
        public List<HospitalCode> SearchHospitals(string sortingPar)
        {
            return _persistence.SearchHospitals(sortingPar);
        }
        public List<ProjectManagerCode> SearchProjectManagers(string sortingPar)
        {
            return _persistence.SearchProjectManagers(sortingPar);
        }
        public List<ProjectCode> SearchProjects(string sortingPar)
        {
            return _persistence.SearchProjects(sortingPar);
        }
        public List<StudyCoordinatorCode> SearchStudyCoordinators(string sortingPar)
        {
            return _persistence.SearchStudyCoordinators(sortingPar);
        }
        #endregion
        
        #region Control

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {

            }
            return match.Groups[1].Value + domainName;
        }

        public bool IsValidEmail(string parEmail)
		{
            bool invalid = false;
            if (String.IsNullOrEmpty(parEmail))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                parEmail = Regex.Replace(parEmail, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid email format.
            try
            {
                return Regex.IsMatch(parEmail,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public bool IsValidPhone(string parNumber)
        {
            string number = PhoneNumberUtil.NormalizeDigitsOnly(parNumber);
            return PhoneNumberUtil.IsViablePhoneNumber(number);
        }

        public string BeginUpperCase(string word)
        {
            if(word != "")
            {
                word = word.First().ToString().ToUpper() + word.Substring(1);
            }
            else
            {
                word = "";
            }
            return word;
        }
        #endregion

        #region UserWarning
        //public static void MessageBoxShow(this Page Page, String Message)
        //{
        //    Page.ClientScript.RegisterStartupScript(
        //       Page.GetType(),
        //       "MessageBox",
        //       "<script language='javascript'>alert('" + Message + "');</script>"
        //    );
        //}
        #endregion
        
    }
}
