using OneData.Attributes;
using OneData.Interfaces;
using OneData.Models;
using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace Movies.Models
{
    [DataTable("movies")]
    public class Movie : Cope<Movie>, IManageable
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        [DateCreated]
        public DateTime DateCreated { get; set; }

        [DateModified]
        public DateTime DateModified { get; set; }

        [DisplayName("Movie Title")]
        public string Title { get; set; }

        [DisplayName("Sinopsis")]
        public string Sinopsis { get; set; }

        [DisplayName("Director")]
        public string Director { get; set; }

        [DisplayName("Duration in minutes")]
        public double Duration { get; set; }

        [DisplayName("Clasification")]
        public string Clasification { get; set; }

        [DisplayName("Rating")]
        public string Rating { get; set; }

        [DisplayName("Score")]
        public float Score { get; set; }

        [AllowNull]
        public string Image { get; set; }

        [ForeignKey(typeof(Origin)), DisplayName("Country of Origin")]
        public Guid OriginId { get; set; }
        [ForeignData(typeof(Origin))]
        public string OriginName { get; set; }

        [ForeignKey(typeof(Gender)), DisplayName("Gender")]
        public Guid GenderId { get; set; }
        [ForeignData(typeof(Gender))]
        public string GenderName { get; set; }

        public Movie()
        {
            Id = Guid.NewGuid();
        }

        public Movie(Guid id)
        {
            Id = id;
        }

    }
}
