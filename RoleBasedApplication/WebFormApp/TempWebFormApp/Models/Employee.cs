using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TempWebFormApp.Models
{
    [DataContract]
    public class Employee
    {
        internal Employee()
        {
            DOJ = DateTime.UtcNow;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public DateTime DOJ { get; set; }
        [DataMember]
        public string Role { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public List<Remark> Remarks { get; set; }
    }
}