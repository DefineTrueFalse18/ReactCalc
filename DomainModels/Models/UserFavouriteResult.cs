using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    [Table("UserFavouriteResult")]
    public class UserFavouriteResult
    {
        public virtual long Id { get; set; }

        [Obsolete]
        public virtual long UserId { get; set; }

        public virtual User User { get; set; }
        [Obsolete]
        public virtual long ResultId { get; set; }

        public virtual OperationResult Result { get; set; }
    }
}
