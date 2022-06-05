using System;
using Xunit;
using ChallengeApp;

namespace Challenge.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetEmployeeReturnsDifferentObjects()
        {
            var emp1 = GetEmployee("Frank");
            var emp2 = GetEmployee("Arek");

            Assert.NotSame(emp1, emp2);
            Assert.False(Object.ReferenceEquals(emp1, emp2));
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var em1 = GetEmployee("Adam");
            var em2 = em1;

            Assert.Same(em1, em2);
            Assert.True(Object.ReferenceEquals(em1, em2));
        }

        [Fact]
        public void CanSetNameByReference()
        {
            var em1 = GetEmployee("Arek");
            this.SetName(ref em1, "NewName");
            Assert.Equal("NewName", em1.Name);
        }

        [Fact]
        public void CanSetTrueNameByReference()
        {
            var em1 = GetEmployee("Arek");
            this.ChangeName(em1, "Bartek");
            Assert.Equal("Bartek", em1.Name);
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            Employee emp1 = null;
            GetEmployeeSetName(out emp1, "New name");
            Assert.Equal("New name", emp1.Name);

        }


        private void ChangeName(Employee employee, string name) 
        {
            employee.Name = name;
        }

        private void GetEmployeeSetName(out Employee emp, string name)
        {
            emp = new Employee(name, new DateTime(9999, 12, 12));
        }
        private Employee GetEmployee(string name)
        {
            return new Employee(name, new DateTime(1, 1, 1));
        }

        private void SetName (ref Employee employee, string name)
        {
            employee = new Employee("new", new DateTime(1, 1, 1));
            employee.Name = name;
        }
    }
}
