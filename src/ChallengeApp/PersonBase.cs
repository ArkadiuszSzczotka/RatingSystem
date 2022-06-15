using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public abstract class PersonBase
    {
        private string name;
        public string Name 
        {
            get { return name; }
            set
            {
                if(String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid argument {nameof(Name)}");
                }
                foreach(char c in value)
                {
                    if(char.IsDigit(c))
                    {
                        throw new ArgumentException($"Invalid argument {nameof(Name)}");
                    }
                }
                this.name = value;
            }
        }

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
        public abstract DateTime SetDateOfBirth();
            
    }
}