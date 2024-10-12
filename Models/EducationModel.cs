
using System.ComponentModel;

namespace InternConnect.Models
{
    class EducationModel
    {
        private string _levelOfEducation = string.Empty;
        private string _institutionAttended = string.Empty;
        private string _majorFieldOfStudy = string.Empty;
        private DateTime _graduationDates = DateTime.Now;
        private bool _previousInternshipsOrJobs = false;
        private string _companyNames = string.Empty;
        private string _jobTitles = string.Empty;
        private string _responsibilitiesAndAccomplishments = string.Empty;
        private string _technicalSkills = string.Empty;
        private string _softSkills = string.Empty;
        public event PropertyChangedEventHandler? PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string LevelOfEducation
        {
            get => _levelOfEducation;
            set
            {
                _levelOfEducation = value;
                RaisePropertyChanged(nameof(LevelOfEducation));
            }
        }

        public string InstitutionAttended
        {
            get => _institutionAttended;
            set
            {
                _institutionAttended = value;
                RaisePropertyChanged(nameof(InstitutionAttended));
            }
        }

        public string MajorFieldOfStudy
        {
            get => _majorFieldOfStudy;
            set
            {
                _majorFieldOfStudy = value;
                RaisePropertyChanged(nameof(MajorFieldOfStudy));
            }
        }

        public DateTime GraduationDates
        {
            get => _graduationDates;
            set
            {
                _graduationDates = value;
                RaisePropertyChanged(nameof(GraduationDates));
            }
        }

        public bool PreviousInternshipsOrJobs
        {
            get => _previousInternshipsOrJobs;
            set
            {
                _previousInternshipsOrJobs = value;
                RaisePropertyChanged(nameof(PreviousInternshipsOrJobs));
            }
        }

        public string CompanyNames
        {
            get => _companyNames;
            set
            {
                _companyNames = value;
                RaisePropertyChanged(nameof(CompanyNames));
            }
        }

        public string JobTitles
        {
            get => _jobTitles;
            set
            {
                _jobTitles = value;
                RaisePropertyChanged(nameof(JobTitles));
            }
        }

        public string ResponsibilitiesAndAccomplishments
        {
            get => _responsibilitiesAndAccomplishments;
            set
            {
                _responsibilitiesAndAccomplishments = value;
                RaisePropertyChanged(nameof(ResponsibilitiesAndAccomplishments));
            }
        }

        public string TechnicalSkills
        {
            get => _technicalSkills;
            set
            {
                _technicalSkills = value;
                RaisePropertyChanged(nameof(TechnicalSkills));
            }
        }

        public string SoftSkills
        {
            get => _softSkills;
            set
            {
                _softSkills = value;
                RaisePropertyChanged(nameof(SoftSkills));
            }
        }
    }
}
