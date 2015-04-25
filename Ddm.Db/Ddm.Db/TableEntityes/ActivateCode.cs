using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ddm.Db.TableEntityes
{
    [DataContract]
    public class ActivateCode
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public Guid UserId { get; set; }
    }
}
