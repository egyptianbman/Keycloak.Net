using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Equivalency;
using Keycloak.Net.Shared.Json;

namespace Keycloak.Net.Tests
{
    /// <summary>
    /// See https://github.com/fluentassertions/fluentassertions/issues/1086#issuecomment-503301058.
    /// </summary>
    public class IgnoreNullMembersInExpectation : IMemberSelectionRule
    {
        public IgnoreNullMembersInExpectation(object expectation)
        {
            _expectation = expectation;
        }

        private readonly object _expectation;

        public IEnumerable<IMember> SelectMembers(INode currentNode, IEnumerable<IMember> selectedMembers, MemberSelectionContext context)
        {
            var selectedMembersList = selectedMembers.ToList();
            var filteredMembersList = new List<IMember>(selectedMembersList);

            // Ignore filtering if node types are different.
            if (_expectation.GetType() != currentNode.Type)
            {
                return selectedMembersList;
            }

            foreach (var selectedMemberInfo in selectedMembersList)
            {
                var value = selectedMemberInfo.GetValue(_expectation);
                var @default = selectedMemberInfo.Type.GetDefault();
                if (value == @default || value.Equals(@default))
                {
                    filteredMembersList.Remove(selectedMemberInfo);
                }
            }

            return filteredMembersList;
        }

        public bool IncludesMembers => false;

        /// <inheritdoc />
        public override string ToString()
        {
            return "Exclude member when it's value is 'default'.";
        }
    }
}
