﻿using FluentAssertions;
using NetArchTest.Rules;
using SharedKernel;
using System.Reflection;

namespace ArchitectureTests.Domain
{
    public class DomainTests : BaseTest
    {

        [Fact]
        public void DomainEvents_Should_BeSealed()
        {
            TestResult result = Types.InAssembly(DomainAssembly)
                .That()
                .ImplementInterface(typeof(IDomainEvent))
                .Should()
                .BeSealed()
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }


        [Fact]
        public void DomainEvents_Should_HaveDomainEventsPostFix()
        {
            TestResult result = Types.InAssembly(DomainAssembly)
                .That()
                .ImplementInterface(typeof(IDomainEvent))
                .Should()
                .HaveNameEndingWith("DomainEvents")
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }


        [Fact]
        public void DomainEvents_Should_HavePrivateParameterLessConstructor()
        {
            IEnumerable<Type> entityTypes = Types.InAssembly(DomainAssembly)
                .That()
                .Inherit(typeof(Entity))
                .GetTypes();

            var failingTypes = new List<Type>();
            foreach (var entityType in entityTypes)
            {
                ConstructorInfo[] constructors = entityType.GetConstructors(BindingFlags.NonPublic |
                                                                            BindingFlags.Instance);

                if (!constructors.Any(c => c.IsPrivate && c.GetParameters().Length == 0))
                {
                    failingTypes.Add(entityType);
                }
            }

            failingTypes.Should().BeEmpty();
        }
    }
}
