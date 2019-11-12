using System;
using System.Collections.Generic;

namespace OilStationCoreAPI.Model
{
    public partial class Entry
    {
        public Guid Id { get; set; }
        public string StaffName { get; set; }
        public bool Sex { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool? MaritalStatus { get; set; }
        public decimal? Height { get; set; }
        public int? HighestEducation { get; set; }
        public string Major { get; set; }
        public string ForeginLanguageAptitude { get; set; }
        public string Idnumber { get; set; }
        public string NativePlace { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public bool? HaseMedicalHistory { get; set; }
        public string MedicalHistoryComment { get; set; }
        public string HobbiesAndSpeciality { get; set; }
        public DateTime? EducationalExperience1StartDate { get; set; }
        public DateTime? EducationalExperience1EndDate { get; set; }
        public string EducationalExperience1SchoolName { get; set; }
        public string EducationalExperience1Major { get; set; }
        public string EducationalExperience1Certificate { get; set; }
        public DateTime? EducationalExperience2StartDate { get; set; }
        public DateTime? EducationalExperience2EndDate { get; set; }
        public string EducationalExperience2SchoolName { get; set; }
        public string EducationalExperience2Major { get; set; }
        public string EducationalExperience2Certificate { get; set; }
        public DateTime? EducationalExperience3StartDate { get; set; }
        public DateTime? EducationalExperience3EndDate { get; set; }
        public string EducationalExperience3SchoolName { get; set; }
        public string EducationalExperience3Major { get; set; }
        public string EducationalExperience3Certificate { get; set; }
        public DateTime? EducationalExperience4StartDate { get; set; }
        public DateTime? EducationalExperience4EndDate { get; set; }
        public string EducationalExperience4SchoolName { get; set; }
        public string EducationalExperience4Major { get; set; }
        public string EducationalExperience4Certificate { get; set; }
        public string FamilyStatus1Name { get; set; }
        public string FamilyStatus1Appellation { get; set; }
        public string FamilyStatus1Company { get; set; }
        public string FamilyStatus1Tel { get; set; }
        public string FamilyStatus2Name { get; set; }
        public string FamilyStatus2Appellation { get; set; }
        public string FamilyStatus2Company { get; set; }
        public string FamilyStatus2Tel { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactTel { get; set; }
        public string EmergencyContactEelationShipWithMe { get; set; }
        public string WorkExperience1CompanyName { get; set; }
        public string WorkExperience1Job { get; set; }
        public DateTime? WorkExperience1StartDate { get; set; }
        public DateTime? WorkExperience1EndDate { get; set; }
        public string WorkExperience1Pay { get; set; }
        public string WorkExperience1LeavingReasons { get; set; }
        public string WorkExperience2CompanyName { get; set; }
        public string WorkExperience2Job { get; set; }
        public DateTime? WorkExperience2StartDate { get; set; }
        public DateTime? WorkExperience2EndDate { get; set; }
        public string WorkExperience2Pay { get; set; }
        public string WorkExperience2LeavingReasons { get; set; }
        public string WorkExperience3CompanyName { get; set; }
        public string WorkExperience3Job { get; set; }
        public DateTime? WorkExperience3StartDate { get; set; }
        public DateTime? WorkExperience3EndDate { get; set; }
        public string WorkExperience3Pay { get; set; }
        public string WorkExperience3LeavingReasons { get; set; }
        public string WorkExperience4CompanyName { get; set; }
        public string WorkExperience4Job { get; set; }
        public DateTime? WorkExperience4StartDate { get; set; }
        public DateTime? WorkExperience4EndDate { get; set; }
        public string WorkExperience4Pay { get; set; }
        public string WorkExperience4LeavingReasons { get; set; }
        public Guid? JobId { get; set; }
        public string Title { get; set; }
        public Guid? OrganizationId { get; set; }
        public string SupervisorComments { get; set; }
        public string ProbationarySalary { get; set; }
        public string CorrectSalary { get; set; }
        public string WorkNumber { get; set; }
        public DateTime? EntryDate { get; set; }
        public string BirthCertificatePhoto { get; set; }
        public string RegistrationPhoto { get; set; }
        public string BankCardNumber { get; set; }
        public Guid? CreateStaffeId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string No { get; set; }
        public string StaffNo { get; set; }
        public bool IsDel { get; set; }
    }
}
