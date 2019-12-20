using OneData.Attributes;
using OneData.Interfaces;
using OneData.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    [DataTable("gender")]
    public class Gender : Cope<Gender>, IManageable
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        [DateCreated]
        public DateTime DateCreated { get; set; }
        [DateModified]
        public DateTime DateModified { get; set; }

        public string Name { get; set; }
        [Default(30)]
        public string Description { get; set; }


        public Gender()
        {
            Id = Guid.NewGuid();
        }

        public Gender(Guid id)
        {
            Id = id;
        }
    }
}
