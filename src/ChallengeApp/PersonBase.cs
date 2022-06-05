using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class PersonBase
    {
        public string Name { get; set; }

        public PersonBase(string name)
        {
            this.Name = name;
        }

        public PersonBase(string name, DateTime date) : this(name)
        {
            this.dateOfBirth = date;
        }
        
        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Inavlid date of birth");
                }
                else
                {  
                    dateOfBirth = value;
                }
            }
        }        
    }
}