using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekip.Framework.Data.Model
{
    public class MotherModel
    {
        public int MotherId { get; set; }

        public string FullName { get; set; }

        public string Title { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        public string HomePhone { get; set; }

        public string BusinessPhone { get; set; }

        public string MobilePhone { get; set; }

        public string OtherPhone { get; set; }

        public int? JobId { get; set; }

        public string Notes { get; set; }

        public byte MotherStatusId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int CreateUserId { get; set; }

        public int? UpdateUserId { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

    }
}
