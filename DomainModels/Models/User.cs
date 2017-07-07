using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Models
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            OperationResults = new List<OperationResult>();
            UserFavouriteResults = new List<UserFavouriteResult>();
        }

        public virtual long Id { get; set; }

        public virtual Guid Uid { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        [Display(Name = "ФИО")]
        public virtual string FIO { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual ICollection<OperationResult> OperationResults { get; set; }

        public virtual ICollection<UserFavouriteResult> UserFavouriteResults { get; set; }
    }
}
