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
        
        public long Id { get; set; }
        
        public Guid Uid { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }

        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        
        public bool IsDeleted { get; set; }

        public virtual ICollection<OperationResult> OperationResults { get; set; }

        public virtual ICollection<UserFavouriteResult> UserFavouriteResults { get; set; }
    }
}
