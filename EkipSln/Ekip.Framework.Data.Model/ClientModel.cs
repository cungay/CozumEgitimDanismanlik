using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekip.Framework.Data.Model
{
    public class ClientModel
    {
        public int ClientId { get; set; }

        public int FileNumber { get; set; }

        public DateTime FirstContactDate { get; set; }

        public int FirstContactAge { get; set; }

        public int CurrentAge { get; set; }

        public DateTime BirthDate { get; set; }

        public int CalendarAgeId { get; set; }

        public string FullName { get; set; }

        public string MiddleName { get; set; }

        public string Referance { get; set; }

        public int? MotherId { get; set; }

        public int? FatherId { get; set; }

        public int? AddressId { get; set; }

        public string IdCard { get; set; }

        public byte? Gender { get; set; }

        public byte? Blood { get; set; }

        public string Pediatrician { get; set; }

        public int CountOfChild { get; set; }

        public byte? FamilyStatus { get; set; }

        public string Notes { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int CreateUserId { get; set; }

        public int? UpdateUserId { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public MotherModel Mother { get; set; }

        public FatherModel Father { get; set; }
    }
}
