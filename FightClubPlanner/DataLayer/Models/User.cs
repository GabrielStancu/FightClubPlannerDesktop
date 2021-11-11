using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public abstract class User : BaseModel
    {
        private string _fullName;
        [NotMapped]
        public string FullName 
        {
            get 
            {
                _fullName = $"{FirstName} {LastName}";
                return _fullName;
            }  
            set
            {
                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
